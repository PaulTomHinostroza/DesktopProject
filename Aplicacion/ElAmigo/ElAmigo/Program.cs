﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElAmigo
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
            //Application.Run(new frmVentanaPrincipal());
            Application.Run(new frmLogin());
            if (mdlVariables.MiEmpleadoConectado != null)
            {
                Application.Run(new frmVentanaPrincipal());
            }
        }
    }
}
