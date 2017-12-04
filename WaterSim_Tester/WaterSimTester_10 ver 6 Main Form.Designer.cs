namespace WaterSim_Tester
{
    partial class WaterSimTestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaterSimTestForm));
            this.ModelControlsTabControl = new System.Windows.Forms.TabControl();
            this.InputPage = new System.Windows.Forms.TabPage();
            this.WS_InputPanel = new WaterSimDCDC.Controls.WaterSim_InputPanel();
            this.OutputTabPage = new System.Windows.Forms.TabPage();
            this.GraphsTab = new System.Windows.Forms.TabControl();
            this.OutputPage = new System.Windows.Forms.TabPage();
            this.CopyOutputButton = new System.Windows.Forms.Button();
            this.OutputListBox = new System.Windows.Forms.ListBox();
            this.ReportPage = new System.Windows.Forms.TabPage();
            this.CopyReportButton = new System.Windows.Forms.Button();
            this.ReportTextBox = new System.Windows.Forms.RichTextBox();
            this.DBPage = new System.Windows.Forms.TabPage();
            this.dbTableGridView = new System.Windows.Forms.DataGridView();
            this.MapsPage = new System.Windows.Forms.TabPage();
           
            this.mapDashboardControl1 = new WaterSimDCDC.Controls.Dotspatial.MapDashboardControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.AllGraphsTabControl = new System.Windows.Forms.TabControl();
            this.ByParametersChart = new System.Windows.Forms.TabPage();
            this.providerDashBoardChart1 = new WaterSimDCDC.Controls.ProviderDashBoardChart();
            this.ByProviderTabPage = new System.Windows.Forms.TabPage();
            this.parameterDashboardChart1 = new WaterSimDCDC.Controls.ParameterDashboardChart();
            this.OptionsPage = new System.Windows.Forms.TabPage();
            this.ContinuousCheckBox = new System.Windows.Forms.CheckBox();
            this.ScenarioNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OutputReportCheckBox = new System.Windows.Forms.CheckBox();
            this.ProcessTabPage = new System.Windows.Forms.TabPage();
            this.ProcessTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.processSeclectPanel = new WaterSimDCDC.Controls.ProcessSeclectControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadScenarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveReportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.allYearsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextYearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allYearsDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.continuousReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MemoryLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.RunModelButton = new System.Windows.Forms.ToolStripButton();
            this.RunOneYearButton = new System.Windows.Forms.ToolStripButton();
            this.RunDBSimulationButton = new System.Windows.Forms.ToolStripButton();
            this.OpenDBButton = new System.Windows.Forms.ToolStripButton();
            this.SaveReportButton = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ModelControlsTabControl.SuspendLayout();
            this.InputPage.SuspendLayout();
            this.OutputTabPage.SuspendLayout();
            this.GraphsTab.SuspendLayout();
            this.OutputPage.SuspendLayout();
            this.ReportPage.SuspendLayout();
            this.DBPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbTableGridView)).BeginInit();
            this.MapsPage.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.AllGraphsTabControl.SuspendLayout();
            this.ByParametersChart.SuspendLayout();
            this.ByProviderTabPage.SuspendLayout();
            this.OptionsPage.SuspendLayout();
            this.ProcessTabPage.SuspendLayout();
            this.ProcessTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ModelControlsTabControl
            // 
            this.ModelControlsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ModelControlsTabControl.Controls.Add(this.InputPage);
            this.ModelControlsTabControl.Controls.Add(this.OutputTabPage);
            this.ModelControlsTabControl.Controls.Add(this.OptionsPage);
            this.ModelControlsTabControl.Controls.Add(this.ProcessTabPage);
            this.ModelControlsTabControl.Location = new System.Drawing.Point(3, 66);
            this.ModelControlsTabControl.Name = "ModelControlsTabControl";
            this.ModelControlsTabControl.SelectedIndex = 0;
            this.ModelControlsTabControl.Size = new System.Drawing.Size(989, 519);
            this.ModelControlsTabControl.TabIndex = 0;
            // 
            // InputPage
            // 
            this.InputPage.Controls.Add(this.WS_InputPanel);
            this.InputPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputPage.Location = new System.Drawing.Point(4, 22);
            this.InputPage.Name = "InputPage";
            this.InputPage.Padding = new System.Windows.Forms.Padding(3);
            this.InputPage.Size = new System.Drawing.Size(981, 493);
            this.InputPage.TabIndex = 0;
            this.InputPage.Text = "Parameter Input";
            this.InputPage.UseVisualStyleBackColor = true;
            // 
            // WS_InputPanel
            // 
            this.WS_InputPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WS_InputPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.WS_InputPanel.GetLocal = true;
            this.WS_InputPanel.Location = new System.Drawing.Point(3, 3);
            this.WS_InputPanel.Name = "WS_InputPanel";
            this.WS_InputPanel.ParamManager = null;
            this.WS_InputPanel.Size = new System.Drawing.Size(975, 487);
            this.WS_InputPanel.StoreLocal = true;
            this.WS_InputPanel.TabIndex = 0;
            // 
            // OutputTabPage
            // 
            this.OutputTabPage.Controls.Add(this.GraphsTab);
            this.OutputTabPage.Location = new System.Drawing.Point(4, 22);
            this.OutputTabPage.Name = "OutputTabPage";
            this.OutputTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.OutputTabPage.Size = new System.Drawing.Size(981, 493);
            this.OutputTabPage.TabIndex = 1;
            this.OutputTabPage.Text = "Output";
            this.OutputTabPage.UseVisualStyleBackColor = true;
            // 
            // GraphsTab
            // 
            this.GraphsTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GraphsTab.Controls.Add(this.OutputPage);
            this.GraphsTab.Controls.Add(this.ReportPage);
            this.GraphsTab.Controls.Add(this.DBPage);
            this.GraphsTab.Controls.Add(this.MapsPage);
            this.GraphsTab.Controls.Add(this.tabPage3);
            this.GraphsTab.Location = new System.Drawing.Point(6, 6);
            this.GraphsTab.Name = "GraphsTab";
            this.GraphsTab.SelectedIndex = 0;
            this.GraphsTab.Size = new System.Drawing.Size(971, 483);
            this.GraphsTab.TabIndex = 2;
            // 
            // OutputPage
            // 
            this.OutputPage.Controls.Add(this.CopyOutputButton);
            this.OutputPage.Controls.Add(this.OutputListBox);
            this.OutputPage.Location = new System.Drawing.Point(4, 22);
            this.OutputPage.Name = "OutputPage";
            this.OutputPage.Padding = new System.Windows.Forms.Padding(3);
            this.OutputPage.Size = new System.Drawing.Size(963, 457);
            this.OutputPage.TabIndex = 0;
            this.OutputPage.Text = "Basic";
            this.OutputPage.UseVisualStyleBackColor = true;
            // 
            // CopyOutputButton
            // 
            this.CopyOutputButton.Location = new System.Drawing.Point(6, 6);
            this.CopyOutputButton.Name = "CopyOutputButton";
            this.CopyOutputButton.Size = new System.Drawing.Size(75, 23);
            this.CopyOutputButton.TabIndex = 2;
            this.CopyOutputButton.Text = "Copy";
            this.CopyOutputButton.UseVisualStyleBackColor = true;
            // 
            // OutputListBox
            // 
            this.OutputListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputListBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputListBox.FormattingEnabled = true;
            this.OutputListBox.HorizontalScrollbar = true;
            this.OutputListBox.ItemHeight = 16;
            this.OutputListBox.Location = new System.Drawing.Point(6, 31);
            this.OutputListBox.Name = "OutputListBox";
            this.OutputListBox.Size = new System.Drawing.Size(907, 404);
            this.OutputListBox.TabIndex = 1;
            // 
            // ReportPage
            // 
            this.ReportPage.Controls.Add(this.CopyReportButton);
            this.ReportPage.Controls.Add(this.ReportTextBox);
            this.ReportPage.Location = new System.Drawing.Point(4, 22);
            this.ReportPage.Name = "ReportPage";
            this.ReportPage.Padding = new System.Windows.Forms.Padding(3);
            this.ReportPage.Size = new System.Drawing.Size(963, 457);
            this.ReportPage.TabIndex = 1;
            this.ReportPage.Text = "Report";
            this.ReportPage.UseVisualStyleBackColor = true;
            // 
            // CopyReportButton
            // 
            this.CopyReportButton.Location = new System.Drawing.Point(6, 6);
            this.CopyReportButton.Name = "CopyReportButton";
            this.CopyReportButton.Size = new System.Drawing.Size(75, 23);
            this.CopyReportButton.TabIndex = 2;
            this.CopyReportButton.Text = "Copy Report";
            this.CopyReportButton.UseVisualStyleBackColor = true;
            this.CopyReportButton.Click += new System.EventHandler(this.CopyReportButton_Click);
            // 
            // ReportTextBox
            // 
            this.ReportTextBox.AcceptsTab = true;
            this.ReportTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReportTextBox.DetectUrls = false;
            this.ReportTextBox.Location = new System.Drawing.Point(9, 31);
            this.ReportTextBox.Name = "ReportTextBox";
            this.ReportTextBox.Size = new System.Drawing.Size(907, 416);
            this.ReportTextBox.TabIndex = 1;
            this.ReportTextBox.Text = "";
            this.ReportTextBox.WordWrap = false;
            // 
            // DBPage
            // 
            this.DBPage.Controls.Add(this.dbTableGridView);
            this.DBPage.Location = new System.Drawing.Point(4, 22);
            this.DBPage.Name = "DBPage";
            this.DBPage.Padding = new System.Windows.Forms.Padding(3);
            this.DBPage.Size = new System.Drawing.Size(963, 457);
            this.DBPage.TabIndex = 2;
            this.DBPage.Text = "Db";
            this.DBPage.UseVisualStyleBackColor = true;
            // 
            // dbTableGridView
            // 
            this.dbTableGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbTableGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbTableGridView.Location = new System.Drawing.Point(3, 3);
            this.dbTableGridView.Name = "dbTableGridView";
            this.dbTableGridView.Size = new System.Drawing.Size(914, 444);
            this.dbTableGridView.TabIndex = 1;
            // 
            // MapsPage
            // 
            this.MapsPage.Controls.Add(this.mapDashboardControl1);
            this.MapsPage.Location = new System.Drawing.Point(4, 22);
            this.MapsPage.Name = "MapsPage";
            this.MapsPage.Padding = new System.Windows.Forms.Padding(3);
            this.MapsPage.Size = new System.Drawing.Size(963, 457);
            this.MapsPage.TabIndex = 4;
            this.MapsPage.Text = "Maps";
            this.MapsPage.UseVisualStyleBackColor = true;
            this.MapsPage.Enter += new System.EventHandler(this.MapsPage_Enter);
            // 
            // mapDashboardControl1
            // 
            this.mapDashboardControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mapDashboardControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mapDashboardControl1.CurrentTablename = "";
            this.mapDashboardControl1.DataDirectory = "";
            this.mapDashboardControl1.DbConnection = null;
            this.mapDashboardControl1.Location = new System.Drawing.Point(6, 6);
            this.mapDashboardControl1.Name = "mapDashboardControl1";
            this.mapDashboardControl1.ParameterManager = null;
            this.mapDashboardControl1.SelectedScenario = "";
            this.mapDashboardControl1.ShapeFilename = "Map_Data\\WaterSim 2012 Providers_no_np.shp";
            this.mapDashboardControl1.ShowTablenameToolbar = true;
            this.mapDashboardControl1.Size = new System.Drawing.Size(951, 445);
            this.mapDashboardControl1.TabIndex = 0;
            this.mapDashboardControl1.TableNames = ((System.Collections.Generic.List<string>)(resources.GetObject("mapDashboardControl1.TableNames")));
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.AllGraphsTabControl);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(963, 457);
            this.tabPage3.TabIndex = 5;
            this.tabPage3.Text = "Dash Board";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // AllGraphsTabControl
            // 
            this.AllGraphsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AllGraphsTabControl.Controls.Add(this.ByParametersChart);
            this.AllGraphsTabControl.Controls.Add(this.ByProviderTabPage);
            this.AllGraphsTabControl.Location = new System.Drawing.Point(3, 6);
            this.AllGraphsTabControl.Name = "AllGraphsTabControl";
            this.AllGraphsTabControl.SelectedIndex = 0;
            this.AllGraphsTabControl.Size = new System.Drawing.Size(960, 453);
            this.AllGraphsTabControl.TabIndex = 0;
            // 
            // ByParametersChart
            // 
            this.ByParametersChart.Controls.Add(this.providerDashBoardChart1);
            this.ByParametersChart.Location = new System.Drawing.Point(4, 22);
            this.ByParametersChart.Name = "ByParametersChart";
            this.ByParametersChart.Padding = new System.Windows.Forms.Padding(3);
            this.ByParametersChart.Size = new System.Drawing.Size(952, 427);
            this.ByParametersChart.TabIndex = 1;
            this.ByParametersChart.Text = "Parameters";
            this.ByParametersChart.UseVisualStyleBackColor = true;
            // 
            // providerDashBoardChart1
            // 
            this.providerDashBoardChart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.providerDashBoardChart1.AssignDbConnection = null;
            this.providerDashBoardChart1.AssignParameterManager = null;
            this.providerDashBoardChart1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.providerDashBoardChart1.Location = new System.Drawing.Point(3, 4);
            this.providerDashBoardChart1.MinimumSize = new System.Drawing.Size(726, 150);
            this.providerDashBoardChart1.Name = "providerDashBoardChart1";
            this.providerDashBoardChart1.ProviderDataTable = null;
            this.providerDashBoardChart1.SelectedScenario = "";
            this.providerDashBoardChart1.ShowTablenameComboBox = true;
            this.providerDashBoardChart1.Size = new System.Drawing.Size(940, 417);
            this.providerDashBoardChart1.SQLServer = UniDB.SQLServer.stAccess;
            this.providerDashBoardChart1.TabIndex = 0;
            this.providerDashBoardChart1.Tablename = "";
            // 
            // ByProviderTabPage
            // 
            this.ByProviderTabPage.Controls.Add(this.parameterDashboardChart1);
            this.ByProviderTabPage.Location = new System.Drawing.Point(4, 22);
            this.ByProviderTabPage.Name = "ByProviderTabPage";
            this.ByProviderTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ByProviderTabPage.Size = new System.Drawing.Size(952, 427);
            this.ByProviderTabPage.TabIndex = 2;
            this.ByProviderTabPage.Text = "By Provider";
            this.ByProviderTabPage.UseVisualStyleBackColor = true;
            // 
            // parameterDashboardChart1
            // 
            this.parameterDashboardChart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parameterDashboardChart1.AssignDbConnection = null;
            this.parameterDashboardChart1.AssignParameterManager = null;
            this.parameterDashboardChart1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.parameterDashboardChart1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.parameterDashboardChart1.Location = new System.Drawing.Point(6, 6);
            this.parameterDashboardChart1.Name = "parameterDashboardChart1";
            this.parameterDashboardChart1.ParameterDataTable = null;
            this.parameterDashboardChart1.SelectedScenario = "";
            this.parameterDashboardChart1.ShowTablenameComboBox = true;
            this.parameterDashboardChart1.Size = new System.Drawing.Size(922, 458);
            this.parameterDashboardChart1.SQLServer = UniDB.SQLServer.stAccess;
            this.parameterDashboardChart1.TabIndex = 0;
            this.parameterDashboardChart1.Tablename = "";
            // 
            // OptionsPage
            // 
            this.OptionsPage.Controls.Add(this.ContinuousCheckBox);
            this.OptionsPage.Controls.Add(this.ScenarioNameTextBox);
            this.OptionsPage.Controls.Add(this.label2);
            this.OptionsPage.Controls.Add(this.OutputReportCheckBox);
            this.OptionsPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptionsPage.Location = new System.Drawing.Point(4, 22);
            this.OptionsPage.Name = "OptionsPage";
            this.OptionsPage.Size = new System.Drawing.Size(981, 493);
            this.OptionsPage.TabIndex = 2;
            this.OptionsPage.Text = "Options";
            this.OptionsPage.UseVisualStyleBackColor = true;
            // 
            // ContinuousCheckBox
            // 
            this.ContinuousCheckBox.AutoSize = true;
            this.ContinuousCheckBox.Location = new System.Drawing.Point(105, 123);
            this.ContinuousCheckBox.Name = "ContinuousCheckBox";
            this.ContinuousCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ContinuousCheckBox.Size = new System.Drawing.Size(152, 22);
            this.ContinuousCheckBox.TabIndex = 5;
            this.ContinuousCheckBox.Text = "Continuous Report";
            this.ContinuousCheckBox.UseVisualStyleBackColor = true;
            this.ContinuousCheckBox.CheckedChanged += new System.EventHandler(this.ContinuousCheckBox_CheckedChanged);
            // 
            // ScenarioNameTextBox
            // 
            this.ScenarioNameTextBox.Location = new System.Drawing.Point(244, 29);
            this.ScenarioNameTextBox.Name = "ScenarioNameTextBox";
            this.ScenarioNameTextBox.Size = new System.Drawing.Size(387, 24);
            this.ScenarioNameTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Scenario Name";
            // 
            // OutputReportCheckBox
            // 
            this.OutputReportCheckBox.AutoSize = true;
            this.OutputReportCheckBox.Location = new System.Drawing.Point(137, 95);
            this.OutputReportCheckBox.Name = "OutputReportCheckBox";
            this.OutputReportCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.OutputReportCheckBox.Size = new System.Drawing.Size(120, 22);
            this.OutputReportCheckBox.TabIndex = 2;
            this.OutputReportCheckBox.Text = "Output Report";
            this.OutputReportCheckBox.UseVisualStyleBackColor = true;
            this.OutputReportCheckBox.CheckedChanged += new System.EventHandler(this.OutputReportCheckBox_CheckedChanged);
            // 
            // ProcessTabPage
            // 
            this.ProcessTabPage.Controls.Add(this.ProcessTabs);
            this.ProcessTabPage.Location = new System.Drawing.Point(4, 22);
            this.ProcessTabPage.Name = "ProcessTabPage";
            this.ProcessTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ProcessTabPage.Size = new System.Drawing.Size(981, 493);
            this.ProcessTabPage.TabIndex = 3;
            this.ProcessTabPage.Text = "Feedback Processes";
            this.ProcessTabPage.UseVisualStyleBackColor = true;
            // 
            // ProcessTabs
            // 
            this.ProcessTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcessTabs.Controls.Add(this.tabPage1);
            this.ProcessTabs.Location = new System.Drawing.Point(6, 6);
            this.ProcessTabs.Name = "ProcessTabs";
            this.ProcessTabs.SelectedIndex = 0;
            this.ProcessTabs.Size = new System.Drawing.Size(972, 484);
            this.ProcessTabs.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.processSeclectPanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(964, 458);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Add Feedback Process";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // processSeclectPanel
            // 
            this.processSeclectPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processSeclectPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.processSeclectPanel.Location = new System.Drawing.Point(6, 6);
            this.processSeclectPanel.Name = "processSeclectPanel";
            this.processSeclectPanel.Size = new System.Drawing.Size(952, 446);
            this.processSeclectPanel.TabIndex = 0;
            this.processSeclectPanel.WaterSim = null;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem2,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(996, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.SaveReportMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.loadScenarioToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem1.Text = "&Database";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.openToolStripMenuItem.Text = "&Open Database";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // loadScenarioToolStripMenuItem
            // 
            this.loadScenarioToolStripMenuItem.Enabled = false;
            this.loadScenarioToolStripMenuItem.Name = "loadScenarioToolStripMenuItem";
            this.loadScenarioToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.loadScenarioToolStripMenuItem.Text = "Load Scenario";
            this.loadScenarioToolStripMenuItem.Click += new System.EventHandler(this.loadScenarioToolStripMenuItem_Click);
            // 
            // SaveReportMenuItem
            // 
            this.SaveReportMenuItem.Name = "SaveReportMenuItem";
            this.SaveReportMenuItem.Size = new System.Drawing.Size(136, 22);
            this.SaveReportMenuItem.Text = "&Save Report";
            this.SaveReportMenuItem.Click += new System.EventHandler(this.SaveReportMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allYearsToolStripMenuItem,
            this.nextYearToolStripMenuItem,
            this.allYearsDBToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(76, 20);
            this.toolStripMenuItem2.Text = "Simulation";
            // 
            // allYearsToolStripMenuItem
            // 
            this.allYearsToolStripMenuItem.Name = "allYearsToolStripMenuItem";
            this.allYearsToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.allYearsToolStripMenuItem.Text = "All Years";
            this.allYearsToolStripMenuItem.Click += new System.EventHandler(this.allYearsToolStripMenuItem_Click);
            // 
            // nextYearToolStripMenuItem
            // 
            this.nextYearToolStripMenuItem.Name = "nextYearToolStripMenuItem";
            this.nextYearToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.nextYearToolStripMenuItem.Text = "One Year";
            this.nextYearToolStripMenuItem.Click += new System.EventHandler(this.nextYearToolStripMenuItem_Click);
            // 
            // allYearsDBToolStripMenuItem
            // 
            this.allYearsDBToolStripMenuItem.Name = "allYearsDBToolStripMenuItem";
            this.allYearsDBToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.allYearsDBToolStripMenuItem.Text = "All Years DB";
            this.allYearsDBToolStripMenuItem.Click += new System.EventHandler(this.allYearsDBToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createReportToolStripMenuItem,
            this.continuousReportToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // createReportToolStripMenuItem
            // 
            this.createReportToolStripMenuItem.Name = "createReportToolStripMenuItem";
            this.createReportToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.createReportToolStripMenuItem.Text = "Create Report";
            this.createReportToolStripMenuItem.Click += new System.EventHandler(this.createReportToolStripMenuItem_Click);
            // 
            // continuousReportToolStripMenuItem
            // 
            this.continuousReportToolStripMenuItem.Name = "continuousReportToolStripMenuItem";
            this.continuousReportToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.continuousReportToolStripMenuItem.Text = "Continuous Report";
            this.continuousReportToolStripMenuItem.Click += new System.EventHandler(this.continuousReportToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.helpToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.helpToolStripMenuItem1.Text = "&Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MemoryLabel,
            this.StatusLabel1,
            this.StatusProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 596);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(996, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MemoryLabel
            // 
            this.MemoryLabel.Name = "MemoryLabel";
            this.MemoryLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // StatusLabel1
            // 
            this.StatusLabel1.Name = "StatusLabel1";
            this.StatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // StatusProgressBar
            // 
            this.StatusProgressBar.Name = "StatusProgressBar";
            this.StatusProgressBar.Size = new System.Drawing.Size(100, 16);
            this.StatusProgressBar.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Silver;
            this.toolStrip1.Font = new System.Drawing.Font("Verdana", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RunModelButton,
            this.RunOneYearButton,
            this.RunDBSimulationButton,
            this.OpenDBButton,
            this.SaveReportButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(996, 39);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // RunModelButton
            // 
            this.RunModelButton.AutoSize = false;
            this.RunModelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RunModelButton.Image = ((System.Drawing.Image)(resources.GetObject("RunModelButton.Image")));
            this.RunModelButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.RunModelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RunModelButton.Name = "RunModelButton";
            this.RunModelButton.Size = new System.Drawing.Size(36, 36);
            this.RunModelButton.Text = "Run Simulation";
            this.RunModelButton.ToolTipText = "Run Simulation All Years";
            this.RunModelButton.Click += new System.EventHandler(this.RunModelButton_Click);
            // 
            // RunOneYearButton
            // 
            this.RunOneYearButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RunOneYearButton.Image = ((System.Drawing.Image)(resources.GetObject("RunOneYearButton.Image")));
            this.RunOneYearButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.RunOneYearButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RunOneYearButton.Name = "RunOneYearButton";
            this.RunOneYearButton.Size = new System.Drawing.Size(36, 36);
            this.RunOneYearButton.Text = "Run One Year";
            this.RunOneYearButton.Click += new System.EventHandler(this.RunOneYearButton_Click);
            // 
            // RunDBSimulationButton
            // 
            this.RunDBSimulationButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RunDBSimulationButton.Image = ((System.Drawing.Image)(resources.GetObject("RunDBSimulationButton.Image")));
            this.RunDBSimulationButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.RunDBSimulationButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RunDBSimulationButton.Name = "RunDBSimulationButton";
            this.RunDBSimulationButton.Size = new System.Drawing.Size(36, 36);
            this.RunDBSimulationButton.Text = "Run DB Simulation";
            this.RunDBSimulationButton.Visible = false;
            this.RunDBSimulationButton.Click += new System.EventHandler(this.RunDBSimulationButton_Click);
            // 
            // OpenDBButton
            // 
            this.OpenDBButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenDBButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenDBButton.Image")));
            this.OpenDBButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.OpenDBButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenDBButton.Name = "OpenDBButton";
            this.OpenDBButton.Size = new System.Drawing.Size(36, 36);
            this.OpenDBButton.Text = "toolStripButton1";
            this.OpenDBButton.ToolTipText = "Open Database";
            this.OpenDBButton.Click += new System.EventHandler(this.OpenDBButton_Click);
            // 
            // SaveReportButton
            // 
            this.SaveReportButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveReportButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveReportButton.Image")));
            this.SaveReportButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SaveReportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveReportButton.Name = "SaveReportButton";
            this.SaveReportButton.Size = new System.Drawing.Size(36, 36);
            this.SaveReportButton.Text = "toolStripButton1";
            this.SaveReportButton.ToolTipText = "Save Report to RIch Text FIle";
            this.SaveReportButton.Click += new System.EventHandler(this.SaveReportButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Access Files *.mdb|*.mdb";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Rich Text *.rtf|*.rtf|Text File|*.txt";
            // 
            // WaterSimTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(996, 618);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ModelControlsTabControl);
            this.Controls.Add(this.menuStrip1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "WaterSimTestForm";
            this.Text = "WaterSim Tester";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.ModelControlsTabControl.ResumeLayout(false);
            this.InputPage.ResumeLayout(false);
            this.OutputTabPage.ResumeLayout(false);
            this.GraphsTab.ResumeLayout(false);
            this.OutputPage.ResumeLayout(false);
            this.ReportPage.ResumeLayout(false);
            this.DBPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbTableGridView)).EndInit();
            this.MapsPage.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.AllGraphsTabControl.ResumeLayout(false);
            this.ByParametersChart.ResumeLayout(false);
            this.ByProviderTabPage.ResumeLayout(false);
            this.OptionsPage.ResumeLayout(false);
            this.OptionsPage.PerformLayout();
            this.ProcessTabPage.ResumeLayout(false);
            this.ProcessTabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl ModelControlsTabControl;
        private System.Windows.Forms.TabPage InputPage;
        private System.Windows.Forms.TabPage OutputTabPage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton RunModelButton;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel MemoryLabel;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar StatusProgressBar;
        private System.Windows.Forms.TabPage OptionsPage;
        private System.Windows.Forms.CheckBox OutputReportCheckBox;
        private System.Windows.Forms.TextBox ScenarioNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ContinuousCheckBox;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.TabControl GraphsTab;
        private System.Windows.Forms.TabPage OutputPage;
        private System.Windows.Forms.TabPage ReportPage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabPage DBPage;
        private System.Windows.Forms.Button CopyOutputButton;
        private System.Windows.Forms.ListBox OutputListBox;
        private System.Windows.Forms.Button CopyReportButton;
        private System.Windows.Forms.RichTextBox ReportTextBox;
        private System.Windows.Forms.DataGridView dbTableGridView;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem allYearsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextYearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allYearsDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem continuousReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton RunOneYearButton;
        private System.Windows.Forms.ToolStripButton RunDBSimulationButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem SaveReportMenuItem;
        private System.Windows.Forms.ToolStripButton OpenDBButton;
        private System.Windows.Forms.ToolStripButton SaveReportButton;
        private System.Windows.Forms.ToolStripMenuItem loadScenarioToolStripMenuItem;
        private WaterSimDCDC.Controls.WaterSim_InputPanel WS_InputPanel;
        private System.Windows.Forms.TabPage ProcessTabPage;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabControl AllGraphsTabControl;
        private System.Windows.Forms.TabPage ByParametersChart;
        private WaterSimDCDC.Controls.ProviderDashBoardChart providerDashBoardChart1;
        private System.Windows.Forms.TabControl ProcessTabs;
        private System.Windows.Forms.TabPage ByProviderTabPage;
        private WaterSimDCDC.Controls.ParameterDashboardChart parameterDashboardChart1;
        private System.Windows.Forms.TabPage tabPage1;
        private WaterSimDCDC.Controls.ProcessSeclectControl processSeclectPanel;
        private System.Windows.Forms.TabPage MapsPage;
        private WaterSimDCDC.Controls.Dotspatial.MapDashboardControl mapDashboardControl1;
        
    }
}

