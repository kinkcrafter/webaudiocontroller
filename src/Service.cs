using Microsoft.Owin.Hosting;
using NAudio.Wave;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebAudioController
{
    static class Service
    {
        internal static NAudioHandler audioHandler;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /// Boot up our core audio handler
            audioHandler = new NAudioHandler();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}