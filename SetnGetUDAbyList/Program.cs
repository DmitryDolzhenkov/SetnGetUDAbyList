using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TSM = Tekla.Structures.Model;


namespace SetnGetAttribute
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            TSM.Model _model = new TSM.Model();
            if (_model.GetConnectionStatus())
            {
                SetAttributeFromList.SetPathLog();
                
                Application.Run(new SetAttributeFromList());
            }
        }
    }
}
