﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WaterSimDCDC;
using System.Reflection;
using System.Runtime.InteropServices;

namespace WaterSim_Tester
{
    public partial class WSimTreeSelectV1 : UserControl
    {

        ParameterManagerClass FParamManager;
        List<ModelParamItem> FParamItems = new List<ModelParamItem>();
        List<ModelParameterGroupClass> FAllGroups = new List<ModelParameterGroupClass>();
        List<ParmTreeNode> TheParmNodes = new List<ParmTreeNode>();

        bool FShowInputBase = true;
        bool FShowInputProvider = true;
        bool FShowOutputBase = true;
        bool FShowOutputProvider = true;
        ShowFieldnameState FShowFieldname = ShowFieldnameState.sfsNone;

        public WSimTreeSelectV1()
        {
            InitializeComponent();
            treeViewParameters.ImageList = imageListTreeNodes;
            treeViewParameters.ShowNodeToolTips = true;
            
        }

        public WSimTreeSelectV1(ParameterManagerClass ParamManager)
        {
            FParamManager = ParamManager;
            InitializeComponent();
            BuildParmList();
        }

        public ParameterManagerClass ParameterManager
        {
            get { return FParamManager; }
            set
            {
                FParamManager = value;
                if (FParamManager != null)
                {
                    BuildParmList();
                    BuildTree();
                }
            }
        }

        internal void BuildParmList()
        {
            if (FParamManager != null)
            {
                foreach (ModelParameterClass MP in FParamManager.AllModelParameters())
                {
                    ModelParamItem MPI = new ModelParamItem(MP);
                    FParamItems.Add(MPI);
                }
            }
        }

        internal void BuildTree()
        {
            // get groups
            
            foreach (ModelParamItem MPI in FParamItems)
            {

                if (MPI.TopicsGroup.Count > 0)
                {

                    foreach (ModelParameterGroupClass MPG in MPI.TopicsGroup)
                    {
                        if (FAllGroups.Find(delegate(ModelParameterGroupClass item) { return item.ID == MPG.ID; }) == null)
                        {
                            FAllGroups.Add(MPG);
                            ParmTreeNode temp = new ParmTreeNode(MPG, FParamManager);
                            TheParmNodes.Add(temp);
                        }
                    }

                }
            }

            foreach(ParmTreeNode Node in TheParmNodes)
            {
                treeViewParameters.Nodes.Add(Node);

            
            }

        }

        public bool UseCheckBoxes
        {
            get { return treeViewParameters.CheckBoxes; }
            set { treeViewParameters.CheckBoxes = value; }
        }

        internal void _ResetFieldName(TreeNode target)
        {
            (target as ParmTreeNode).ShowFieldnames = FShowFieldname;
            if (target.Nodes.Count > 0)
            {
                foreach (TreeNode temp in target.Nodes)
                {
                    _ResetFieldName(temp);
                }
            }
        }
        internal void ResetFieldname()
        {

            TreeNode tempNode = treeViewParameters.TopNode;
            treeViewParameters.LabelEdit = true;
            treeViewParameters.BeginUpdate();
            foreach(TreeNode tempnode in treeViewParameters.Nodes)
            {
                _ResetFieldName(tempnode);
            }
            treeViewParameters.EndUpdate();
            treeViewParameters.LabelEdit = false;

            
        }
        private void ShowCheckEvent(object sender, EventArgs e)
        {

        }

        private void ShowDisplayChangeEvent()
        {

        }

        private void ToolStripMenuItemShowInputBase_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void contextMenuStripParameterTreeview_Opening(object sender, CancelEventArgs e)
        {

        }

        
        bool SettingShowFieldname = false;

        private void ToolStripMenuItemShowFieldFirst_CheckedChanged(object sender, EventArgs e)
        {
            if ((!SettingShowFieldname)&&(ToolStripMenuItemShowFieldFirst.Checked))
            {
                SettingShowFieldname = true;
                toolStripMenuItemNoShowField.Checked = false;
                ToolStripMenuItemShowFieldLast.Checked = false;
                FShowFieldname = ShowFieldnameState.sfsFirst;
                ResetFieldname();
                SettingShowFieldname = false;
            }
        }

        private void toolStripMenuItemNoShowField_CheckedChanged(object sender, EventArgs e)
        {
            if ((!SettingShowFieldname) && (toolStripMenuItemNoShowField.Checked))
            {
                SettingShowFieldname = true;
                ToolStripMenuItemShowFieldFirst.Checked = false;
                ToolStripMenuItemShowFieldLast.Checked = false;
                FShowFieldname = ShowFieldnameState.sfsNone;
                ResetFieldname();
                SettingShowFieldname = false;
            }
        }

        private void ToolStripMenuItemShowFieldLast_CheckedChanged(object sender, EventArgs e)
        {
            if ((!SettingShowFieldname) && (ToolStripMenuItemShowFieldLast.Checked))
            {
                SettingShowFieldname = true;
                toolStripMenuItemNoShowField.Checked = false;
                ToolStripMenuItemShowFieldFirst.Checked = false;
                FShowFieldname = ShowFieldnameState.sfsLast;
                ResetFieldname();
                SettingShowFieldname = false;
            }
        }
    }

    public enum ShowFieldnameState { sfsNone, sfsFirst, sfsLast };


    public class ParmTreeNode : TreeNode
    {
        ParameterManagerClass FPM;
        ModelParameterGroupClass ThisGroup = null;
        ModelParamItem ThisParamItem = null;
        ShowFieldnameState FShowFieldnames = ShowFieldnameState.sfsNone;

        public ParmTreeNode(string aName, ParameterManagerClass aPM) : base (aName)
        {
            FPM = aPM;
        }


        public ParmTreeNode(ModelParameterGroupClass aGroup,ParameterManagerClass aPM ) : base(aGroup.Name)
        {
            FPM = aPM;
            ThisGroup = aGroup;
            ImageIndex = 4;
            SelectedImageIndex = 4;
            foreach (ModelParameterGroupClass groupitem in aGroup.Groups())
            {
                Add(groupitem);
            }
            foreach (int parmcode in aGroup.ModelParameters())
            {
                    Add(parmcode);
            }
        }

        public ParmTreeNode(int ParmCode, ParameterManagerClass aPM)
        {
            FPM = aPM;
            try
                {
                    ModelParameterClass MP = aPM.Model_Parameter(ParmCode);
                    ThisParamItem = new ModelParamItem(MP);
                    Name = ThisParamItem.Fieldname;
                    Text = ThisParamItem.Label;
                    ToolTipText = ThisParamItem.Description;
                    switch(ThisParamItem.ParameterType)
                    {
                        case modelParamtype.mptInputBase:
                            ImageIndex = 0;
                            SelectedImageIndex = 0;
                            break;
                        case modelParamtype.mptInputProvider:
                            ImageIndex = 1;
                            SelectedImageIndex = 1;
                            break;
                        case modelParamtype.mptOutputBase:
                            ImageIndex = 2;
                            SelectedImageIndex = 2;
                            break;
                         case modelParamtype.mptOutputProvider:
                            ImageIndex = 3;
                            SelectedImageIndex = 3;
                             break;
                        default:
                            ImageIndex = 4;
                            SelectedImageIndex = 4;
                            break;
                    }
                }
             catch
                {
                    ModelParamItem temp = new ModelParamItem();
                    temp.SetUndefined(ParmCode);
                    ThisParamItem = temp;
                    Name = ThisParamItem.Fieldname;
                    Text = ThisParamItem.Label;
                    ImageIndex = SelectedImageIndex = 6;
                }
            
        }

  
        void Add(ModelParameterGroupClass aGroup)
        {
            // Create new node
            ParmTreeNode Temp = new ParmTreeNode(aGroup, FPM);
            Nodes.Add(Temp);
        }

        void Add(int ParamCode)
        {
            // Create new node
            ParmTreeNode Temp = new ParmTreeNode(ParamCode, FPM);
            Nodes.Add(Temp);
        }

        public ShowFieldnameState ShowFieldnames
        {
            get { return FShowFieldnames; }
            set { 
                FShowFieldnames = value;
                RenderFieldnames(FShowFieldnames);

            }

        }
        public int Levels()
        {
            return LastNode.Index;
        }

        public bool isGroupNode
        {
            get {return (ThisGroup!=null);}
        }

        public bool isParamItemNode
        {
            get { return (ThisParamItem != null); }
        }


        public bool isInTree(ModelParameterGroupClass Target)
        {
            bool found = false;
            if (isGroupNode)
            {
                if (ThisGroup.ID == Target.ID) { found = true; }
            }
            else
            {
                foreach (TreeNode node in Nodes)
                {
                    if (node is ParmTreeNode)
                    {
                        if ((node as ParmTreeNode).isInTree(Target))
                        {
                            found = true;
                            break;
                        }
                    }
                }
            }
            return found;
        }

        public bool isInTree(int paramcode)
        {
            bool found = false;
            if (isParamItemNode)
            {
                if ( ThisParamItem.ModelParam==paramcode) { found = true; }
            }
            else
            {
                foreach (TreeNode node in Nodes)
                {
                    if (node is ParmTreeNode)
                    {
                        if ((node as ParmTreeNode).isInTree(paramcode))
                        {
                            found = true;
                            break;
                        }
                    }
                }
            }
            return found;
        }

        internal void RenderFieldnames(ShowFieldnameState thestate)
        {
            string thetext = "";
            if (isParamItemNode)
            {
                switch (thestate)
                {
                    case ShowFieldnameState.sfsNone:
                        thetext = ThisParamItem.Label;
                        break;
                    case ShowFieldnameState.sfsFirst:
                        thetext = ThisParamItem.Fieldname + " : " + ThisParamItem.Label;
                        break;
                    case ShowFieldnameState.sfsLast:
                        thetext = ThisParamItem.Label + " : "+ ThisParamItem.Fieldname;
                        break;
                }
                BeginEdit();
                Text = thetext;
                EndEdit(false);
            }
        }

        private const int TVIF_STATE = 0x8;
        private const int TVIS_STATEIMAGEMASK = 0xF000;
        private const int TV_FIRST = 0x1100;
        private const int TVM_SETITEM = TV_FIRST + 63;

        [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Auto)]
        private struct TVITEM
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public IntPtr lParam;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam,
                                                 ref TVITEM lParam);

        /// <summary>
        /// Hides the checkbox for the specified node on a TreeView control.
        /// </summary>
        private void HideCheckBox(TreeView tvw, TreeNode node)
        {
            TVITEM tvi = new TVITEM();
            tvi.hItem = node.Handle;
            tvi.mask = TVIF_STATE;
            tvi.stateMask = TVIS_STATEIMAGEMASK;
            tvi.state = 0;
            SendMessage(tvw.Handle, TVM_SETITEM, IntPtr.Zero, ref tvi);
        }
    }

    //--------------------------------------------------------------
    internal class ModelParamItem
    {
        int FModelParam = -1;
        string FModelParamName = "";
        string FFieldname = "";
        string FLabel = "";
        string FDescrip = "";
        string FUnitsShort = "";
        string FUnitsLong = "";
        int FMax = 0;
        int FMin = 0;
        rangeChecktype FRangeType = rangeChecktype.rctUnknown;
        ModelParameterGroupClass FDepends = null;
        List<ModelParameterGroupClass> FTopics = new List<ModelParameterGroupClass>();
        int Default = 0;
        modelParamtype FParamType = modelParamtype.mptUnknown;
        eProviderAggregateMode FProvAgMode = eProviderAggregateMode.agNone;
        string FProviderPropertyName = "";
        string FgetintName = "";
        string FgetintarrayName = "";
        string FsetintName = "";
        string FsetintarrayName = "";
        string FspecialBaseRangeCheckName = "";
        string FspecialProviderRangeCheckName = "";
        string FreloadEventName = "";

        /// <summary>   Default constructor. </summary>
        public ModelParamItem() 
        { 
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Constructor. </summary>
        ///
        /// <param name="TheModelParam">    the model parameter to create item from. </param>
        ///-------------------------------------------------------------------------------------------------

        public ModelParamItem(ModelParameterClass TheModelParam)
        {
            FModelParam = TheModelParam.ModelParam;
            FModelParamName = eModelParam.Names(TheModelParam.ModelParam);
            FFieldname = TheModelParam.Fieldname; ;
            FLabel = TheModelParam.Label;

            if (TheModelParam.isExtended)
            {
                FDescrip = TheModelParam.Description;
                FUnitsShort = TheModelParam.Units;
                FUnitsLong = TheModelParam.UnitsLong;
                if (TheModelParam.TopicGroups != null)
                {
                    if (TheModelParam.TopicGroups.Count > 0)
                    {
                        foreach (ModelParameterGroupClass MPG in TheModelParam.TopicGroups)
                        {
                            FTopics.Add(MPG);
                        }
                    }
                }
            }
            FMax = TheModelParam.HighRange;
            FMin = TheModelParam.LowRange;
            FRangeType = TheModelParam.RangeCheckType;
            FDepends = TheModelParam.DerivedFrom;
            //int Default = 0;
            FParamType = TheModelParam.ParamType;
            if ((TheModelParam.isProviderParam)&&(TheModelParam.ProviderProperty != null))
            {
                FProvAgMode = TheModelParam.ProviderProperty.AggregateMode;
                FProviderPropertyName = TheModelParam.ProviderProperty.GetType().FullName;
            }
        }

        public void SetUndefined(int code)
        {
            // see of this is in documentation
            string test = eModelParam.Names(code);
            if (test != "")
            {
                FLabel = test;
            }
            else
            {
                FLabel = "UnDefined #" + code.ToString();
            }
            FModelParam = code;
            FFieldname = "??#"+code.ToString();
        }

        public int ModelParam
        {
            get { return FModelParam; }
            set { FModelParam = value; }
        }
 
        public string ModelParamName
        {
            get { return FModelParamName; }
            set { FModelParamName = value; }
        }


        public string Fieldname
        {
            get { return FFieldname; }
            set { FFieldname = value; }
        }

        public string Label
        {
            get { return FLabel; }
            set { FLabel = value; }
        }

        public string Description
        {
            get { return FDescrip; }
            set { FDescrip = value; }
        }

        public string Units
        {
            get { return FUnitsShort; }
            set { FUnitsShort = value; }
        }

        public string UnitsLong
        {
            get { return FUnitsLong; }
            set { FUnitsLong = value; }
        }

 
        public int Max
        {
            get { return FMax; }
            set { FMax = value; }
        }

        public int Min
        {
            get { return FMin; }
            set { FMin = value; }
        }

        public rangeChecktype RangeCheckType
        {
            get { return FRangeType; }
            set { FRangeType = value; }
        }

        public ModelParameterGroupClass DependencyGroup
        {
            get { return FDepends; }
            set { FDepends = value; }
        }

        public List<ModelParameterGroupClass> TopicsGroup
        {
            get { return FTopics; }
            set { FTopics = value; }
        }

        public modelParamtype ParameterType
        {
            get { return FParamType; }
            set { FParamType = value; }
        }

        public eProviderAggregateMode ProviderAggregateMode
        {
            get { return FProvAgMode; }
            set { FProvAgMode = value; }
        }

        public string ProviderPropertyName
        {
            get { return FProviderPropertyName; }
            set { FProviderPropertyName = value; }
        }
    }
}
