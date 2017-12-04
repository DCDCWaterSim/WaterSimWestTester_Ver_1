using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;

using System.Text;
using System.Windows.Forms;


using UniDB;
using WaterSimDCDC;
using WaterSimDCDC.Controls;
using WaterSimDCDC.Dialogs;
//using WaterSimDCDC.Processes;
using WaterSimDCDC.Controls.Dotspatial;

using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;
using TimerTool;
using WaterSimDCDC.Generic;
using TreeViewInputs;
//using WaterSimDCDC_Graphics;


using System.Threading;




namespace WaterSim_Tester
{

    public partial class WaterSimTestForm : Form
    {

        WaterSimDCDC.WaterSimManager_DB WSim;

       // DataTable MapDataTable = null;
 
        bool WSDB_Open = false;

        bool FMonitorTime = true; 

        HelpAboutForm HADialog;

        TimeMonitor TMon;
        //UniDB.SQLServer MyServer = UniDB.SQLServer.stAccess; //UniDB.Tools.SQLServer.stPostgreSQL;

        //const string DataPath = @"App_Data\WaterSim_5_0\";
        string DataPath = "";
        //const string ShapeFilename = @"App_Data\Map Data\WaterSim 2012 Providers_no_np.shp";
        const string ShapeFilename = @"G:\DCDC\WaterSim_DCDC_50\VS Projects\WaterSim_API_11_0\API_Projects\WaterSim_Tester_12 PHX Extended\WaterSim_Tester\bin\Debug\App_Data\Map_Data\WaterSim 2012 Providers_no_np.shp";
//        const string ShapeFilename = @"G:\DCDC\WaterSim_DCDC_50\VS Projects\WaterSim_API_9_0\WaterSim_Tester_12 Extended\WaterSim_Tester\bin\Debug\App_Data\WaterSim_5_0\Map_Data\WaterSim 2012 Providers_no_np.shp";
            //"E:\\WaterSim_DCDC_50\\Data\\New Providers\\2013 New Provider Maps\\Water Sim Topological Correct\\WaterSim2012Providers_correcttopo.shp"  ;//"Map_Data\\WaterSim 2012 Providers.shp";
        //G:\DCDC\WaterSim_DCDC_50\VS Projects\WaterSim_API_9_0\WaterSim_Tester_12 Extended\WaterSim_Tester\bin\Debug\App_Data\WaterSim_5_0\Map_Data
        List<string> FTableNames = new List<string>();
        List<ToolStripComboBox> TablenameComboBoxes = new List<ToolStripComboBox>();
        //
        WaterSimCRFModel TheCRFModel = null;
        string ModelUnitName = "AZ_Central";

        //
        public WaterSimTestForm()
        {
            InitializeComponent();
           // TablenameComboBoxes.Add(MapTableListComboBox);
            // Set up Time
            TMon = new TimerTool.TimeMonitor();

            TablenameComboBoxes.Add(providerDashBoardChart2.TablenameBox);
            TablenameComboBoxes.Add(parameterDashboardChart2.TablenameBox);

            //WaterSimManager.CreateModelOutputFiles = true;
            //WaterSimManager_DB.ServerType = MyServer;
            try
            {
                DataPath = Application.StartupPath;
                WSim = new WaterSimManager_DB(DataPath, ""); //@"WaterSimOutputs\");

                WSim.IncludeAggregates = true;
                // WSim = new WaterSimManager_DB(SQLServer.stMySQL,"WaterSim_Output\\", DataPath, "watersim_mysql","localhost","RayQuay","ObjectCode92","");

                WSim.AddRegionToDB = true;
                providerDashBoardChart2.AssignParameterManager = WSim.ParamManager;
                parameterDashboardChart2.AssignParameterManager = WSim.ParamManager;
                mapDashboardControl2.ParameterManager = WSim.ParamManager;
                mapDashboardControl2.ShapeFilename = ShapeFilename; //.DataDirectory = "App_Data\\WaterSim_4_0";

                ShowMemory();
                toolStripVersion.Text = WSim.Model_Version + " API " + WSim.API_Version;//.APiVersion;
                WS_InputPanel.ParamManager = WSim.ParamManager;

                HADialog = new HelpAboutForm("5.0", WSim.API_Version, WSim.Model_Version);// WSim.APiVersion, WSim.ModelBuild);


                processSeclectPanel.WaterSim = WSim;

                parameterTreeViewTest.ParameterManager = WSim.ParamManager;
                // ----------------------------------------------------------
                UnitData TheData = null;
                TheData = WSim.WaterSimWestModel.ModelUnitData;
                foreach (string name in TheData.UnitNames)
                {
                    comboBoxSankeyGraph1.Items.Add(name);
                    comboBoxSankeyGraph2.Items.Add(name);
                }
                sankeyPanelControl1.PanelWaterSim = WSim;
                sankeyPanelControl2.PanelWaterSim = WSim;
                // -----------------------------------------------------------
                TreeNodes TN = new TreeNodes(WSim);
                // -----------------------------------------------------------
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }

           // added just for this test

            //AnnualFeedbackProcess TrackGW = new TrackAvailableGroundwater("Track Groundwter", WSim);
            //WSim.ProcessManager.AddProcess(TrackGW);
            //AnnualFeedbackProcess PersonalUse = new Personal_GPCD_WebFeedbackProcess("Track Personal", WSim);
            //WSim.ProcessManager.AddProcess(PersonalUse);

            //WSim.ParamManager.Extended.LoadExternalDocumentation(WSim.DataDirectory);
            //parameterTreeViewTest.ParameterManager = WSim.ParamManager;

            // create annual feedback process
            //TrackAvailableGroundwater TAGW = new TrackAvailableGroundwater( WSim);
            //// add it to the process que
            //WSim.ProcessManager.AddProcess(TAGW);
            //WSim.Simulation_Initialize();
            //WSim.Simulation_AllYears();
            //// setup variables
            //int years = int.MinValue;  // or whatever your default is I often use  int.MinValue as a marker for missing rather than set it to 0;
            //ModelParameterClass YearsNotAssured;
            //try
            //{
            //    // fetch model parameter
            //    YearsNotAssured = WSim.ParamManager.Model_Parameter(eModelParam.epYearsNotAssured);
            //}
            //catch
            //{
            //    // should only get this if you have not started the TrackAvailableGroundwater process
            //    YearsNotAssured = null;
            //}
            //// add WS.NextYear() loop
            //// run a year of the model

            //if (YearsNotAssured != null)
            //{
            //    years = YearsNotAssured.ProviderProperty.RegionalValue(eProvider.Regional);
            //    // there are other regions  eProvider.OffProject eProvider.OnProject
                    
            //}
            //WSim.Simulation_Stop();
             //end loop

            //ModelParameterClass MP = WSim.ParamManager.Model_Parameter(38);
            //string fldstr = MP.Fieldname;
            //MP = WSim.ParamManager.Model_Parameter(fldstr);
            //string label = MP.Label;

            //foreach (ModelParameterClass TempMP in WSim.ParamManager.AllModelParameters())
            //{
            //    rangeChecktype RCType = TempMP.RangeCheckType;
            //    if (RCType == rangeChecktype.rctCheckRangeSpecial)
            //    {
            //        if (TempMP.ParamType == modelParamtype.mptInputProvider)
            //        {
            //        string temp = "INFO";
            //        TempMP.SpecialProviderCheck(int.MinValue, 0, ref temp, TempMP);
            //        }
            //        else
            //            if (TempMP.ParamType == modelParamtype.mptInputBase)
            //            {
            //                string temp = "INFO";
            //                TempMP.SpecialBaseCheck(int.MinValue, ref temp, TempMP);
            //            }
                    

            //    }
            //}
        }  // Form Constructor

        // ----------------------------------------------------------------

        public void ReportTime()
        {
            if (FMonitorTime)
            {
                toolStripStatusLabelTime.Text = "TimeSpan: "+TMon.TimeSec.ToString("#.####")+ " secs ";
            }
        }
        //-------------------------------------------------------------
        public void FetchTablenames()
        {
            if (WSim.DbConnection != null)
            {
                bool test = true;
                string errString = "";
                FTableNames = WSim.DbConnection.GetTableNames(ref test, ref errString);
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
            return ScenarioNameTextBox.Text + "   " + DateTime.Today.ToShortDateString() + "  " + DateTime.Now.ToShortTimeString() + "   WaterSim_DCDC Build " + WSim.Model_Version;
        }
        //----------------------------------------------------------
        bool _InRunModel = false;
        internal void RunModel()
        {
            if (!_InRunModel)
            {
                _InRunModel = true;
                string ScName = ScenarioNameTextBox.Text;

                // reset Timer
                TMon.Reset();

                //string lineout = "";
                string ReportString = "";
                int ProviderSize = ProviderClass.NumberOfProviders;
                if (WSim.IncludeAggregates)
                    ProviderSize = ProviderClass.NumberOfProviders + ProviderClass.NumberOfAggregates;
                string[] AllStrings = new string[ProviderSize];
                
                // Resett the simulation
                WSim.Simulation_Initialize();
                
                // Fetch all the Input fields
                SimulationInputs SimInputs = WS_InputPanel.GetAllValues();
                SetAllModelValues(SimInputs);

                //SetStatusBar
                StatusLabel1.Text = "Running Simulation " + ScenarioNameTextBox.Text;
                Application.DoEvents();

                //// Lock the model       
                //WSim.LockSimulation();
                //// Reset Memory Status
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

                // if monitorig time start timer
                if (FMonitorTime) { TMon.Start(); }

                WSim.Simulation_AllYears();

                // if monitorig time stop timer
                if (FMonitorTime) { TMon.Stop(); }

                // Stop Model
                WSim.Simulation_Stop();

                StatusLabel1.Text = "Building Report " + ScenarioNameTextBox.Text;
                Application.DoEvents();
                StatusProgressBar.Maximum = (WSim.Simulation_End_Year - WSim.Simulation_Start_Year)+1;
                StatusProgressBar.Value = 1;
                StatusProgressBar.Visible = true;
                cnt = 0;
                foreach (int year in WSim.simulationYears())
                {
                    StatusProgressBar.Value = cnt;
                    cnt++;
                    Application.DoEvents();

                    AllStrings = ReportClass.AnnualFullData(WSim.SimulationRunResults, ScName, year, 20, false);
                    for (int i = 0; i < ProviderSize; i++)
                        OutputListBox.Items.Add(AllStrings[i]);
                    if (OutputReportCheckBox.Checked)
                    {
                        AllStrings = ReportClass.AnnualFullData(WSim, ScName, runyear, 20, true);
                        for (int i = 0; i < ProviderSize; i++)
                            ReportString += AllStrings[i];
                    }

                }


                // output report
                if (OutputReportCheckBox.Checked)
                {
                    ReportTextBox.Text = ReportString + System.Environment.NewLine;
                }

                StatusProgressBar.Visible = false;

                // Set output to default
                StatusLabel1.Text = "";

                ModelControlsTabControl.SelectedTab = OutputTabPage;
                OutputTabPage.Select();
                if (FMonitorTime) ReportTime();
                // Allow entry
                _InRunModel = false;
                sankeyPanelControl1.PanelWaterSim = WSim;

               // sankeyPanelControl1.resetPanelGraph();
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

                // reset the timer
                TMon.Reset();

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
                    // if monitorig time start timer
                    if (FMonitorTime) { TMon.Start(); }
          
                    _runYear = WSim.Simulation_NextYear();
                    // if monitorig time stop timer
                    if (FMonitorTime) { TMon.Stop(); }
 
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
                    if (FMonitorTime) ReportTime();

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
            SqlServerDialog SSD = new SqlServerDialog();
            if (SSD.ShowDialog() == DialogResult.OK)
            {
                SQLServer aServerType = SSD.ServerType;
                string aLocation = SSD.ServerLocation;
                string aDatabasename = SSD.Datbasename;
                string aPort = SSD.Port;
                string aUser = SSD.User;
                string aPassword = SSD.Password;
                string aOption = SSD.Options;

                UniDbConnection TempDbCon = new UniDbConnection(aServerType, aLocation, aDatabasename, aUser, aPassword, aOption);
                TempDbCon.Open();
                WSim.DbConnection = TempDbCon;
                FetchTablenames();
                providerDashBoardChart2.AssignDbConnection = WSim.DbConnection;
                parameterDashboardChart2.AssignDbConnection = WSim.DbConnection;
                mapDashboardControl2.DbConnection = WSim.DbConnection;
                WSDB_Open = true;
                RunDBSimulationButton.Visible = true;
                loadScenarioToolStripMenuItem.Enabled = true;

            }
            //switch (MyServer)
            //{
            //    case SQLServer.stAccess:
            //        {
            //            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //            {
            //                try
            //                {
            //                    WSim.Databasename = openFileDialog1.FileName;
            //                    WSDB_Open = true;
            //                    RunDBSimulationButton.Visible = true;
            //                    loadScenarioToolStripMenuItem.Enabled = true;
            //                    FetchTablenames();
            //                    providerDashBoardChart2.AssignDbConnection = WSim.DbConnection;
            //                    parameterDashboardChart2.AssignDbConnection = WSim.DbConnection;
            //                    mapDashboardControl1.DbConnection = WSim.DbConnection;
            //                }
            //                catch
            //                {
            //                    WSDB_Open = false;
            //                    RunDBSimulationButton.Visible = false;

            //                    MessageBox.Show(" Unable  to open " + openFileDialog1.FileName);
            //                }
            //            }
            //            break;
            //        }
            //    case SQLServer.stPostgreSQL:
            //        {
            //            WaterSimDCDC.Dialogs.GetANameDialog GetNameDialog = new GetANameDialog();
            //            List<string> Names = UniDB.Tools.GetDatabaseNames(MyServer,"LocalHost", "RayQuay", "object");
            //            if (GetNameDialog.ShowDialog("Select Database", "", Names, false, false)==DialogResult.OK)
            //            {
                            
            //            }

            //            break;
            //        }
            //    case SQLServer.stMySQL:
            //        {

            //            break;
            //        }
            //}
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
                            DT = UniDB.Tools.LoadTable(WSim.DbConnection, "Select * from " + UniDB.Tools.BracketIt(WSim.DbConnection.SQLServerType,tablename)+";", ref iserror, ref ErrMessage); 
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
                HADialog = new HelpAboutForm("5.0", WSim.API_Version, WSim.Model_Version);// WSim.APiVersion, WSim.ModelBuild);
            HADialog.Mode = eHelpAboutMode.haAbout;
            HADialog.ShowDialog();
        }
        //--------------------------------------------------------------------------------------
 
        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (HADialog == null)
                HADialog = new HelpAboutForm("5.0", WSim.API_Version, WSim.Model_Version);// WSim.APiVersion, WSim.ModelBuild);
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
                    DateTime STart = DateTime.Now;
                    StatusLabel1.Text = "Running DB Simulation";
                    Application.DoEvents();

                    // Ok fill the data table with all teh relvant fields
 
                    // initialize a db simulation, turn control over to WaterSim_DB
                    WSim.Simulation_Initialize(runtablename, ScenarioNameTextBox.Text);
                    // Fetch all the Input fields
                    SetAllModelValues(WS_InputPanel.GetAllValues());

                    // if monitoring time, start
                    if (FMonitorTime) TMon.Start();

                    // run each year of simulation db
                    WSim.Simulation_AllYears();

                    // if monitoring time, stop
                    if (FMonitorTime) TMon.Stop();

                    //foreach (int year in WSim.simulationYears())
                    //    WSim.Simulation_NextYear();
                    // stop the simulation (which adds all data to data table
                    WSim.Simulation_Stop();
                    DateTime STop = DateTime.Now;
                    TimeSpan TimeLength = STop - STart;
                    // OK I now have control, update the database
                    UniDataAdapter NewRawTableAdapter = new UniDataAdapter("Select * from " + UniDB.Tools.BracketIt(WSim.DbConnection.SQLServerType,runtablename)+";", WSim.DbConnection);
                    NewRawTableAdapter.Fill(DT);
                    dbTableGridView.DataSource = DT;

                    StatusLabel1.Text = "Done  "+TimeLength.ToString(@"mm\:ss\.ff");
                    ReportTime();
                    Application.DoEvents();

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

        public void allYearsDbToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            //parameterTreeViewTest.Clear();
            parameterTreeViewTest.AllowGroupCheck = false;
            parameterTreeViewTest.UseCheckBoxes = true;

            //ParmTreeNode PTN = parameterTreeView1.Selected();
            //if (PTN != null)
            //{
            //    if (PTN.isParamItemNode)
            //    {
            //        label1.Text = PTN.ParmItem.Label + " Parameter ";
            //        //System.Drawing.Font DisableFont = new System.Drawing.Font("Arial", 10);
            //        PTN.ForeColor = Color.LightGray;
            //    }
            //    else
            //    {
            //        label1.Text = PTN.ParmGroup.Name + " Group ";
            //    }
            //}
        }

        private void parameterTreeViewTest_ParmItemCheck(object sender, ParmTreeNode Node)
        {
            WaterSimDCDC.Documentation.Extended_Parameter_Documentation TestDoc = WSim.ParamManager.Extended;
            int pId = Node.ParmItem.ModelParam;
            string MPI = TestDoc.Unit(pId);
            label1.Text = Node.Name;
            propertyViewFieldname.AsString = Node.ParmItem.Fieldname;
            PropertyViewWebLabel.AsString = Node.ParmItem.WebLabel;
            propertyViewUnit.AsString = Node.ParmItem.Units;
            PropertyViewDesc.AsString = Node.ParmItem.Description;
            propertyViewLongUnits.AsString = Node.ParmItem.UnitsLong;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            FMonitorTime = checkBoxMonitorTime.Checked;
        }

        long TotalTicks = 0;

        
        private void TimeMonitor_Tick(object sender, EventArgs e)
        {
            TotalTicks++;
        }

        private void parameterTreeViewTest_ParmItemSelect(object sender, ParmTreeNode Node)
        {
            if(Node.isParamItemNode)
            {
                parameterTreeViewTest_ParmItemCheck(sender, Node);
                 }
        }

        private void propertyViewLongUnits_Load(object sender, EventArgs e)
        {

        }
        // ===================================================================================
        // David sankey stuff
        // 09.20.17
        private void comboBoxSankeyGraph1_SelectedIndexChanged(object sender, EventArgs e)
        {
              string aunitname = comboBoxSankeyGraph1.SelectedItem.ToString();
            sankeyPanelControl1.PanelWaterSimName = aunitname;
        }
        private void comboBoxSankeyGraph2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string aunitname = comboBoxSankeyGraph2.SelectedItem.ToString();
            sankeyPanelControl2.PanelWaterSimName = aunitname;
        }

        public WaterSimManager_DB PanelWaterSim
        {
            get { return WSim; }
            set
            {
                if (value != null)
                {
                    WSim = value;
                    UnitData TheData = null;
                    TheData = WSim.WaterSimWestModel.ModelUnitData;
                    foreach (string name in TheData.UnitNames)
                    {
                        comboBoxSankeyGraph1.Items.Add(name);
                        comboBoxSankeyGraph2.Items.Add(name);
                    }
                    ResetSanKeyGraphUnit(ModelUnitName);
                }
            }
        }
        private void ResetSanKeyGraphUnit(String aUnitName)
        {
            if (WSim != null) TheCRFModel = WSim.WaterSimWestModel.GetUnitModel(aUnitName);
            if (TheCRFModel != null)
            {
                ModelUnitName = aUnitName;
            }
        }
        //========================================================================================
        // 09.20.17
        // Tree View Code for Inputs


        // =======================================================================================
    }

}