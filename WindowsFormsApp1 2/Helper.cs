using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Helper
    {
        public static string ConnectionString = @"Data Source=" + Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf('\\')).Substring(0, Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf('\\')).LastIndexOf('\\')) + "\\messageBackup1.db";

        public static string DbFilePath = Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf('\\')).Substring(0, Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf('\\')).LastIndexOf('\\')) + "\\messageBackup1.db";
    }
}
