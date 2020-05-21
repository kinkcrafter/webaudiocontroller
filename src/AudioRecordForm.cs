using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WebAudioController
{
    public partial class AudioRecordForm : Form
    {
        private MMDeviceEnumerator deviceEnum = new MMDeviceEnumerator();
        private MMDeviceCollection inputDevices;
        private MMDevice inputDevice;
        private IWaveIn captureDevice;
        private WaveOutEvent wo = new WaveOutEvent();
        private WaveFileWriter writer;
        private AudioFileReader afr;
        private string outputFilename;
        private int volume;
        private string outputFolder;

        public AudioRecordForm(string recordingFolder)
        {
            outputFolder = recordingFolder;
            Directory.CreateDirectory(outputFolder);

            InitializeComponent();
            Disposed += OnRecordingPanelDisposed;

            inputDevices = deviceEnum.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);

            if(inputDevices.Count < 1)
            {
                MessageBox.Show($"There are no Audio Input devices available!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }

            inputDevice = inputDevices[0];

            buttonStartRecording.Enabled = false;
            buttonStopRecording.Enabled = false;
            buttonPlay.Enabled = false;

            LoadFiles(outputFolder);

            comboBoxVoiceSelector.DataSource = inputDevices.ToList();
            comboBoxVoiceSelector.DisplayMember = "FriendlyName";
            comboBoxVoiceSelector.SelectedIndex = 0;
        }

        private void LoadFiles(string outputFolder)
        {
            List<string> files = Directory.GetFiles(outputFolder).Select(x => { return x.Substring(x.LastIndexOf('\\') + 1 ); }).Where(x => x.EndsWith(".wav")).ToList();

            listBoxRecordings.Items.AddRange(files.ToArray());
        }

        void OnRecordingPanelDisposed(object sender, EventArgs e)
        {
            Cleanup();
        }

        private void OnButtonStartRecordingClick(object sender, EventArgs e)
        {
            if(writer != null)
            {
                writer.Close();
                writer.Dispose();
                writer = null;
            }

            DisableButtons();
            buttonStopRecording.Enabled = true;

            captureDevice = new WaveIn();

            captureDevice.DataAvailable += OnDataAvailable;
            captureDevice.RecordingStopped += OnRecordingStopped;

            inputDevice.AudioEndpointVolume.Mute = false;

            outputFilename = $"{recordingNameText.Text}.wav";
            writer = new WaveFileWriter(Path.Combine(outputFolder, outputFilename), captureDevice.WaveFormat);
            captureDevice.StartRecording();
            SetControlStates(true);
        }

        private void DisableButtons()
        {
            buttonPlay.Enabled = false;
            buttonDelete.Enabled = false;
            buttonCloseRecorder.Enabled = false;
            buttonStartRecording.Enabled = false;
        }

        private void EnableButtons()
        {
            buttonPlay.Enabled = true;
            buttonDelete.Enabled = true;
            buttonCloseRecorder.Enabled = true;
            buttonStartRecording.Enabled = true;
        }

        void OnRecordingStopped(object sender, StoppedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<StoppedEventArgs>(OnRecordingStopped), sender, e);
            }
            else
            {
                //FinalizeWaveFile();
                progressBar1.Value = 0;
                if (e.Exception != null)
                {
                    MessageBox.Show(String.Format("A problem was encountered during recording {0}",
                                                  e.Exception.Message));
                }
                int newItemIndex = listBoxRecordings.Items.Add(outputFilename);
                listBoxRecordings.SelectedIndex = newItemIndex;
                SetControlStates(false);
            }
            EnableButtons();
            buttonStopRecording.Enabled = false;
        }

        private void Cleanup()
        {
            if (captureDevice != null)
            {
                captureDevice.Dispose();
                captureDevice = null;
            }
            FinalizeWaveFile();
        }

        private void FinalizeWaveFile()
        {
            writer?.Dispose();
            writer = null;
        }

        void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            if (InvokeRequired)
            {
                //Debug.WriteLine("Data Available");
                BeginInvoke(new EventHandler<WaveInEventArgs>(OnDataAvailable), sender, e);
            }
            else
            {
                //Debug.WriteLine("Flushing Data Available");
                writer.Write(e.Buffer, 0, e.BytesRecorded);
                int secondsRecorded = (int)(writer.Length / writer.WaveFormat.AverageBytesPerSecond);
                if (secondsRecorded >= 60)
                {
                    StopRecording();

                    volume = 0;
                }
                else
                {
                    progressBar1.Value = secondsRecorded;

                    volume = (int)(inputDevice.AudioMeterInformation.MasterPeakValue * 100);
                }
            }
        }

        void StopRecording()
        {
            Debug.WriteLine("StopRecording");
            captureDevice?.StopRecording();

            Cleanup();

            volume = 0;
        }

        private void OnButtonStopRecordingClick(object sender, EventArgs e)
        {
            StopRecording();
        }

        private void OnButtonPlayClick(object sender, EventArgs e)
        {
            DisableButtons();
            if (listBoxRecordings.SelectedItem != null)
            {
                if(writer != null)
                {
                    writer.Close();
                    writer.Dispose();
                    writer = null;
                }

                afr = new AudioFileReader(Path.Combine(outputFolder, (string)listBoxRecordings.SelectedItem));
                wo = new WaveOutEvent();

                wo.Init(afr);
                wo.Play();
                wo.PlaybackStopped += waveOutStopped;
            }
        }

        private void waveOutStopped(object sender, StoppedEventArgs e)
        {
            wo.Dispose();

            afr.Dispose();

            EnableButtons();

            volume = 0;
        }

        private void SetControlStates(bool isRecording)
        {
            buttonStartRecording.Enabled = !isRecording;
            buttonStopRecording.Enabled = isRecording;
        }

        private void OnButtonDeleteClick(object sender, EventArgs e)
        {
            if (listBoxRecordings.SelectedItem != null)
            {
                try
                {
                    if(writer != null)
                    {
                        writer.Close();
                        writer.Dispose();
                        writer = null;
                    }
                    if(afr != null)
                    {
                        afr.Close();
                        afr.Dispose();
                        afr = null;
                    }

                    File.Delete(Path.Combine(outputFolder, (string)listBoxRecordings.SelectedItem));
                    listBoxRecordings.Items.Remove(listBoxRecordings.SelectedItem);

                    if (listBoxRecordings.Items.Count > 0)
                    {
                        listBoxRecordings.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not delete recording: {ex}");
                }
            }
        }

        private void OnCloseRecorder(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RecordingName_TextChanged(object sender, EventArgs e)
        {
            var fileName = ((TextBox)sender).Text;

            if(fileName != string.Empty)
            {
                if(fileName.All(c => Char.IsLetterOrDigit(c) || c == ' ') && fileName.Length < 25)
                {
                    buttonStartRecording.Enabled = true;

                    // todo: clear error/helper text
                }
                else
                {
                    buttonStartRecording.Enabled = false;

                    // todo: error text here
                }
            }
            else
            {
                buttonStartRecording.Enabled = false;

                // todo: text to on valid setttings
            }
        }

        private void listBoxRecordings_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonDelete.Enabled = true;
            
            var comboSelectedItem = ((ListBox)sender).SelectedItem;

            if(comboSelectedItem != null)
            {
                var trimmed = ((string)comboSelectedItem).Substring(0, ((string)comboSelectedItem).Length - 4);

                recordingNameText.Text = trimmed;
            }

            if (comboSelectedItem != null)
            {
                    buttonPlay.Enabled = true;
            }
        }

        private void comboBoxVoiceSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputDevice = (MMDevice)comboBoxVoiceSelector.SelectedItem;
        }
    }
}