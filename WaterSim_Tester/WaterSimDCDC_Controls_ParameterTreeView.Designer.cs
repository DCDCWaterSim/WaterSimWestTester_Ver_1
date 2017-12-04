namespace WaterSim_Tester
{
    partial class WaterSimDCDC_Controls_ParameterTreeView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaterSimDCDC_Controls_ParameterTreeView));
            this.treeViewParameters = new System.Windows.Forms.TreeView();
            this.imageListTreeNodes = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.picboxInBase = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxInBase)).BeginInit();
            this.SuspendLayout();
            // 
            // treeViewParameters
            // 
            this.treeViewParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewParameters.Location = new System.Drawing.Point(3, 0);
            this.treeViewParameters.Name = "treeViewParameters";
            this.treeViewParameters.Size = new System.Drawing.Size(561, 492);
            this.treeViewParameters.TabIndex = 0;
            // 
            // imageListTreeNodes
            // 
            this.imageListTreeNodes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTreeNodes.ImageStream")));
            this.imageListTreeNodes.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTreeNodes.Images.SetKeyName(0, "green arrow left.png");
            this.imageListTreeNodes.Images.SetKeyName(1, "green round arrow going right 32 x 32.png");
            this.imageListTreeNodes.Images.SetKeyName(2, "red arrow left.png");
            this.imageListTreeNodes.Images.SetKeyName(3, "red round arroe going left 32 x 32psd.png");
            this.imageListTreeNodes.Images.SetKeyName(4, "blue buttondouble arrow left right  32 x 32.png");
            this.imageListTreeNodes.Images.SetKeyName(5, "blue circle with arrow 32 x 32 4 .png");
            this.imageListTreeNodes.Images.SetKeyName(6, "red round question 32 x 32.png");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 535);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(567, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picboxInBase);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 492);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(561, 40);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key: ";
            // 
            // picboxInBase
            // 
            this.picboxInBase.Location = new System.Drawing.Point(47, 5);
            this.picboxInBase.Name = "picboxInBase";
            this.picboxInBase.Size = new System.Drawing.Size(32, 32);
            this.picboxInBase.TabIndex = 1;
            this.picboxInBase.TabStop = false;
            // 
            // WSimTreeSelectV1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.treeViewParameters);
            this.Name = "WSimTreeSelectV1";
            this.Size = new System.Drawing.Size(567, 557);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxInBase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewParameters;
        private System.Windows.Forms.ImageList imageListTreeNodes;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picboxInBase;
        private System.Windows.Forms.Label label1;
    }
}
