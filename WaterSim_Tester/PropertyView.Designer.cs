namespace QuayControls
{
    partial class PropertyView
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
            this.PropertyLabel = new System.Windows.Forms.Label();
            this.PropertyTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // PropertyLabel
            // 
            this.PropertyLabel.AutoSize = true;
            this.PropertyLabel.Location = new System.Drawing.Point(13, 13);
            this.PropertyLabel.Name = "PropertyLabel";
            this.PropertyLabel.Size = new System.Drawing.Size(35, 13);
            this.PropertyLabel.TabIndex = 0;
            this.PropertyLabel.Text = "label1";
            // 
            // PropertyTextbox
            // 
            this.PropertyTextbox.Location = new System.Drawing.Point(54, 6);
            this.PropertyTextbox.Name = "PropertyTextbox";
            this.PropertyTextbox.Size = new System.Drawing.Size(160, 20);
            this.PropertyTextbox.TabIndex = 1;
            // 
            // PropertyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PropertyTextbox);
            this.Controls.Add(this.PropertyLabel);
            this.Name = "PropertyView";
            this.Size = new System.Drawing.Size(262, 42);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PropertyLabel;
        private System.Windows.Forms.TextBox PropertyTextbox;
    }
}
