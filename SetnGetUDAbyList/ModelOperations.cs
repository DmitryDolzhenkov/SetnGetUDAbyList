using System;
using System.Text;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;
using TSMUI = Tekla.Structures.Model.UI;
using Tekla.Structures.Model.Operations;
using TSD = Tekla.Structures.Drawing;
using TSDUI = Tekla.Structures.Drawing.UI;

using TSM = Tekla.Structures.Model;
//using Tekla.Structures.Solid;
using Tekla.Structures.Model;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Linq;
using System.Diagnostics;
using System.Threading;

namespace SetnGetAttribute
{
    public static class ModelOperations
    {
        public static ArrayList SelectModelObj()
        {
            ArrayList selobj = new ArrayList();
            TSM.ModelObjectEnumerator MOE = new TSMUI.ModelObjectSelector().GetSelectedObjects();

            while (MOE.MoveNext())
            {
                selobj.Add(MOE.Current);
            }
            TSMUI.ModelObjectSelector selector = new TSMUI.ModelObjectSelector();
            selector.Select(selobj);
            if (selobj.Count == 0)
            {
                MessageBox.Show("No one object is selected.", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.None);
            }

            return selobj;
        }
    }
    public static class DrawingOperations
    {
        public static ArrayList SelectDrawingObj()
        {
            ArrayList selobj = new ArrayList();
            TSD.DrawingHandler dh = new TSD.DrawingHandler();
            TSDUI.DrawingSelector ds = dh.GetDrawingSelector();
            TSD.DrawingEnumerator SelectedObjects = ds.GetSelected();

            while (SelectedObjects.MoveNext())
            {
                selobj.Add(SelectedObjects.Current);
            }
            //TSDUI.DrawingObjectSelector selector = new TSDUI.DrawingObjectSelector().G;
            //selector.Select(selobj);
            if (selobj.Count == 0)
            {
                MessageBox.Show("No one object is selected.", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.None);
            }

            return selobj;
        }
    }
}
