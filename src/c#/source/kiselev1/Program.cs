using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace kiselev1
{
    static class Program
    {
        public static Form1 Form1
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public static Form1 Form11
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public static Form1 Form12
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
