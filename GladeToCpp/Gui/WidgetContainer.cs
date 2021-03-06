﻿using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GladeConstructor.Parser;
using WeifenLuo.WinFormsUI.Docking;

namespace GladeConstructor.Gui
{
    public partial class WidgetContainer : DockContent
    {
        public static ObjectIDGenerator WidgetContainerId = new ObjectIDGenerator();

        private bool isFirstTime;

        public long ID
        {
            get
            {
                return WidgetContainerId.GetId(this, out isFirstTime);
            }
        }

        private BindingForm bindingForm;
        
        public WidgetContainer()
        {
            InitializeComponent();
        }

        public WidgetContainer(BindingForm form)
        {
            InitializeComponent();
            bindingForm = form;
            SetDataSource(bindingForm.Widgets);
        }

        public void SetDataSource(BindingSource source)
        {
            ObjectsDataGrid.DataSource = source;
        }

        private void ObjectsDataGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ObjectsDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void WidgetContainer_FormClosing(object sender, FormClosingEventArgs e)
        {
            //GuiManager.WidgetContainersList.FindIndex(w => w.ID == this.ID);
            GuiManager.WidgetContainersList.RemoveAll(w => w.ID == this.ID);
            bindingForm.GUIContainerId = -1;
        }
    }
}
