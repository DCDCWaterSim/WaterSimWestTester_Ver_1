/**********************************************************************************
	dbUtils.cs 7/10/12  Quay

 *  A static class that provides generic OleDb database support routines 
	Copyright (C) 2011 Ray Quay
 * 
	All rights reserved.
	
	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License version 3 as published by
	the Free Software Foundation.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.


 *  General ODBC Database Utilities
		public static List<string> GetTableNames(OleDbConnection Connection, ref Boolean error, ref string errString)
		public static DataTable LoadTable(OleDbConnection dbConnection, string tablename, ref bool error, ref string errString)
        public static DataTable LoadTable(OleDbConnection dbConnection, string tablename, string Conditions,ref bool error, ref string errString)
		static public OleDbConnection OpenDatabase(string Filename, string ConnectionString)
        public static bool ConvertdbTableToText(OleDbConnection dbCon, string tablename, TxtFieldMode mode, string newtablename, ProgressReport PR, bool CreateDataDefineFile, ref string errMessage)
        public static int ConvertToInt32(string valueStr, ref bool IsError, ref string errMessage)
        public static int ConvertToInt16(string valueStr, ref bool IsError, ref string errMessage)
        public static double ConvertToDouble(string valueStr, ref bool IsError, ref string errMessage)

 * Version 1.2
 * 7/10/12

 *******************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;


namespace dbTools
{
    static class dbTool
    {
        const int MAXINT32SIZE = 2147483647;
        const int MININT32SIZE = -2147483648;
        const int MAXINT16SIZE = 0;
        const int MININT16SIZE = 0;
        const int MAXLONGSIZE = 0;
        const int MINLONGSIZE = 0;

        public delegate void ProgressReport(string report, int i, int max);

        public static bool oledbColumnIsString(DataColumn DC)
        {
            bool result = false;
            result = (DC.DataType == System.Type.GetType("System.String"));
            return result;
        }
        public enum TxtFieldMode {cmCommaDelimited, cmFixedFieldWidth, cmSpaceDelimited};

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Convert DataTable to text file. </summary>
        ///
        /// <param name="dbCon">                The database connection </param>
        /// <param name="tablename">            name of the data table to load </param>
        /// <param name="mode">                 The mode for writing the text file </param>
        /// <param name="newtablename">         The newtablename. </param>
        /// <param name="PR">                   Use this delegate to report progress </param>
        /// <param name="CreateDataDefineFile"> true to create data definition file for the text . </param>
        /// <param name="errMessage">           Message describing the error if returns false. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ///-------------------------------------------------------------------------------------------------

        public static bool ConvertdbTableToText(OleDbConnection dbCon, string tablename, TxtFieldMode mode, string newtablename, ProgressReport PR, bool CreateDataDefineFile, ref string errMessage)
        {
            bool result = false;
            bool iserr = false;
            List<int> FieldWidths = new List<int>();
            string Delimiter = "";
            string ModeStr = "";


            switch(mode)
            {
                case TxtFieldMode.cmCommaDelimited:
                    Delimiter = ", ";
                    ModeStr = "Comma Delimited";
                    break;
                case TxtFieldMode.cmSpaceDelimited:
                    Delimiter = " ";
                    ModeStr = "Space Delimited";
                    break;
                case TxtFieldMode.cmFixedFieldWidth:
                    Delimiter = "";
                    ModeStr = "Fixed Field Width";
                    break;

            }
            DataTable InputData = LoadTable(dbCon, tablename, ref iserr, ref errMessage);
            if (iserr)
            {
                result = false;
            }
            else
            // table loaded lets go
            {
                int ReportMaximum = InputData.Rows.Count;
                string ext = Path.GetExtension(newtablename);
                int extindex = newtablename.IndexOf(ext);
                string pathfilename = newtablename.Substring(0,extindex);
                string docfilename = pathfilename + "_Data_Definition" + ext;
                try  // Textwriter
                {
                    int ReportOnRowCnt = InputData.Rows.Count / 100;
                    if (ReportOnRowCnt == 0)
                        ReportOnRowCnt = 1;

                    using (TextWriter DataWwriter = File.CreateText(newtablename))
                    {
                        int RowCnt = 0;
                        foreach (DataRow DR in InputData.Rows)
                        {
                            string RowStr = "";
                            int colcnt = 0;
                            foreach (DataColumn DC in InputData.Columns)
                            {
                                string FldDataStr = "";
                                if (colcnt > 0)
                                    FldDataStr += Delimiter;
                                bool IsString = oledbColumnIsString(DC);
                                if (IsString)
                                    FldDataStr += '"';
                                FldDataStr += DR[DC.ColumnName].ToString();
                                if (IsString)
                                    FldDataStr += '"';
                                RowStr += FldDataStr;
                                colcnt++;
                            }
                            DataWwriter.WriteLine(RowStr);
                            if ((PR != null) && ((RowCnt % ReportOnRowCnt) == 0))
                                PR("Writing",RowCnt,ReportMaximum);
                            RowCnt++;
                        }
                    }
                }
                catch(Exception e)
                {
                    result = false;
                    errMessage = "Error writing new file" + newtablename + ".  Error:" + e.Message;
                
                }
                try{
                    if (CreateDataDefineFile)
                    {
                        using (TextWriter DocWriter = File.CreateText(docfilename))
                        {
                            DocWriter.WriteLine("Data Definition for " + newtablename);
                            DocWriter.WriteLine(DateTime.Today.ToShortDateString() + "  " + DateTime.Today.ToShortTimeString());
                            string outstr = "Database: " + dbCon.ConnectionString + "  Tablename: " + tablename;
                            DocWriter.WriteLine(outstr);
                            DocWriter.WriteLine("Format: " + ModeStr);

                            DocWriter.WriteLine("# ColumnName");
                            int cnt = 0;
                            foreach (DataColumn DC in InputData.Columns)
                            {

                                outstr = cnt.ToString().PadRight(7) + DC.ColumnName;
                                DocWriter.WriteLine(outstr);
                                cnt++;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    result = false;
                    errMessage = "Error writing Data Definition file"+docfilename+".  Error:" + e.Message;
                }

            }
           

            return result;
        }
            //-----------------------------------------------------------------------

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Converts this object to an int 32. </summary>
        ///
        /// <param name="valueStr">     The value string. </param>
        /// <param name="IsError">      The is error. </param>
        /// <param name="errMessage">   Message describing the error. </param>
        ///
        /// <returns>   The given data converted to an int 32. </returns>
        ///-------------------------------------------------------------------------------------------------

        public static int ConvertToInt32(string valueStr, ref bool IsError, ref string errMessage)
            {
                int result = 0;
                IsError = true;
                try
                {
                    result = Convert.ToInt32(valueStr);
                    IsError = false;
                    errMessage = "";
                }
                catch (Exception ex)
                {
                    errMessage = "Conversion Error: " + ex.Message;
                }
                return result;
            }
            //-----------------------------------------------------------------------
            public static int ConvertToInt16(string valueStr, ref bool IsError, ref string errMessage)
            {
                int result = 0;
                IsError = true;
                try
                {
                    result = Convert.ToInt16(valueStr);
                    IsError = false;
                    errMessage = "";
                }
                catch (Exception ex)
                {
                    errMessage = "Conversion Error: " + ex.Message;
                }
                return result;
            }
            //-----------------------------------------------------------------------

            ///-------------------------------------------------------------------------------------------------
            /// <summary>   Converts this object to a double. </summary>
            ///
            /// <param name="valueStr">     The value string. </param>
            /// <param name="IsError">      [in,out] The is error. </param>
            /// <param name="errMessage">   [in,out] Message describing the error. </param>
            ///
            /// <returns>   The given data converted to a double. </returns>
            ///-------------------------------------------------------------------------------------------------

            public static double ConvertToDouble(string valueStr, ref bool IsError, ref string errMessage)
            {
                double result = 0;
                IsError = true;
                try
                {
                    result = Convert.ToDouble(valueStr);
                    IsError = false;
                    errMessage = "";
                }
                catch (Exception ex)
                {
                    errMessage = "Conversion Error: " + ex.Message;
                }
                return result;
            }
       
        /// <summary>
        /// Gets a list of tablenames from the Database connected to Connection
        /// </summary>
        /// <param name="Connection"> </param>
        /// <param name="error">If there is an exception then this returns true, returns message in errString</param>
        /// <param name="errString">If there is an exception this returns Exception.Message</param>
        /// <returns>a List<> of strings of tablenames that are TABLE_TYPE TABLE, ie no system tables </returns>
        /// <remarks> if Connection is not null, but not open, this routine opens them</remarks>
        /// <remarks>   Mcquay, 6/21/2012. </remarks>

        public static List<string> GetTableNames(OleDbConnection Connection, ref Boolean error, ref string errString)
        {
            List<string> _tablenames = new List<string>();
            OleDbConnection _dbConnect = Connection;
            bool validConnection = (_dbConnect != null);
            error = true;
            errString = "";
            if (validConnection)
            {
                bool orgOpen = (_dbConnect.State == System.Data.ConnectionState.Open);
                try
                {
                    string temp = "";
                    if (!orgOpen) _dbConnect.Open();
                    _tablenames.Clear();
                    DataTable dbSchema = new DataTable();
                    dbSchema = _dbConnect.GetSchema("TABLES");
                    for (int i = 0; i < dbSchema.Rows.Count; i++)
                    {
                        if (dbSchema.Rows[i]["TABLE_TYPE"].ToString() == "TABLE")
                        {
                            temp = dbSchema.Rows[i]["TABLE_NAME"].ToString();
                            _tablenames.Add(temp);
                        }
                    }
                    error = false;
                }
                catch (Exception e)
                {
                    errString = e.Message;
                }
            }
            else
            {
                errString = "oleDbConnection must be non null";
            }
            return _tablenames;

        }
        //-----------------------------------------------------------------------------
        /// <summary>
        /// Static method to load all fields all records of a table from a database using OleDbConnection that is already open
        /// uses sql command   "Select * from [tablename]"
        /// </summary>
        /// <param name="dbConnection">oleDbConection that is connected to database</param>
        /// <param name="tablename"> name of the table to load</param>
        /// <returns>DataTable </returns>
        public static DataTable LoadTable(OleDbConnection dbConnection, string tablename, ref bool error, ref string errString)
        {
            DataTable DT = new DataTable();
            error = true;
            errString = "";
            if (dbConnection != null)
            {
                if (dbConnection.State == ConnectionState.Open)
                {
                    if (tablename != "")
                    {
                        string sqltext = "";
                        try
                        {
                            sqltext = "Select * from " + '[' + tablename + ']';
                            OleDbDataAdapter NewRawTableAdapter = new OleDbDataAdapter(sqltext, dbConnection);
                            NewRawTableAdapter.Fill(DT);
                            error = false;
                        }
                        catch (Exception e)
                        {
                            errString = e.Message + " reading table [" + tablename + "] from " + dbConnection.ConnectionString + " using <" + sqltext + ">";
                        }
                    }
                    else
                    {
                        errString = "Fatal Error reading table [" + tablename + "] Tablename must not be null";
                    }
                }
                else
                {
                    errString = "Fatal Error reading table [" + tablename + "] . dbConnection must be Open";
                }
            }
            else
            {
                errString = "Fatal Error reading table [" + tablename + "]. dbConnection cannot be null";
            }
            return DT;
        }

        //-----------------------------------------------------------------------------
        /// <summary>
        /// Static method to load all fields and all records meeting Conditions of a table from a database using OleDbConnection that is already open
        /// uses sql command   "Select * from [tablename] Where [Conditions]"
        /// </summary>
        /// <param name="dbConnection">oleDbConection that is connected to database</param>
        /// <param name="tablename"> name of the table to load</param>
        /// <returns>DataTable </returns>
        public static DataTable LoadTable(OleDbConnection dbConnection, string tablename, string Conditions,ref bool error, ref string errString)
        {
            DataTable DT = new DataTable();
            error = true;
            errString = "";
            if (dbConnection != null)
            {
                if (dbConnection.State == ConnectionState.Open)
                {
                    if (tablename != "")
                    {
                        string sqltext = "";
                        try
                        {
                            sqltext = "Select * from " + '[' + tablename + "] Where "+Conditions;
                            OleDbDataAdapter NewRawTableAdapter = new OleDbDataAdapter(sqltext, dbConnection);
                            NewRawTableAdapter.Fill(DT);
                            error = false;
                        }
                        catch (Exception e)
                        {
                            errString = e.Message + " reading table [" + tablename + "] from " + dbConnection.ConnectionString + " using <" + sqltext + ">";
                        }
                    }
                    else
                    {
                        errString = "Fatal Error reading table [" + tablename + "] Tablename must not be null";
                    }
                }
                else
                {
                    errString = "Fatal Error reading table [" + tablename + "] . dbConnection must be Open";
                }
            }
            else
            {
                errString = "Fatal Error reading table [" + tablename + "]. dbConnection cannot be null";
            }
            return DT;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Static method to specified columns for all records of a table from a database using
        ///             OleDbConnection that is already open uses sql command   "Select [FieldList] from
        ///             [tablename]". </summary>
        ///
        /// <param name="dbConnection"> oleDbConection that is connected to database. </param>
        /// <param name="tablename">    name of the table to load. </param>
        /// <param name="FieldList">    List of Columns. </param>
        /// <param name="error">        If there is an exception then this returns true, returns message
        ///                             in errString. </param>
        /// <param name="errString">    If there is an exception this returns Exception.Message. </param>
        ///
        /// <returns>   DataTable. </returns>
        ///-------------------------------------------------------------------------------------------------

        public static DataTable LoadTable(OleDbConnection dbConnection, string tablename, List<string> FieldList, ref bool error, ref string errString)
        {
            DataTable DT = new DataTable();
            error = true;
            errString = "";
            if (dbConnection != null)
            {
                if (dbConnection.State == ConnectionState.Open)
                {
                    if (tablename != "")
                    {
                        string sqltext = "";
                        try
                        {
                            string ColList = FieldList[0];
                            if (FieldList.Count > 1)
                                for (int i = 1; i < FieldList.Count; i++)
                                    ColList += " , " + FieldList[i];
                            sqltext = "Select "+ColList+" from " + '[' + tablename + ']';
                            OleDbDataAdapter NewRawTableAdapter = new OleDbDataAdapter(sqltext, dbConnection);
                            NewRawTableAdapter.Fill(DT);
                            error = false;
                        }
                        catch (Exception e)
                        {
                            errString = e.Message + " reading table [" + tablename + "] from " + dbConnection.ConnectionString + " using <" + sqltext + ">";
                        }
                    }
                    else
                    {
                        errString = "Fatal Error reading table [" + tablename + "] Tablename must not be null";
                    }
                }
                else
                {
                    errString = "Fatal Error reading table [" + tablename + "] . dbConnection must be Open";
                }
            }
            else
            {
                errString = "Fatal Error reading table [" + tablename + "]. dbConnection cannot be null";
            }
            return DT;
        }


        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Static method to load specified Columns for all records meeting Conditions of a table from a database using
        ///             OleDbConnection that is already open uses sql command   "Select [FielList] from
        ///             [tablename] Where [Conditions]". </summary>
        ///
        /// <param name="dbConnection"> oleDbConection that is connected to database. </param>
        /// <param name="tablename">    name of the table to load. </param>
        /// <param name="FieldList">    List of Columns. </param>
        /// <param name="Conditions">   The conditions. </param>
        /// <param name="error">        If there is an exception then this returns true, returns message
        ///                             in errString. </param>
        /// <param name="errString">    If there is an exception this returns Exception.Message. </param>
        ///
        /// <returns>   DataTable. </returns>
        ///-------------------------------------------------------------------------------------------------

        public static DataTable LoadTable(OleDbConnection dbConnection, string tablename, List<string> FieldList, string Conditions, ref bool error, ref string errString)
        {
            DataTable DT = new DataTable();
            error = true;
            errString = "";
            if (dbConnection != null)
            {
                if (dbConnection.State == ConnectionState.Open)
                {
                    if ((tablename != "")&(Conditions!="")&(FieldList.Count>0))
                    {
                        string sqltext = "";
                        try
                        {
                            // Build ColumnList
                            string ColList = FieldList[0];
                            if (FieldList.Count > 1)
                                for (int i = 1; i < FieldList.Count; i++)
                                    ColList += " , " + FieldList[i];
                            sqltext = "Select "+ColList+" from " + '[' + tablename + "] Where " + Conditions;
                            OleDbDataAdapter NewRawTableAdapter = new OleDbDataAdapter(sqltext, dbConnection);
                            NewRawTableAdapter.Fill(DT);
                            error = false;
                        }
                        catch (Exception e)
                        {
                            errString = e.Message + " reading table [" + tablename + "] from " + dbConnection.ConnectionString + " using <" + sqltext + ">";
                        }
                    }
                    else
                    {
                        errString = "Fatal Error reading table [" + tablename + "] Tablename, Conditions, and Fieldlist must not be null";
                    }
                }
                else
                {
                    errString = "Fatal Error reading table [" + tablename + "] . dbConnection must be Open";
                }
            }
            else
            {
                errString = "Fatal Error reading table [" + tablename + "]. dbConnection cannot be null";
            }
            return DT;
        }
        const string DATASOURCESTR = "data source=";
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Opens a database </summary>
        ///
        /// <remarks>   Mcquay, 7/2/2012. </remarks>
        ///
        /// <exception cref="Exception">    Thrown when exception occurs during attempt to open. </exception>
        ///
        /// <param name="Filename">         Filename of the database file. </param>
        /// <param name="ConnectionString"> The connection string to use. In this string must include the phrase "data source="  
        /// 								The filename will be inserted in the connection string at this location.</param>
        ///
        /// <returns> if succesful, an Open OleDbConnection connected to the database  . </returns>
        ///-------------------------------------------------------------------------------------------------

        static public OleDbConnection OpenDatabase(string Filename, string ConnectionString)
        {
            int index = ConnectionString.IndexOf(DATASOURCESTR);
            if (index == -1)
            {
                throw new Exception("Connection string does not contain a '" + DATASOURCESTR + "' in the string");
            }
            try
            {
                index = index + DATASOURCESTR.Length;
                string Connectstr = ConnectionString.Substring(0, index) + Filename + ConnectionString.Substring(index);
                OleDbConnection FDbConnection = new OleDbConnection(Connectstr);
                FDbConnection.Open();
                return FDbConnection;
            }
            catch (Exception e)
            {
                throw new Exception("Unable  to open Database " + Filename + " : " + e.Message);
            }
        }

        const int siSQLCHAR = 1;
        const int siSQLFLOAT = 2;
        const int siSQLSINGLE = 3;
        const int siSQLDOUBLE = 4;
        const int siSQLINT16 = 5;
        const int siSQLINT32 = 6;
        const int siSQLINT64 = 7;
        const int siSQLDATE = 8;
        const int siSQLTIME = 9;
        const int SQLTYPENUMBER = 10;

       public  enum SQLServer { stAccess, stMySQL, stPostgreSQL };
       static string[] SQL_ACCESS = new string[SQLTYPENUMBER] { "ACCESS", "CHAR", "CURRENCY", "SINGLE", "DOUBLE", "SMALLINT", "INTEGER", "DOUBLE", "DATE", "TIME" };

        public static string GetSQLType(int index, SQLServer Server)
        {
            string temp = "";
            if ((index >= 0) && (index < SQLTYPENUMBER))
            {
                switch (Server)
                {
                    case SQLServer.stAccess:
                        temp = SQL_ACCESS[index];
                        break;

                }
            }
            return temp;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates a directory. </summary>
        /// <param name="directoryName">    Pathname of the directory. </param>
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ///-------------------------------------------------------------------------------------------------

        static public bool CreateDirectory(string directoryName)
        {
            bool createdok = false;
            try
            {
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(directoryName);
                if (!dir.Exists)
                {
                    dir.Create();
                    createdok = true;
                }
            }
            catch
            {
            }
            return createdok;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Reads all lines from a text file and returns them in a  List<string>. </summary>
        /// <param name="Filename">     Filename of the database file. </param>
        /// <param name="errString">    [in,out] If there is an exception this returns Exception.Message. </param>
        ///
        /// <returns>   The lines from text file. </returns>
        ///-------------------------------------------------------------------------------------------------

        static public List<string> ReadLinesFromTextFile(string Filename, ref string errString) // Including path
        {
            List<String> Lines = new List<string>();
            
            try
            {
                using (StreamReader sr = new StreamReader(Filename))
                {
                String line;
                // Read and display lines from the file until the end of
                // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        Lines.Add(line);
                    }
                }
                return Lines;               
            }
            catch (Exception e)
            {
                errString = e.Message;
                return Lines;
            }
        }


        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Dynamic text data </summary>
        /// <remarks> This class is used to parce a text field an determines what type of data types can the field be.
        ///           Though this class provides a lot of flexibility in reading and converting text fields, it can also 
        ///           be quite slow and resource intensive.  The more you know about your data, and the less you have
        ///           to explore what data types the text field will support, the faster this will be.  
        ///           The reason for this is that this class uses try catch blocsk to trapp exceptions thrown by System.Convert() in order to
        ///           determine what data types are not valid for the text field.  Thus multiple calls to different the "Canbe" methods
        ///           that fail can generate a lot of system exceptions which can slow things down substantially.  </remarks>
        ///-------------------------------------------------------------------------------------------------

        public class DynamicTextData
        {
            string FTextValue = "";
  
            ///-------------------------------------------------------------------------------------------------
            /// <summary>   Constructor. </summary>
            /// <param name="Text"> The text of the data field </param>
            ///-------------------------------------------------------------------------------------------------

            public DynamicTextData(string Text)
            {
                FTextValue = Text.Trim();
            }

            //===============================
            //  INT32 
            int Fint = 0;
            bool FIntTested = false;
            bool FCanbeInt = false;
            //-------------
            internal void TestInt()
            {
                if (!FIntTested)
                {
                    try
                    {
                        Fint = Convert.ToInt32(FTextValue);
                        FCanbeInt = true;
                        FIntTested = true;
                    }
                    catch
                    {
                        FCanbeInt = false;
                        FIntTested = true;
                    }
                }
            }
            //-----------------

            ///-------------------------------------------------------------------------------------------------
            /// <summary>   Determine if field can be int. </summary>
            /// <returns>   true if we can be int, false if not. </returns>
            ///-------------------------------------------------------------------------------------------------

            public bool CanBeInt()
            {
               TestInt();
                return FCanbeInt;
            }
            //------------------

            ///-------------------------------------------------------------------------------------------------
            /// <summary>   Gets an int value for field. </summary>
            /// <value> The value as int. </value>
            /// <exception cref="Exception">Throws Exception if not an int value</exception>
            /// <seealso cref="ValueLong"/>
            /// <seealso cref="ValueShort"/>
            ///-------------------------------------------------------------------------------------------------

            public int ValueInt
            {
                get
                {
                   TestInt();
                    if (FCanbeInt)
                        return Fint;
                    else
                        throw new Exception("Not a int32 (int) value");
                }
            }

            //===============================
            //  INT16 
            short Fint16 = 0;
            bool FInt16Tested = false;
            bool FCanbeInt16 = false;
            //-------------
            internal void TestInt16()
            {
                if (!FInt16Tested)
                {
                    try
                    {
                        Fint16 = Convert.ToInt16(FTextValue);
                        FCanbeInt16 = true;
                        FInt16Tested = true;
                    }
                    catch
                    {
                        FCanbeInt16 = false;
                        FInt16Tested = true;
                    }
                }
            }

            ///-------------------------------------------------------------------------------------------------
            /// <summary>   Determine if value can be int16 (short). </summary>
            /// <returns>   true if we can be int 16, false if not. </returns>
            ///-------------------------------------------------------------------------------------------------

            public bool CanBeInt16()
            {
                TestInt16();
                return FCanbeInt16;
            }

            ///-------------------------------------------------------------------------------------------------
            /// <summary>   Gets the value as short. </summary>
            /// <value> The value as short. </value>
            /// <exception cref="Exception">Throws Exception if not a int16 (short) int value</exception>
            /// <seealso cref="ValueLong"/>
            /// <seealso cref="ValueInt"/>
            ///-------------------------------------------------------------------------------------------------

            public short ValueShort
            {
                get
                {
                    TestInt16();
                    if (FCanbeInt16)
                        return Fint16;
                    else
                        throw new Exception("Not a int16 (short) value");
                }
            }
            //===============================
            //  INT64 
            long Fint64 = 0;
            bool FInt64Tested = false;
            bool FCanbeInt64 = false;
            //-------------
            internal void TestInt64()
            {
                if (!FInt64Tested)
                {
                    try
                    {
                        Fint64 = Convert.ToInt64(FTextValue);
                        FCanbeInt64 = true;
                        FInt64Tested = true;
                    }
                    catch
                    {
                        FCanbeInt64 = false;
                        FInt64Tested = true;
                    }
                }
            }

            ///-------------------------------------------------------------------------------------------------
            /// <summary>   Determine if we can be int64 (long). </summary>
            /// <returns>   true if we can be int64, false if not. </returns>
            ///-------------------------------------------------------------------------------------------------

            public bool CanBeInt64()
            {
                TestInt64();
                return FCanbeInt64;
            }

            ///-------------------------------------------------------------------------------------------------
            /// <summary>   Gets the value as long. </summary>
            /// <value> The long value. </value>
            /// <exception cref="Exception">Throws Exception if not a int64 (long) int value</exception>
            /// <seealso cref="ValueShort"/>
            /// <seealso cref="ValueInt"/>
            ///-------------------------------------------------------------------------------------------------

            public long ValueLong
            {
                get
                {
                    TestInt64();
                    if (FCanbeInt64)
                        return Fint64;
                    else
                        throw new Exception("Not a int64 (long) value");
                }
            }
            //===============================
            //  Double 
            double FDouble = 0;
            bool FDoubleTested = false;
            bool FCanbeDouble = false;

            internal void TestDouble()
            {
                if (!FDoubleTested)
                {
                    try
                    {
                        FDouble = Convert.ToDouble(FTextValue);
                        FCanbeDouble = true;
                        FDoubleTested = true;
                    }
                    catch
                    {
                        FCanbeDouble = false;
                        FDoubleTested = true;
                    }
                }
            }

            ///-------------------------------------------------------------------------------------------------
            /// <summary>   Determine if we field can be double. </summary>
            /// <returns>   true if we can be double, false if not. </returns>
            ///-------------------------------------------------------------------------------------------------

            public bool CanBeDouble()
            {
                TestDouble();
                return FCanbeDouble;
            }

            ///-------------------------------------------------------------------------------------------------
            /// <summary>   Gets the value as double. </summary>
            /// <value> The value as double. </value>
            /// <exception cref="Exception">Throws Exception if not a double value</exception>
            /// <seealso cref="ValueDecimal"/>
            /// <seealso cref="ValueFloat"/>
            ///-------------------------------------------------------------------------------------------------

            public double ValueDouble
            {
                get
                {
                    TestDouble();
                    if (FCanbeDouble)
                        return Fint;
                    else
                        throw new Exception("Not a double value");
                }
            }

            //===============================
            //  Decimal 
            decimal FDecimal = 0.0M;
            bool FDecimalTested = false;
            bool FCanbeDecimal = false;
            //-------------
            internal void TestDecimal()
            {
                if (!FDecimalTested)
                {
                    try
                    {
                        FDecimal = Convert.ToDecimal(FTextValue);
                        FCanbeDecimal = true;
                        FDecimalTested = true;
                    }
                    catch
                    {
                        FCanbeDecimal = false;
                        FDecimalTested = true;
                    }
                }
            }
            // -----------------

            ///-------------------------------------------------------------------------------------------------
            /// <summary>   Determine if value can be decimal. </summary>
            /// <returns>   true if we can be decimal, false if not. </returns>
            ///-------------------------------------------------------------------------------------------------

            public bool CanBeDecimal()
            {
                TestDecimal();
                return FCanbeDecimal;
            }

            ///-------------------------------------------------------------------------------------------------
            /// <summary>   Gets the value as decimal. </summary>
            /// <value> The value as decimal. </value>
            /// <exception cref="Exception">Throws Exception if not a decimal value</exception>
            /// <seealso cref="ValueDouble"/>
            /// <seealso cref="ValueFloat"/>
            ///-------------------------------------------------------------------------------------------------

            public decimal ValueDecimal
            {
                get
                {
                    TestDecimal();
                    if (FCanbeDecimal)
                        return FDecimal;
                    else
                        throw new Exception("Not a decimal value");
                }
            }
            //===============================
            //  FLOAT 
            float FFloat = 0.0f;
            bool FFloatTested = false;
            bool FCanbeFloat = false;
            //-------------
            internal void TestFloat()
            {
                if (!FFloatTested)
                {
                    try
                    {
                        FFloat = Convert.ToSingle(FTextValue);
                        FCanbeFloat = true;
                        FFloatTested = true;
                    }
                    catch
                    {
                        FCanbeFloat = false;
                        FFloatTested = true;
                    }
                }
            }
            ///-------------------------------------------------------------------------------------------------
            /// <summary>   Determine if value can be float. </summary>
            /// <returns>   true if we can be float, false if not. </returns>
            ///-------------------------------------------------------------------------------------------------

            public bool CanBeFloat()
            {
                TestFloat();
                return FCanbeFloat;
            }

            ///-------------------------------------------------------------------------------------------------
            /// <summary>   Gets the value as float. </summary>
            /// <value> The value as float. </value>
            ///-------------------------------------------------------------------------------------------------

            public float ValueFloat
            {
                get
                {
                    TestFloat();
                    if (FCanbeFloat)
                        return FFloat;
                    else
                        throw new Exception("Not a float (single) value");
                }
            }

            //===============================
            //  BOOL 
            bool FBool = false;
            bool FBoolTested = false;
            bool FCanbeBool = false;
            //-------------
            internal void TestBool()
            {
                if (!FBoolTested)
                {
                    // OK, check Bool with (False,true,F,T,Yes,No,Y,N)
                        string Text = FTextValue.ToUpper();
                        if ((Text=="FALSE")||(Text=="F")||(Text=="NO"))
                        {
                            FCanbeBool = true;
                            FBool = false;
                        }
                        else
                            if ((Text=="True")||(Text=="T")||(Text=="YES"))
                            {
                            FCanbeBool = true;
                            FBool = true;
                            }
                    FBoolTested = true;
                }
            }
            ///-------------------------------------------------------------------------------------------------
            /// <summary>   Determine if value can be bool. </summary>
            /// <returns>   true if we can be bool, false if not. </returns>
            ///-------------------------------------------------------------------------------------------------

            public bool CanBeBool()
            {
                TestBool();
                return FCanbeBool;
            }
            //------------------

            ///-------------------------------------------------------------------------------------------------
            /// <summary>   Gets value as bool. </summary>
            ///
            /// <value> value as bool<value>
            /// <exception cref="Exception">Throws Exception if not a bool value</exception>
            ///-------------------------------------------------------------------------------------------------

            public bool ValueBool
            {
                get
                {
                    TestBool();
                    if (FCanbeBool)
                        return FBool;
                    else
                        throw new Exception("Not a bool (boolean) value");
                }
            }

        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Values that represent different text file data formats. </summary>
        /// <seealso cref="FetchDataFromTextLine"/>
        ///-------------------------------------------------------------------------------------------------

        public enum DataFormat { SDF, FixedFields, SpaceDelimited, CommaDelimited,TabDelimited};

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Parses data from text line. </summary>
        /// <param name="Line">         The text line to parse </param>
        /// <param name="FormatType">   Type of data file format. </param>
        /// <returns>   A List of DynamicTextData, one for each text field found in the text line. </returns>
        ///-------------------------------------------------------------------------------------------------

        static public List<DynamicTextData> FetchDataFromTextLine(string Line, DataFormat FormatType)
        {
            List<DynamicTextData> Data = new List<DynamicTextData>();
            
            switch (FormatType)
            {
                case DataFormat.SDF:
                case DataFormat.FixedFields:
                    {

                        break;
                    }
                case DataFormat.SpaceDelimited:
                    {
                        int nextspace = -1;
                        string temp = "";
                        int index = 0;
                        while (index<Line.Length)
                        {
                            // Go to next field
                            while ((Line[index] == ' ') && (index < Line.Length))
                                index++;
                            if (index<Line.Length)
                            {
                                // Find end of this field
                                nextspace = Line.IndexOf(' ',index);
                                // check if lsat field
                                if (nextspace == -1)
                                    nextspace = Line.Length;
                                // grab field text
                                temp = Line.Substring(index, nextspace-index);
                                Data.Add(new DynamicTextData(temp));
                                index = nextspace;
                            }
                        }

                        break;
                    }
                case DataFormat.CommaDelimited:
                    {
                        int nextspace = -1;
                        string temp = "";
                        int index = 0;
                        while (index < Line.Length)
                        {
                                // Find end of this field
                                nextspace = Line.IndexOf(',',index);
                                // check if lsat field
                                if (nextspace == -1)
                                    nextspace = Line.Length;
                                // grab field text
                                temp = Line.Substring(index, nextspace - index).Trim();
                                Data.Add(new DynamicTextData(temp));
                                index = nextspace+1;
                        }
                        break;
                    }
            }
            return Data;
        }
        //===================================

        // All code from this point on is under development

        public static string buildSQLCreateCommandFromDataTable(OleDbConnection dbCon, string SourceTablename)
        {
            string temp = "";
            if (dbCon.State == ConnectionState.Open)
            {
                try
                {
                    // ok fetch some data from the Schema
                    SourceTablename = SourceTablename.Trim().ToUpper();
                    List<string> Schema_ColumnNames = new List<string>();
                    List<int> Schema_ColumnSizes = new List<int>();
                    List<int> Schame_ColumnDataType = new List<int>();
                    List<int> Schema_ColumnPrecision = new List<int>();

                    DataTable SourceColumns = dbCon.GetSchema("COLUMNS");

                    foreach (DataRow DR in SourceColumns.Rows)
                    {
                        string temptablename = DR["TABLE_NAME"].ToString().Trim().ToUpper();
                        if (SourceTablename == temptablename)
                        {
                            string valuestr = "";
                            // add column name
                            Schema_ColumnNames.Add(DR["COLUMN_NAME"].ToString().Trim().ToUpper());
                            // get max char length
                            valuestr = DR["CHARACTER_MAXIMUM_LENGTH"].ToString();
                            if (valuestr != "")
                            { Schema_ColumnSizes.Add(Convert.ToInt32(valuestr)); }
                            else
                            { Schema_ColumnSizes.Add(0); }
                            // get precision
                            valuestr = DR["NUMERIC_PRECISION"].ToString();
                            if (valuestr != "")
                            { Schema_ColumnPrecision.Add(Convert.ToInt32(valuestr)); }
                            else
                            { Schema_ColumnPrecision.Add(0); }
                            // get datatype
                            valuestr = DR["DATA_TYPE"].ToString();
                            if (valuestr != "")
                            { Schame_ColumnDataType.Add(Convert.ToInt32(valuestr)); }
                            else
                            { Schame_ColumnDataType.Add(0); }

                        }
                    } // foreach DR
                    // OK cycle through DataTable Fields and create
                }// try

                catch
                {
                }

            }// if dbcon
            return temp;
        }
        //
        public static string SQLDataDefine(Type DT, SQLServer Server, int Width)
        {
            string temp = "";
            if (DT == System.Type.GetType("System.String"))
            {
                temp = GetSQLType(siSQLCHAR, Server) + "(" + Width.ToString() + ")";
            }
            else
                if (DT == System.Type.GetType("System.Int16"))
                {
                    temp = GetSQLType(siSQLINT16, Server);
                }
                else
                    if (DT == System.Type.GetType("System.Int32"))
                    {
                        temp = GetSQLType(siSQLINT32, Server);
                    }
                    else
                        if (DT == System.Type.GetType("System.Int64"))
                        {
                            temp = GetSQLType(siSQLINT64, Server);
                        }
                        else
                            if (DT == System.Type.GetType("System.Decimal"))
                            {
                                temp = GetSQLType(siSQLFLOAT, Server);
                            }
                            else
                                if (DT == System.Type.GetType("System.Single"))
                                {
                                    temp = GetSQLType(siSQLSINGLE, Server);
                                }
                                else
                                    if (DT == System.Type.GetType("System.Double"))
                                    {
                                        temp = GetSQLType(siSQLDOUBLE, Server);
                                    }

                                    else
                                        if (DT == System.Type.GetType("System.DateTime"))
                                        {
                                            temp = GetSQLType(siSQLDATE, Server);
                                        }



            return temp;
        }
        //===============================================
        public struct ColumnInfo
        {
            string FName;
            System.Type FDataType;
            int FWidth;

            public ColumnInfo(DataColumn Column)
            {
                FName = Column.ColumnName;
                FDataType = Column.DataType;
                FWidth = Column.MaxLength;
            }

            public string ColumName
            { get { return FName; } }

            public System.Type DataType
            { get { return FDataType; } }
        }
        public static bool createTableFromTable(OleDbConnection DbConnnection, DataTable Source, string NewTablename, ref string errMessage, SQLServer Server)
        {

            bool result = false;
            if (NewTablename.Length > 0)
            {
                string tc = "CREATE TABLE ";
                OleDbCommand cmd = DbConnnection.CreateCommand();
                tc += '[' + NewTablename + ']' + " (";
                string ColList = "";
                int cnt = 0;
                foreach (DataColumn DC in Source.Columns)
                {
                    if (cnt > 0)
                        ColList += " , ";
                    ColList += SQLDataDefine(DC.DataType, Server, DC.MaxLength);

                }
                tc += ColList + "  )";
                cmd.CommandText = tc;
                try
                {
                    cmd.ExecuteNonQuery();
                    result = true;
                    cmd.Dispose();
                } // try
                catch (Exception ex)
                {
                    errMessage = "Error creating table " + NewTablename + ". Error:" + ex.Message;
                    cmd.Dispose();
                } // catch
            } // if newtable
            return result;
        }

    }  // end of dbtool

}
