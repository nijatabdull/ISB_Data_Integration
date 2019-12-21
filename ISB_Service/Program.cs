using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;

namespace ISB_Service
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
            Application.SetCompatibleTextRenderingDefault(true);

            string value = ConfigurationManager.AppSettings["InsuranceType"];

            if (value.ToString()== "qeyri-heyat")
                Application.Run(new Service());
            else if(value.ToString() == "heyat")
                Application.Run(new Life_Insurance());
            
        }
    }
}
