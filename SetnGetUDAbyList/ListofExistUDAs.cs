using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TS = Tekla.Structures;
using TSM = Tekla.Structures.Model;
using TSMUI = Tekla.Structures.Model.UI;
using System.Collections;
using System.IO;
using TSD = Tekla.Structures.Drawing;

namespace SetnGetAttribute
{
    public partial class ListofExistUDAs : Form
    {
        TSM.Model _model = new TSM.Model();
        SetAttributeFromList _theMainForm = new SetAttributeFromList();
        public SetAttributeFromList theMainForm { get; set; }

        public ListofExistUDAs()
        {
            TopMost = true;
            InitializeComponent();
        }
        private void ListofExistUDAs_Load(object sender, EventArgs e)
        {
            //methSizeToFitColumns();
            this.Left = theMainForm.Left;
            this.Top = theMainForm.Bottom;
        }
        private void bGetUDAList_Click(object sender, EventArgs e)
        {
            GetList();
            methSizeToFitColumns();
        }

        private void GetList()
        {
            List<UDA> UDAList = new List<UDA>();
            ArrayList selobj = new ArrayList();

            switch (theMainForm.DataFile.objectSelectorType)
            {
                case AppDataFile.eObjectSelectorType.Model:
                    selobj = ModelOperations.SelectModelObj();
                    IEnumerator Enum_Model = selobj.GetEnumerator();
                    while (Enum_Model.MoveNext())
                    {
                        TSM.ModelObject prototype = Enum_Model.Current as TSM.ModelObject;
                        if (prototype != null)
                        {
                            UDAList = UDA.GetUDAList(prototype);
                        }
                    }
                    break;
                case AppDataFile.eObjectSelectorType.Drawing:
                    selobj = DrawingOperations.SelectDrawingObj();
                    IEnumerator Enum_Draw = selobj.GetEnumerator();
                    while (Enum_Draw.MoveNext())
                    {
                        TSD.DatabaseObject drawprototype = Enum_Draw.Current as TSD.DatabaseObject;
                        if (drawprototype != null)
                        {
                            TSM.ModelObject prototype = theMainForm.ConvertFromDrawingtoModelObj(drawprototype);
                            UDAList = UDA.GetUDAList(prototype);
                        }
                    }
                    break;
                default:
                    break;
            }
           
            //ArrayList selobj = ModelOperations.SelectModelObj();
            //IEnumerator Enum = selobj.GetEnumerator();
            //while (Enum.MoveNext())
            //{
            //    TSM.ModelObject prototype = Enum.Current as TSM.ModelObject;
            //    if (prototype != null)
            //    {
            //        UDAList = UDA.GetUDAList(prototype);
            //    }
            //}
            FillDataGridView(UDAList);
        }
        public void FillDataGridView(List<UDA> UDAList)
        {
            RemoveRows();

            int i = UDAList.Count;
            dGV_Main.ReadOnly = false;
            int j = 0;
            if (i > 1)
                dGV_Main.Rows.Add(i - 1);

            foreach (var item in UDAList)
            {
                dGV_Main.Rows[j].Cells[0].Value = item.Name;
                dGV_Main.Rows[j].Cells[1].Value = item.Value;
                dGV_Main.Rows[j].Cells[2].Value = item.Type;
                j++;
            }
        }
        private void RemoveRows()
        {
            dGV_Main.SelectAll();
            foreach (DataGridViewRow row in dGV_Main.SelectedRows)
            {
                if (!row.IsNewRow)
                    dGV_Main.Rows.Remove(row);
            }
        }

        private void bCopyStr2MainForm_Click(object sender, EventArgs e)
        {
            try
            {
                CopytoMainForm();
            }
            catch (Exception ex)
            {
                Logger.WriteExMessage2Temp(SetAttributeFromList.PathofLog, ex);
                MessageBox.Show("Read Log");
            }
        }

        private void CopytoMainForm()
        {
            string value = string.Empty;
            foreach (DataGridViewCell oneCell in dGV_Main.SelectedCells)
            {
                if (oneCell.Selected)
                {
                    int i = oneCell.RowIndex; 
                    value = dGV_Main.Rows[i].Cells[0].Value.ToString();
                    theMainForm.tbUserAttr.Text = value;
                    value = dGV_Main.Rows[i].Cells[2].Value.ToString();
                    theMainForm.cBUDADatatype.Text = value;
                    //theMainForm.Refresh();
                }
            }
        }
        public void methSizeToFitColumns()
        {
            try
            {
                int columnWidths = 0;
                int columnCount = 0;

                columnCount = dGV_Main.Columns.Count;
                //if (btnShowIDs.Checked)
                //{
                //    columnCount = dGV_Main.Columns.Count - 1;
                //}
                //else
                //{
                //    columnCount = grdMain.Columns.Count - 3;
                //}

                for (int i = 0; i < columnCount; i++)
                {
                    if (dGV_Main.Columns[i].Visible)
                    {
                        columnWidths += dGV_Main.Columns[i].Width;
                    }
                }

                this.Width = columnWidths + dGV_Main.RowHeadersWidth + 100;

            }
            catch (Exception e)
            {
                if (e.Message == "")
                {

                }
                else
                {
                    MessageBox.Show("There was an unexpected error in the following module:\n\n" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\n\nDetails:\n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clipboard.SetText(e.Message);
                }
            }
        }
    }
}
