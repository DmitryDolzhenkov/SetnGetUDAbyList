using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SetnGetAttribute
{
    public static class Logger
    {
        /// <summary>
        /// write message of exception to temp
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="ex">exception</param>
        public static void WriteExMessage2Temp(string filePath, Exception ex)
        {
            

            using (StreamWriter writer = new StreamWriter(filePath, true, SetAttributeFromList.enc))
            {
                writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                   "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }

    }
}
