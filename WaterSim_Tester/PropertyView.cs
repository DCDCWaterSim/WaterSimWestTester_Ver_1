using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuayControls
{
    public partial class PropertyView : UserControl
    {
        string fLabel = "";
        int FIntValue = int.MinValue;
        double FDoubleValue = double.MinValue;
        bool FEditMode = false;
        bool FAutoSize = false; 
        string FStringValue = "";

        //---------------------------------------------------------
        public PropertyView()
        {
            InitializeComponent();
            PropertyLabel.Text = fLabel;
            PropertyTextbox.Text = "";
            FEditMode = false;
            FAutoSize = true;
        }
        //---------------------------------------------------------
        public PropertyView(string TheLabel, string TheValue)
        {
            InitializeComponent();
            PropertyLabel.Text = TheLabel;
            PropertyTextbox.Text = TheValue;
            FEditMode = false;
            FAutoSize = true;
        }
        //---------------------------------------------------------
        public PropertyView(string TheLabel, string TheValue, bool isEditable, bool isAutoSize)
        {
            InitializeComponent();
            PropertyLabel.Text = TheLabel;
            PropertyTextbox.Text = TheValue;
            FEditMode = isAutoSize;
            FAutoSize = isAutoSize;
        }
        //---------------------------------------------------------
        internal void ResizeControl()
        {
        }
        //---------------------------------------------------------
        public string AsString
        {
            get { return FStringValue; }
            set { FStringValue = value; }
        }
        //---------------------------------------------------------
        public int AsInt
        {
            get { return FIntValue; }
            set { FIntValue = value; }
        }
        //---------------------------------------------------------
        public double AsDouble
        {
            get { return FDoubleValue; }
            set { FDoubleValue = value; }
        }
        //---------------------------------------------------------
        

    }
}
