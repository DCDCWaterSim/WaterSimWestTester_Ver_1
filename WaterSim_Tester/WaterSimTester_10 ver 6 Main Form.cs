using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

using WaterSimDCDC;
using WaterSimDCDC.Controls;
using WaterSimDCDC.Processes;
using WaterSimDCDC.Controls.Dotspatial;

using System.Diagnostics;
using WaterSimDCDC.Dialogs;
using System.Windows.Forms.DataVisualization.Charting;
using UniDB;


//using WaterSimDCDC_Graphics;


using System.Threading;




namespace WaterSim_Tester
{

    public partial class WaterSimTestForm : Form
    {

        WaterSimDCDC.WaterSimManager_DB WSim;

       // DataTable MapDataTable = null;
 
        bool WSDB_Open = false;

        HelpAboutForm HADialog;

        UniDB.SQLServer MyServer = UniDB.SQLServer.stAccess; //dbTool.SQLServer.stPostgreSQL;

        const string DataPath = "App_Data\\WaterSim_4_0\\";
        const string ShapeFilename = "Map_Data\\WaterSim 2012 Providers.shp";

        List<string> FTableNames = new List<string>();
        List<ToolStripComboBox> TablenameComboBoxes = new List<ToolStripComboBox>();

        public WaterSimTestForm()
        {

            InitializeComponent();
           // TablenameComboBoxes.Add(MapTableListComboBox);
            
            TablenameComboBoxes.Add(providerDashBoardChart1.TablenameBox);
            TablenameComboBoxes.Add(parameterDashboardChart1.TablenameBox);

            WaterSimManager.CreateModelOutputFiles = true;
            //WaterSimManager_DB.ServerType = MyServer;
           // WSim = new WaterSimManager_DB("WaterSim_Output\\", DataPath, null);
            WSim = new WaterSimManager_DB(SQLServer.stMySQL,"WaterSim_Output\\", DataPath, "watersim_mysql","localhots","RayQuay","ObjectCode92","");

            WSim.AddRegionToDB = true;
            providerDashBoardChart1.AssignParameterManager = WSim.ParamManager;
            parameterDashboardChart1.AssignParameterManager = WSim.ParamManager;
            mapDashboardControl1.ParameterManager = WSim.ParamManager;
            mapDashboardControl1.DataDirectory = "App_Data\\WaterSim_4_0";

            ShowMemory();

           WS_InputPanel.ParamManager = WSim.ParamManager;
        
           HADialog = new HelpAboutForm("5.0", WSim.APiVersion, WSim.ModelBuild);

           //WSim.ProcessRegistry.addAnnualFeedbackProcess(typeof(AlterGrowth));
           
           WSim.ProcessRegistry.addAnnualFeedbackProcess(typeof(WaterSimDCDC.Processes.AlterGrowthFeedbackProcess));

           //WSim.ProcessRegistry.addAnnualFeedbackProcess(typeof(AlterGPCD));
           WSim.ProcessRegistry.addAnnualFeedbackProcess(typeof(WaterSimDCDC.Processes.AlterGPCDFeedbackProcess));

          
            //AddProviderBaseShapeFile();

           processSeclectPanel.WaterSim = WSim;
        }  // Form Constructor
        //-------------------------------------------------------------
        public void FetchTablenames()
        {
            if (WSim.DbConnection != null)
            {
                bool test = true;
                string errString = "";
                FTableNames = dbTool.GetTableNames(WSim.DbConnection, ref test, ref errString);
                if (test)
                {
                    MessageBox.Show(" Error fetching table names " + errString, "Database Error");
                }
                else
                {
                    foreach (ToolStripComboBox CB in TablenameComboBoxes)
                    {
                        CB.Items.Clear();
                        foreach (string tn in FTableNames)
                        {
                            CB.Items.Add(tn);
                        }
                    }
                }
            }
        }
        ////--------------------------------------------------------------
        //internal void AddProviderBaseShapeFile()
        //{
        //    try
        //    {
        //        ProviderMap.AddLayer(DataPath + ShapeFilename);

        //        //Assign the mappolygon layer from the map
        //        MapPolygonLayer BaseLayer = default(MapPolygonLayer);
        //        BaseLayer = (MapPolygonLayer)ProviderMap.Layers[0];

        //        if (BaseLayer == null)
        //        {
        //            MessageBox.Show("The Base Layer of Provider Map is not a polygon layer.");
        //        }
        //        else
        //        {
        //            //Get the shapefile's attribute table to our datatable dt
        //            DataTable DT = BaseLayer.DataSet.DataTable;

        //            // Create a Scheme
        //            PolygonScheme BaseScheme = new PolygonScheme();
        //            //Set the ClassificationType for the PolygonScheme via EditorSettings
        //            BaseScheme.EditorSettings.ClassificationType = ClassificationType.UniqueValues;
        //            //Set the UniqueValue field name
        //            BaseScheme.EditorSettings.FieldName = "ADWR_NAME";
        //            // Create Catagories based on data
        //            BaseScheme.CreateCategories(DT);
        //            // Set the Symbology to this Scheme
        //            BaseLayer.Symbology = BaseScheme;
                   
                
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show("Error Loading Shape File:[ " + DataPath + ShapeFilename + "] :" + e.Message);
        //    }
        //}
        ////-------------------------------------------------------------
        // Will generate a stack overflow exception, used to judge size of stack
        int rcnt = 0;
        int mcnt = 0;
        public int StackCheck(int count)
        {
            rcnt++;
            try
            {
                if ((count % 1000) == 0)
                {
                    mcnt++;
                }
                if (count < 100000)
                    StackCheck(count + 1);
                return count + 1;
            }
            catch
            {
                // never gets here
                return count;
            }
        }    
       //-------------------------------------------------------------
        public string ReportTitle()
        {
            return ScenarioNameTextBox.Text + "   " + DateTime.Today.ToShortDateString() + "  " + DateTime.Now.ToShortTimeString() + "   WaterSim_DCDC Build " + WSim.ModelBuild;
        }
        //----------------------------------------------------------
        bool _InRunModel = false;
        internal void RunModel()
        {
            if (!_InRunModel)
            {
                _InRunModel = true;
                string ScName = ScenarioNameTextBox.Text;

                //string lineout = "";
                string ReportString = "";
                int ProviderSize = ProviderClass.NumberOfProviders;
                string[] AllStrings = new string[ProviderSize];
                
                // Resett the simulation
                WSim.Simulation_Initialize();
                
                // Fetch all the Input fields
                SimulationInputs SimInputs = WS_InputPanel.GetAllValues();
                SetAllModelValues(SimInputs);

                //SetStatusBar
                StatusLabel1.Text = "Running Simulation " + ScenarioNameTextBox.Text;
                StatusProgressBar.Maximum = WSim.Simulation_End_Year - WSim.Simulation_Start_Year;
                StatusProgressBar.Value = 1;
                StatusProgressBar.Visible = true;
              
                // Lock the model       
                WSim.LockSimulation();
                // Reset Memory Status
                ShowMemory();
                // Add a Title and Header
                OutputListBox.Items.Clear();
                OutputListBox.Items.Add(ReportTitle());
                //string[] header = new string[2];
                ReportHeader header = new ReportHeader();
                header = ReportClass.FullHeader(WSim, 20, false, true);
                OutputListBox.Items.Add(header[2]);
                OutputListBox.Items.Add(header[0]);
                OutputListBox.Items.Add(header[1]);


                if (OutputReportCheckBox.Checked)
                {
                    if (ContinuousCheckBox.Checked)
                        ReportString = ReportTextBox.Text;
                    else
                        ReportString = "";
                    ReportString += ReportTitle() + System.Environment.NewLine + ReportClass.FullHeader(WSim, 0, true, false)[0] + System.Environment.NewLine;
                }

                // OK run the model
                int runyear = 0;
                int cnt = 0;
                foreach (int year in WSim.simulationYears())
                {
                    runyear = WSim.Simulation_NextYear();
                    AllStrings = ReportClass.AnnualFullData(WSim,ScName, runyear, 20, false);
                    for (int i = 0; i < ProviderSize; i++)
                        OutputListBox.Items.Add(AllStrings[i]);
                    if (OutputReportCheckBox.Checked)
                    {
                        AllStrings = ReportClass.AnnualFullData(WSim, ScName, runyear, 20, true);
                        for (int i = 0; i < ProviderSize; i++)
                            ReportString += AllStrings[i];
                    }
                    StatusProgressBar.Value = cnt;
                    cnt++;
                }

                // Stop Model
                WSim.Simulation_Stop();

                StatusProgressBar.Visible = false;

                // output report
                if (OutputReportCheckBox.Checked)
                {
                    ReportTextBox.Text = ReportString + System.Environment.NewLine;
                }

                // Set output to default
                StatusLabel1.Text = "";

                ModelControlsTabControl.SelectedTab = OutputTabPage;
                OutputTabPage.Select();

                // Allow entry
                _InRunModel = false;
            }
        }

        //-------------------------------------------------------------------------------------------------------
        bool _OneYearNotStarted = true;
        bool _inRunOneYear = false;
        int _OneYearStart = 0;
        int _OneYearStop = 0;
        //-------------------------------------------------------------------------------------------------------
        private void RunOneYear()
        {
            // Block Rentry
            if (!_inRunOneYear)
            {
                _inRunOneYear = true;

                int ProviderSize = ProviderClass.NumberOfProviders;
                ReportHeader lineout = new ReportHeader();
                string ReportString = "";
                string[] AllStrings = new string[ProviderSize];
                string ScName = ScenarioNameTextBox.Text;
                int _runYear = 0;
                //----------------------------
                if (_OneYearNotStarted)
                {
                    // Resett the simulation
                    WSim.Simulation_Initialize();

                    OutputListBox.Items.Clear();
                    OutputListBox.Items.Add(ReportTitle());
                    lineout = ReportClass.FullHeader(WSim, 20, false,true);
                    OutputListBox.Items.Add(lineout[0]);
                    OutputListBox.Items.Add(lineout[1]);

                    SetAllModelValues(WS_InputPanel.GetAllValues());
                    _OneYearStart = WSim.Simulation_Start_Year;
                    _OneYearStop = WSim.Simulation_End_Year;
                    if (OutputReportCheckBox.Checked)
                    {
                        if (ContinuousCheckBox.Checked)
                            ReportString = ReportTextBox.Text;
                        else
                            ReportString = "";
                        ReportString += ReportTitle() + System.Environment.NewLine + ReportClass.FullHeader(WSim, 0, true, false)[0] + System.Environment.NewLine;
                        ReportTextBox.Text = ReportString;
                    }
                    _OneYearNotStarted = false;
                } // _oneYearNotSTarted true
               
                // Set New Year
                    // Clear this just to be safe
                    ReportString = "";
                    // Run One year of model
                    SetAllModelValues(WS_InputPanel.GetAllValues());
                    // Lock the model       

                    WSim.LockSimulation();

                    _runYear = WSim.Simulation_NextYear();
 
                    AllStrings = ReportClass.AnnualFullData(WSim,ScName,  _runYear, 20, false);
                    for (int i = 0; i < ProviderSize; i++)
                        OutputListBox.Items.Add(AllStrings[i]);
                    if (OutputReportCheckBox.Checked)
                    {
                        ReportString = ReportTextBox.Text;
                        AllStrings = ReportClass.AnnualFullData(WSim, ScName, _runYear, 20, true);
                        for (int i = 0; i < ProviderSize; i++)
                            ReportString += AllStrings[i];
                        ReportTextBox.Text = ReportString;
                    }
                    if (_runYear == _OneYearStop)
                    {
                        WSim.Simulation_Stop();
                        MessageBox.Show("Simulation has ended, next run will restart simulation!");
                        _OneYearNotStarted = true;
                    }
                
                _inRunOneYear = false;
            }
        }
        private void RunModelButton_Click(object sender, EventArgs e)
        {
            RunModel();
        }
        //----------------------------------------------------------
        public void SetAllModelValues(SimulationInputs si)
        {
            WSim.ParamManager.SetSimulationInputs(si);
        }
        //-------------------------------------------------------------------------------------------------------
        private void Refresh_Inputs()
        {
            WS_InputPanel.Refresh_Inputs();
        }
        //-------------------------------------------------------------------------------------------------------

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        internal long Last_Memory = 0;
        //-----------------------------------------------
        internal void ShowMemory()
        {
            Process MyProcess = System.Diagnostics.Process.GetCurrentProcess();

            long change = 0;
            long Process_Memory = MyProcess.PrivateMemorySize64;

            long GC_Memory = System.GC.GetTotalMemory(true);
            change = GC_Memory - Last_Memory;
            MemoryLabel.Text = "Memory - System: " + String.Format("{0:0,0}", Process_Memory) + " Managed: " + String.Format("{0:0,0}", GC_Memory) + "  Delta: " + String.Format("{0:0,0}", change) + "  ";
            Last_Memory = GC_Memory;
            Application.DoEvents();
        }


        //------------------------------------------------------------------
        private void CopyOutputButton_Click(object sender, EventArgs e)
        {
            string temp = "";
            int cnt = 0;
            cnt = OutputListBox.Items.Count;
            for (int i = 0; i < cnt; i++)
                temp = temp + OutputListBox.Items[i] + System.Environment.NewLine;
            Clipboard.SetData(DataFormats.Text, temp);
        }
        //-------------------------------------------------------------------
        private void forceNewModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        //----------------------------------------------------------
 
        //-------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------
        private void RunInputsMenuItem_Click(object sender, EventArgs e)
        {
            RunModel();
        }


        //----------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------
        private void CopyReportButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, ReportTextBox.Text);
        }

        //----------------------------------------------------------------------------------------
        private bool OpenDB()
        {
            switch (MyServer)
            {
                case SQLServer.stAccess:
                    {
                        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                WSim.Databasename = openFileDialog1.FileName;
                                WSDB_Open = true;
                                RunDBSimulationButton.Visible = true;
                                loadScenarioToolStripMenuItem.Enabled = true;
                                FetchTablenames();
                                providerDashBoardChart1.AssignDbConnection = WSim.DbConnection;
                                parameterDashboardChart1.AssignDbConnection = WSim.DbConnection;
                                mapDashboardControl1.DbConnection = WSim.DbConnection;
                            }
                            catch
                            {
                                WSDB_Open = false;
                                RunDBSimulationButton.Visible = false;

                                MessageBox.Show(" Unable  to open " + openFileDialog1.FileName);
                            }
                        }
                        break;
                    }
                case SQLServer.stPostgreSQL:
                    {
                        WaterSimDCDC.Dialogs.GetANameDialog GetNameDialog = new GetANameDialog();
                        List<string> Names = dbTool.GetDatabaseNames(MyServer,"LocalHost", "RayQuay", "object");
                        if (GetNameDialog.ShowDialog("Select Database", "", Names, false, false)==DialogResult.OK)
                        {
                            
                        }

                        break;
                    }
                case SQLServer.stMySQL:
                    {

                        break;
                    }
            }
            return WSDB_Open;
        }
        //--------------------------------------------------------------------------------------
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDB();
        }
        //--------------------------------------------------------------------------------------
        void LoadScenario()
        {
            bool iserror = false;
            string ErrMessage = "";
            if (WSDB_Open)
            {
                TablenameDialog tableDialog = new TablenameDialog();
                string tablename = "";
                DataTable DT = new DataTable();
                // get the table name
                if (tableDialog.ShowDialog(WSim.DbConnection, false, true) == System.Windows.Forms.DialogResult.OK)
                {
                    tablename = tableDialog.Tablename;
                    if (tablename != "")
                    {
                        try
                        {
                            DT = dbTool.LoadTable(WSim.DbConnection, "Select * from " + dbTool.BracketIt(WSim.DbConnection.SQLServerType,tablename)+";", ref iserror, ref ErrMessage); 
                            //OleDbDataAdapter TableAdapter = new OleDbDataAdapter("Select * from " + '[' + tablename + ']', WSim.DbConnection);
                            //TableAdapter.Fill(DT);
                            //TableAdapter.Dispose();
                            if (!iserror)
                            {
                                SimulationInputs SI = WSim.ParamManager.GetSimulationInputs();
                                if (WSim.LoadScenario_DB("", 0, DT, ref SI))
                                {
                                    if (WSim.ParamManager.SetSimulationInputs(SI))
                                    {
                                        WS_InputPanel.Refresh_Inputs();
                                    }

                                }
                            }
                            else
                            {
                                throw new Exception(ErrMessage);
                            }
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Whoops " + e.Message);
                        }
                    }
                }
            }
            else
            {

            }

        }
        //--------------------------------------------------------------------------------------
  

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (HADialog == null)
                HADialog = new HelpAboutForm("5.0",WSim.APiVersion, WSim.ModelBuild);
            HADialog.Mode = eHelpAboutMode.haAbout;
            HADialog.ShowDialog();
        }
        //--------------------------------------------------------------------------------------
 
        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (HADialog == null)
                HADialog = new HelpAboutForm("5.0",WSim.APiVersion, WSim.ModelBuild);
            HADialog.Mode = eHelpAboutMode.haHelp;
            HADialog.ShowDialog();
        }
        //--------------------------------------------------------------------------------------
 
        public void RunAllyearsDB()
        {
            if (WSDB_Open)
            {
                TablenameDialog tableDialog = new TablenameDialog();
                string runtablename = "";
                DataTable DT = new DataTable();
                // get the table name
                if (tableDialog.ShowDialog(WSim.DbConnection, false, false) == System.Windows.Forms.DialogResult.OK)
                {
                    runtablename = tableDialog.Tablename;
                    if (tableDialog.isNewTablename)
                        WSim.CreateNewDataTable(runtablename);

                }
                if (runtablename != "")
                {

                    StatusLabel1.Text = "Running DB Simulation";

                    // Ok fill the data table with all teh relvant fields
 
                    // initialize a db simulation, turn control over to WaterSim_DB
                    WSim.Simulation_Initialize(runtablename, ScenarioNameTextBox.Text);
                    // Fetch all the Input fields
                    SetAllModelValues(WS_InputPanel.GetAllValues());

                    // run each year of simulation db
                    foreach (int year in WSim.simulationYears())
                        WSim.Simulation_NextYear();
                    // stop the simulation (which adds all data to data table
                    WSim.Simulation_Stop();
                    // OK I now have control, update the database
                    UniDataAdapter NewRawTableAdapter = new UniDataAdapter("Select * from " + dbTool.BracketIt(WSim.DbConnection.SQLServerType,runtablename)+";", WSim.DbConnection);
                    NewRawTableAdapter.Fill(DT);
                    dbTableGridView.DataSource = DT;
                    StatusLabel1.Text = "Done";

                    FetchTablenames();

                }
            }
            else
            {
                MessageBox.Show("A Database must first be opened");
                OpenDB();
            }

        }
        //--------------------------------------------------------------
        
       //--------------------------------------------------------------
        void SaveReport()
        {
            if (ReportTextBox.Text == "")
            {
                MessageBox.Show("There is no report to save.");
            }
            else
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ReportTextBox.SaveFile(saveFileDialog1.FileName);

                }
            }
        }
        //---------------------------------------------------------------
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void allYearsDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunAllyearsDB();
        }

        private void createReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OutputReportCheckBox.Checked = !OutputReportCheckBox.Checked;
            createReportToolStripMenuItem.Checked = OutputReportCheckBox.Checked;
        }

        private void OutputReportCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            createReportToolStripMenuItem.Checked = OutputReportCheckBox.Checked;
        }

        private void continuousReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContinuousCheckBox.Checked = !ContinuousCheckBox.Checked;
            continuousReportToolStripMenuItem.Checked = ContinuousCheckBox.Checked;

        }

        private void ContinuousCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            continuousReportToolStripMenuItem.Checked = ContinuousCheckBox.Checked;

        }

        private void RunDBSimulationButton_Click(object sender, EventArgs e)
        {
            RunAllyearsDB();
        }

        private void RunOneYearButton_Click(object sender, EventArgs e)
        {
            RunOneYear();
        }


        private void SaveReportMenuItem_Click(object sender, EventArgs e)
        {
            SaveReport();
        }

        private void OpenDBButton_Click(object sender, EventArgs e)
        {
            OpenDB();
        }

        private void allYearsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunModel();
        }

        private void nextYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunOneYear();
        }

        private void SaveReportButton_Click(object sender, EventArgs e)
        {
            SaveReport();
        }



        private void loadScenarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadScenario();
        }
        //----------------------------------------------------------------------------------------

        
        public struct ProviderChartPointsByYear
        {
            int [] FDataValues;
            int [] FYearValues;
            int FProviderCode;
            //---------------------------------------
            public ProviderChartPointsByYear(int[] years, int[] data, int providercode)
            {
                FDataValues = data;
                FYearValues = years;
                FProviderCode = providercode;
            }
            //---------------------------------------
            public int ProviderCode
            {
                get { return FProviderCode; }
                set { FProviderCode = value; }
            }
            //---------------------------------------
            public int[] Years
            {
                get { return FYearValues; }
                set { FYearValues = value; }
            }
            //---------------------------------------
            public int[] Values
            {
                get { return FDataValues; }
                set { FDataValues = value; }
            }
            //-----------------------------------------
            public int MaxValue()
            {
                int Max = FDataValues[0];
                foreach (int value in FDataValues)
                {
                    if (value > Max) Max = value;
                }
                return Max;
            }
            //---------------------------------------
            public int MinValue()
            {
                int Min= FDataValues[0];
                foreach (int value in FDataValues)
                {
                    if (value < Min) Min =  value;
                }
                return Min;
            }
            //-----------------------------------------
            public int MaxYear()
            {
                int Max = FYearValues[0];
                foreach (int value in FYearValues)
                {
                    if (value > Max) Max = value;
                }
                return Max;
            }
            //---------------------------------------
            public int MinYear()
            {
                int Min = FYearValues[0];
                foreach (int value in FYearValues)
                {
                    if (value < Min) Min = value;
                }
                return Min;
            }
            //---------------------------------------
            public static int CompareForSort_UseMax(ProviderChartPointsByYear P1, ProviderChartPointsByYear P2)
            {
                int P1Max = P1.MaxValue();
                int P2Max = P2.MaxValue();
                if (P1Max==P2Max) return 0;
                else
                    if (P1Max<P2Max) return 1;
                    else
                    {
                        return -1;
                    }
            }
        }
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // Map Routines
        // +++++++++++++++++++++++++++++++++++++++++++++++++++++
        // 
        //public void ClearMapLayers()
        //{
        //    for (int i = ProviderMap.Layers.Count-1; i>0; i--)
        //    {
        //        IMapLayer item = ProviderMap.Layers[i];
        //        ProviderMap.Layers.Remove(item);
        //    }

        //}
        ////------------------------------------------
        //internal MapPolygonLayer AddProviderShapeFile(string Name)
        //{
        //    MapPolygonLayer MyLayer = null;
        //    try
        //    {
        //        MyLayer = (MapPolygonLayer) ProviderMap.AddLayer(DataPath + ShapeFilename);
        //        MyLayer.LegendText = Name;
        //        DataTable LayerDT = MyLayer.DataSet.DataTable;

        //        if (MyLayer == null)
        //        {
        //            MessageBox.Show("The Base ShapeFile is not a polygon layer.");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show("Error Loading Shape File:[ " + DataPath + ShapeFilename + "] :" + e.Message);
        //    }
        //    return MyLayer;
        //}

        //string MapTargetYear = "2010";
        ////-------------------------------------------------------
        //public MapPolygonLayer AddFieldLayer(string Fieldname)
        //{
        //    MapPolygonLayer MyLayer = null;
        //    if (MapDataTable!=null)
        //    if (MapDataTable.Columns.Contains(Fieldname))
        //    {
        //        try
        //    {
        //        DataColumn DC = MapDataTable.Columns[Fieldname];

        //        MyLayer = AddProviderShapeFile(Fieldname); //(MapPolygonLayer)ProviderMap.AddLayer(DataPath + ShapeFilename);
        //        if (MyLayer == null)
        //        {
        //            MessageBox.Show("The Base ShapeFile is not a polygon layer.");
        //        }
        //        else
        //        {
        //            // Get the years
        //            string yrfield = WaterSimManager_DB.rdbfSimYear;

        //           // MyLayer.DataSet.FillAttributes();

        //            DataTable LayerDT = MyLayer.DataSet.DataTable;
        //            DataColumn AddColumn = new DataColumn(DC.ColumnName, DC.DataType);
        //            LayerDT.Columns.Add(AddColumn);
                    
        //            foreach (DataRow DR in LayerDT.Rows)
        //            {
        //                Boolean found = false;
        //                string pfcode = DR["Provider"].ToString().Trim();  // Get the Provider Field code for this SHape File Record
        //                // find this code in Scenario DataTable
        //                foreach (DataRow ScnDR in MapDataTable.Rows)
        //                {
        //                    if (ScnDR[yrfield].ToString().Trim() == MapTargetYear)
        //                    {
        //                        string Scnpfcode = ScnDR[WaterSimManager_DB.rdbfProviderCode].ToString().Trim();  // "PRVDCODE"
        //                        if (pfcode == Scnpfcode)
        //                        {
        //                            DR[Fieldname] = ScnDR[Fieldname].ToString();
        //                            found = true;
        //                            break;
        //                        }
        //                        if (!found)
        //                        {
        //                            if (DC.DataType == System.Type.GetType("System.String"))
        //                            {
        //                                DR[Fieldname] = "";
        //                            }
        //                            else
        //                            {
        //                                DR[Fieldname] = 0;
        //                            }
        //                        }
        //                    } //= provider
        //                } // = target year
        //            }
        //            //MyLayer.DataSet.FillAttributes();

        //            if (DC.DataType == System.Type.GetType("System.String"))
        //            {
        //                PolygonScheme FldScheme = new PolygonScheme();
        //                FldScheme.EditorSettings.ClassificationType = ClassificationType.UniqueValues;
        //                ////Set the UniqueValue field name
        //                FldScheme.EditorSettings.FieldName = Fieldname;
        //                // Create Catagories based on data
        //                FldScheme.CreateCategories(LayerDT);
        //                MyLayer.Symbology = FldScheme;
        //            }
        //            else
        //            {

        //                PolygonScheme FldScheme = new PolygonScheme();
        //                FldScheme.EditorSettings.ClassificationType = ClassificationType.Quantities;
        //                FldScheme.EditorSettings.IntervalMethod = IntervalMethod.StandardDeviation;
        //                FldScheme.EditorSettings.NumBreaks = 8;
        //                FldScheme.EditorSettings.FieldName = Fieldname;
        //                FldScheme.AppearsInLegend = true;
        //                FldScheme.CreateCategories(LayerDT);
        //                PolygonCategory NullCat = new PolygonCategory(Color.WhiteSmoke, Color.DarkBlue, 1);
        //                NullCat.FilterExpression = "["+Fieldname+"] = NULL";
        //                NullCat.LegendText = "[" + Fieldname + "] = NULL";
        //                FldScheme.AddCategory(NullCat);
        //                MyLayer.Symbology = FldScheme;
                        
  
        //            }

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show("Error Loading Shape File:[ " + DataPath + ShapeFilename + "] :" + e.Message);
        //    }
        //}
        //    return MyLayer;
        //}
        ////-------------------------------------------------------
        //public void AddProviderShapeFileLayers()
        //{
        //    ProviderMap.Layers.Clear();
        //    AddProviderBaseShapeFile();
        //    MapPolygonLayer MPL = AddFieldLayer("PRVDCODE");

            
        //    PolygonScheme BaseScheme = new PolygonScheme();
        //    BaseScheme.EditorSettings.ClassificationType = ClassificationType.UniqueValues;
        //    ////Set the UniqueValue field name
        //    BaseScheme.EditorSettings.FieldName = "PRVDCODE";
        //    // Create Catagories based on data
        //    BaseScheme.CreateCategories(MPL.DataSet.DataTable);
        //    MPL.Symbology = BaseScheme;
        //}
        ////----------------------------------------

        //private void MapTableListComboBox_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string tablename = MapTableListComboBox.Text;
        //        if (tablename != "")
        //        {
        //            MapParameterListBox.Items.Clear();

        //            MapDataTable = new DataTable(); 
 
        //            ClearMapLayers();
        //            OleDbDataAdapter NewRawTableAdapter = new OleDbDataAdapter("Select * from " + '[' + tablename + ']', WSim.DbConnection);
        //            NewRawTableAdapter.Fill(MapDataTable);

        //            AddProviderShapeFileLayers();
        //            foreach (ModelParameterClass mpc in WSim.ParamManager.ProviderOutputs())
        //            {
        //                if (MapDataTable.Columns.Contains(mpc.Fieldname))
        //                {
        //                    MapParameterListBox.Items.Add(mpc.Fieldname);
        //                }
        //            }
        //            foreach (ModelParameterClass mpc in WSim.ParamManager.ProviderInputs())
        //            {
        //                if (MapDataTable.Columns.Contains(mpc.Fieldname))
        //                {
        //                    MapParameterListBox.Items.Add(mpc.Fieldname);
        //                }
        //            }
        //            List<string> temp = WaterSimManager_DB.YearsInTable(MapDataTable);
        //            YearComboBox.Items.Clear();
        //            foreach (string str in temp) { YearComboBox.Items.Add(str); }
        //            YearComboBox.SelectedIndex = YearComboBox.Items.Count - 1;
        //            MapTargetYear = YearComboBox.Items[YearComboBox.Items.Count - 1].ToString().Trim();
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}


        private void MapsPage_Enter(object sender, EventArgs e)
        {
            //List<string> temp;
            //GraphTableListComboBox.Items.Clear();
            //temp = GetTableNames(WSim.DbConnection);
            //foreach (string str in temp)
            //{
            //    MapTableListComboBox.Items.Add(str);
            //}
        }

        //private void MapParameterListBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string fldname = "";
        //    fldname = MapParameterListBox.Items[MapParameterListBox.SelectedIndex].ToString();
            
        //}

        //private void MapParameterListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        //{
        //    // get item index
        //    int index = e.Index;
        //    // get item text
        //    string Fieldname = MapParameterListBox.Items[index].ToString();
        //    // if check then delete from map
        //    if (MapParameterListBox.GetItemCheckState(index) == CheckState.Checked)
        //    {
        //        for (int i = 0; i < ProviderMap.Layers.Count; i++)
        //        {
        //            if (ProviderMap.Layers[i].LegendText == Fieldname)
        //            {
        //                ProviderMap.Layers.Remove(ProviderMap.Layers[i]);
        //                break;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        AddFieldLayer(Fieldname);
        //    }

        //}

 
     

   
        //==================================================

    }

}