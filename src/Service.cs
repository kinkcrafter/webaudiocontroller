using Microsoft.Owin.Hosting;
using NAudio.Wave;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebAudioController
{
    static class Service
    {
        internal static NAudioHandler audioHandler;

        internal static SpeechSynthesizer speaker;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /// Boot up our core audio handler
            audioHandler = new NAudioHandler();

            speaker = new SpeechSynthesizer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}