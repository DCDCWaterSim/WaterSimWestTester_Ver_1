namespace WaterSim_Tester
{
    partial class WSimTreeSelectV1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WSimTreeSelectV1));
            this.treeViewParameters = new System.Windows.Forms.TreeView();
            this.contextMenuStripParameterTreeview = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemShowFields = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemShowFieldLast = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemShowFieldFirst = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNoShowField = new System.Windows.Forms.ToolStripMenuItem();
            this.sortNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortInputOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListTreeNodes = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStripParameterTreeview.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewParameters
            // 
            this.treeViewParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewParameters.ContextMenuStrip = this.contextMenuStripParameterTreeview;
            this.treeViewParameters.Location = new System.Drawing.Point(2, 2);
            this.treeViewParameters.Margin = new System.Windows.Forms.Padding(2);
            this.treeViewParameters.Name = "treeViewParameters";
            this.treeViewParameters.Size = new System.Drawing.Size(422, 389);
            this.treeViewParameters.TabIndex = 0;
            // 
            // contextMenuStripParameterTreeview
            // 
            this.contextMenuStripParameterTreeview.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.sortNameToolStripMenuItem,
            this.sortInputOutputToolStripMenuItem});
            this.contextMenuStripParameterTreeview.Name = "contextMenuStripParameterTreeview";
            this.contextMenuStripParameterTreeview.Size = new System.Drawing.Size(170, 92);
            this.contextMenuStripParameterTreeview.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripParameterTreeview_Opening);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemShowFields});
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.showToolStripMenuItem.Text = "Show";
            // 
            // ToolStripMenuItemShowFields
            // 
            this.ToolStripMenuItemShowFields.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemShowFieldLast,
            this.ToolStripMenuItemShowFieldFirst,
            this.toolStripMenuItemNoShowField});
            this.ToolStripMenuItemShowFields.Name = "ToolStripMenuItemShowFields";
            this.ToolStripMenuItemShowFields.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemShowFields.Text = "FieldNames ";
            // 
            // ToolStripMenuItemShowFieldLast
            // 
            this.ToolStripMenuItemShowFieldLast.CheckOnClick = true;
            this.ToolStripMenuItemShowFieldLast.Name = "ToolStripMenuItemShowFieldLast";
            this.ToolStripMenuItemShowFieldLast.Size = new System.Drawing.Size(199, 22);
            this.ToolStripMenuItemShowFieldLast.Text = "Show Fieldname Last";
            this.ToolStripMenuItemShowFieldLast.CheckedChanged += new System.EventHandler(this.ToolStripMenuItemShowFieldLast_CheckedChanged);
            // 
            // ToolStripMenuItemShowFieldFirst
            // 
            this.ToolStripMenuItemShowFieldFirst.CheckOnClick = true;
            this.ToolStripMenuItemShowFieldFirst.Name = "ToolStripMenuItemShowFieldFirst";
            this.ToolStripMenuItemShowFieldFirst.Size = new System.Drawing.Size(199, 22);
            this.ToolStripMenuItemShowFieldFirst.Text = "Show Fieldname First";
            this.ToolStripMenuItemShowFieldFirst.CheckedChanged += new System.EventHandler(this.ToolStripMenuItemShowFieldFirst_CheckedChanged);
            // 
            // toolStripMenuItemNoShowField
            // 
            this.toolStripMenuItemNoShowField.CheckOnClick = true;
            this.toolStripMenuItemNoShowField.Name = "toolStripMenuItemNoShowField";
            this.toolStripMenuItemNoShowField.Size = new System.Drawing.Size(199, 22);
            this.toolStripMenuItemNoShowField.Text = "Do not show Fieldname";
            this.toolStripMenuItemNoShowField.CheckedChanged += new System.EventHandler(this.toolStripMenuItemNoShowField_CheckedChanged);
            // 
            // sortNameToolStripMenuItem
            // 
            this.sortNameToolStripMenuItem.Name = "sortNameToolStripMenuItem";
            this.sortNameToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.sortNameToolStripMenuItem.Text = "Sort Name";
            // 
            // sortInputOutputToolStripMenuItem
            // 
            this.sortInputOutputToolStripMenuItem.Name = "sortInputOutputToolStripMenuItem";
            this.sortInputOutputToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.sortInputOutputToolStripMenuItem.Text = "Sort Input/Output";
            // 
            // imageListTreeNodes
            // 
            this.imageListTreeNodes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTreeNodes.ImageStream")));
            this.imageListTreeNodes.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTreeNodes.Images.SetKeyName(0, "green round arrow going right 32 x 32.png");
            this.imageListTreeNodes.Images.SetKeyName(1, "green square arrow right 32 x 32.png");
            this.imageListTreeNodes.Images.SetKeyName(2, "red round arroe going left 32 x 32psd.png");
            this.imageListTreeNodes.Images.SetKeyName(3, "red square arrow left 32 x 32.png");
            this.imageListTreeNodes.Images.SetKeyName(4, "blue buttondouble arrow left right  32 x 32.png");
            this.imageListTreeNodes.Images.SetKeyName(5, "blue buttondouble arrow left right  32 x 32 selected.png");
            this.imageListTreeNodes.Images.SetKeyName(6, "red round question 32 x 32.png");
            // 
            // WSimTreeSelectV1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeViewParameters);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "WSimTreeSelectV1";
            this.Size = new System.Drawing.Size(425, 424);
            this.contextMenuStripParameterTreeview.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewParameters;
        private System.Windows.Forms.ImageList imageListTreeNodes;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripParameterTreeview;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemShowFields;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemShowFieldFirst;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemShowFieldLast;
        private System.Windows.Forms.ToolStripMenuItem sortNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortInputOutputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNoShowField;
    }
}
