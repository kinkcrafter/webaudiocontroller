using Microsoft.Owin.Hosting;
using NAudio.Wave;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebAudioController
{
    public partial class MainForm : Form
    {
        IDisposable server;

        private static readonly string audioControllerFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WebAudioService");
        private static readonly string masterSettingsJsonFile = Path.Combine(audioControllerFolder, $"settings.json");
        private static readonly string preferencesFolder = Path.Combine(audioControllerFolder, "Preferences");
        private static readonly string recordedAudioFolder = Path.Combine(audioControllerFolder, "RecordedAudio");
        public static readonly string liveAudioFolder = Path.Combine(audioControllerFolder, "LiveAudio");

        private static MasterSettings masterSettings { get; set; }
        public static List<WACPreference> preferences { get; set; }
        public static List<string> preferenceNames { get { return preferences.Select(x => { return x.PreferenceName; }).ToList(); } }
        public static WACPreference currentPreference { get { return preferences.First(x => x.PreferenceName == masterSettings.PreferenceName); } }
        //public static WACPlaylist CurrentPlaybackPlaylist { get { return currentPreference.PlaybackPlaylists.First(x => x.PlaylistName == currentPreference.CurrentPlaybackPlaylist); } }
        //public static WACPlaylist CurrentAudioPlaylist { get { return currentPreference.AudioPlaylists.First(x => x.PlaylistName == currentPreference.CurrentAudioPlaylist); } }

        public static string StatusText;

        public MainForm()
        {
            LoadPreferences();
            InitializeComponent();
            InitializeOwin();
            InitializePage();

            foreach (InstalledVoice voice in Service.speaker.GetInstalledVoices())
            {
                voicesCmBox.Items.Add(voice.VoiceInfo.Name);
            }

            RunFirst();
        }

        private void timerStatusUpdater_Tick(object sender, EventArgs e)
        {
            if (Service.audioHandler.muted)
            {
                StatusText = $"Muted";
                return;
            }

            if (Service.audioHandler.liveVoice)
            {
                StatusText = $"Playing {NAudioHandler.currentPlayback.DisplayName}";
                return;
            }

            if (Service.audioHandler.texttospeech)
            {
                StatusText = $"Saying {Service.audioHandler.currentTTS}";
                return;
            }

            switch (Service.audioHandler.currentOutputMode)
            {
                case OutputMode.stopped:
                    {
                        StatusText = "Stopped";
                    }
                    break;
                case OutputMode.audio:
                    {
                        if (NAudioHandler.currentSong != null)
                        {
                            StatusText = $"Playing {NAudioHandler.currentSong.DisplayName}";
                        }
                        else
                        {
                            StatusText = $"Playing Audio";
                        }
                    }
                    break;
                case OutputMode.noise:
                    {
                        StatusText = $"Playing {NAudioHandler.noiseColor} Noise";
                    }
                    break;
                //case OutputMode.voiceReplay:
                //    {
                //        if (NAudioHandler.currentPlayback != null)
                //        {
                //            StatusText = $"Playing {NAudioHandler.currentPlayback.DisplayName}";
                //        }
                //        else
                //        {
                //            StatusText = "Playing Voice";
                //        }
                //    }
                //    break;
                default:
                    break;
            }

            textBoxStatus.Text = StatusText;
        }

        private void RunFirst()
        {
            currentButtonState = ButtonState.stopped;

            listBoxPlaylistFiles.DataSource = currentPreference.CurrentPlaybackPlaylistRef.Playlist;
            listBoxAudioFiles.DataSource = currentPreference.CurrentAudioPlaylistRef.Playlist;

            timerStatusUpdater.Interval = 100;
            timerStatusUpdater.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SavePeferences();
        }

        #region Startup and initialization
        private void InitializePage()
        {
            comboBoxSelectProfile.DataSource = preferenceNames;
            comboBoxSelectProfile.SelectedItem = currentPreference.PreferenceName;

            comboBoxAudioPlaylists.DataSource = currentPreference.AudioPlaylistNames;
            comboBoxAudioPlaylists.SelectedItem = currentPreference.CurrentAudioPlaylist;
            comboBoxPlaybackPlaylists.DataSource = currentPreference.PlaybackPlaylistNames;
            comboBoxPlaybackPlaylists.SelectedItem = currentPreference.CurrentPlaybackPlaylist;

            InitializePlaylistLists();

            ButtonsProfileSelectUpdate();
        }

        private void InitializePlaylistLists()
        {
            listBoxAudioFiles.DataSource = currentPreference.CurrentAudioPlaylistRef.Playlist;
            listBoxPlaylistFiles.DataSource = currentPreference.CurrentPlaybackPlaylistRef.Playlist;
        }

        private void InitializeOwin()
        {
            server = WebApp.Start<Startup>("http://*:12345");
            linkLabelWebService.Links.Add(new LinkLabel.Link() { LinkData = "http://localhost:12345" });
        }

        private static void LoadPreferences()
        {
            var userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\').Last();

            Directory.CreateDirectory(audioControllerFolder);
            Directory.CreateDirectory(preferencesFolder);
            Directory.CreateDirectory(liveAudioFolder);

            if (!File.Exists(masterSettingsJsonFile))
            {
                masterSettings = new MasterSettings() { PreferenceName = $"{userName} Profile" };
                SaveMasterSettings();
            }
            else
            {
                masterSettings = JsonConvert.DeserializeObject<MasterSettings>(File.ReadAllText(masterSettingsJsonFile));
            }

            preferences = new List<WACPreference>();

            var files = Directory.EnumerateFiles(preferencesFolder);

            if (!files.Any())
            {
                var firstPreference = CreateNewPreference(masterSettings.PreferenceName);

                preferences.Add(firstPreference);

                SaveProfiles();
            }
            else
            {
                foreach (var file in files)
                {
                    preferences.Add(JsonConvert.DeserializeObject<WACPreference>(string.Join(Environment.NewLine, File.ReadAllLines(file))));
                }
            }
        }

        private void linkLabelWebService_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }
        #endregion

        #region preferences and saving
        private static WACPreference CreateNewPreference(string preferenceName)
        {
            WACPreference newPreference = new WACPreference() { PreferenceName = preferenceName };

            newPreference.AudioPlaylists.Add(new WACPlaylist() { PlaylistName = "First Audio Playlist" });
            newPreference.CurrentAudioPlaylist = newPreference.AudioPlaylists.First().PlaylistName;
            newPreference.PlaybackPlaylists.Add(new WACPlaylist() { PlaylistName = "First Playback Playlist" });
            newPreference.CurrentPlaybackPlaylist = newPreference.PlaybackPlaylists.First().PlaylistName;

            return newPreference;
        }

        private static void SavePeferences()
        {
            SaveMasterSettings();

            SaveProfiles();
        }

        private static void SaveProfiles()
        {
            foreach (var preference in preferences)
            {
                File.WriteAllText(Path.Combine(preferencesFolder, $"{preference.PreferenceName}.json"), JsonConvert.SerializeObject(preference));
            }
        }

        private static void SaveMasterSettings()
        {
            File.WriteAllText(masterSettingsJsonFile, JsonConvert.SerializeObject(masterSettings));
        }
        #endregion

        #region Preference Handling
        private void textBoxNewProfileName_TextChanged(object sender, EventArgs e)
        {
            if (preferences.Any(x => x.PreferenceName.ToLower() == textBoxNewProfileName.Text.ToLower()) || textBoxNewProfileName.Text.Length < 4)
            {
                buttonCreateProfile.Enabled = false;
                return;
            }

            buttonCreateProfile.Enabled = true;
        }

        private void buttonLoadProfile_Click(object sender, EventArgs e)
        {
            ChangeProfile(comboBoxSelectProfile.Text);
        }

        private void buttonCreateProfile_Click(object sender, EventArgs e)
        {
            if (!preferences.Select(x => x.PreferenceName).Any(y => y.ToLower() == textBoxNewProfileName.Text.ToLower()))
            {
                var newPreference = CreateNewPreference(textBoxNewProfileName.Text);

                preferences.Add(newPreference);

                textBoxNewProfileName.Text = string.Empty;

                comboBoxSelectProfile.DataSource = preferenceNames;

                ChangeProfile(newPreference.PreferenceName);
            }

            SavePeferences();
        }

        private void ChangeProfile(string preferenceName, bool prompt = true)
        {
            DialogResult result = DialogResult.OK;
            if (prompt)
            {
                result = MessageBox.Show($"Do you want to load {preferenceName}?  It will close the current session!", "Load Profile", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            if (result == DialogResult.OK)
            {
                // todo: stop audio gracefully
                masterSettings.PreferenceName = preferenceName;

                LoadCurrentProfile();
            }
        }

        private void LoadCurrentProfile()
        {
            InitializePage();
        }

        private void buttonDeleteProfile_Click(object sender, EventArgs e)
        {
            if (preferences.Count > 1)
            {
                var selectedPreference = preferences.First(x => x.PreferenceName == comboBoxSelectProfile.SelectedItem);
                if (selectedPreference.PreferenceName == currentPreference.PreferenceName)
                {
                    var defaultPreference = preferences.First(x => x.PreferenceName != currentPreference.PreferenceName);

                    DialogResult result = MessageBox.Show($"Do you want to delete {comboBoxSelectProfile.SelectedItem}?  It is currently your active profile and will cause you to change to the {defaultPreference.PreferenceName} profile, closing your current session!", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        DeleteProfile(selectedPreference);

                        ChangeProfile(defaultPreference.PreferenceName, prompt: false);
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show($"Do you want to delete {comboBoxSelectProfile.SelectedItem}?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        DeleteProfile(selectedPreference);

                        comboBoxSelectProfile.DataSource = preferenceNames;
                    }
                }
            }
        }

        private void DeleteProfile(WACPreference profile)
        {
            preferences.Remove(profile);

            File.Delete(Path.Combine(preferencesFolder, $"{profile.PreferenceName}.json"));
        }

        private void comboBoxSelectProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButtonsProfileSelectUpdate();
        }
        #endregion

        #region Control Enable State Handling
        ButtonState currentButtonState = ButtonState.disableAll;
        ButtonState previousButtonState = ButtonState.disableAll;

        private void ButtonsProfileSelectUpdate()
        {
            if (comboBoxSelectProfile.SelectedItem == currentPreference.PreferenceName)
            {
                buttonLoadProfile.Enabled = false;
            }
            else
            {
                buttonLoadProfile.Enabled = true;
            }

            if (preferences.Count > 1 && currentButtonState != ButtonState.disableAll && currentButtonState != ButtonState.transition)
            {
                buttonDeleteProfile.Enabled = true;
            }
            else
            {
                buttonDeleteProfile.Enabled = false;
            }
        }

        private void ButtonsAudioPlaylistSelectUpdate()
        {
            if (currentPreference.AudioPlaylists.Count > 1 && currentButtonState != ButtonState.disableAll && currentButtonState != ButtonState.transition)
            {
                buttonDeleteAudioPlaylist.Enabled = true;
            }
            else
            {
                buttonDeleteAudioPlaylist.Enabled = false;
            }
        }

        private void ButtonsPlaybackPlaylistSelectUpdate()
        {
            if (currentPreference.PlaybackPlaylists.Count > 1 && currentButtonState != ButtonState.disableAll && currentButtonState != ButtonState.transition)
            {
                buttonDeletePlaybackPlaylist.Enabled = true;
            }
            else
            {
                buttonDeletePlaybackPlaylist.Enabled = false;
            }
        }
        #endregion

        #region Playback Playlist Handling
        private void comboBoxPlaybackPlaylists_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPreference.CurrentPlaybackPlaylist = (string)comboBoxPlaybackPlaylists.SelectedItem;

            InitializePlaylistLists();

            ButtonsPlaybackPlaylistSelectUpdate();
        }

        private void textBoxNewPlaybackPlaylistName_TextChanged(object sender, EventArgs e)
        {
            if (currentPreference.PlaybackPlaylistNames.Any(x => x.ToLower() == textBoxNewPlaybackPlaylistName.Text.ToLower()) || textBoxNewPlaybackPlaylistName.Text.Length < 4)
            {
                buttonCreateNewPlaybackPlaylist.Enabled = false;
                return;
            }

            buttonCreateNewPlaybackPlaylist.Enabled = true;
        }

        private void buttonDeletePlaybackPlaylist_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"Do you want to delete the {comboBoxPlaybackPlaylists.SelectedItem} playlist", "Delete Playlist", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                var playlistToRemove = currentPreference.PlaybackPlaylists.First(x => x.PlaylistName == comboBoxPlaybackPlaylists.SelectedItem);
                currentPreference.PlaybackPlaylists.Remove(playlistToRemove);
                InitializePage();
            }
        }

        private void buttonCreateNewPlaybackPlaylist_Click(object sender, EventArgs e)
        {
            currentPreference.PlaybackPlaylists.Add(new WACPlaylist() { PlaylistName = textBoxNewPlaybackPlaylistName.Text });
            currentPreference.CurrentPlaybackPlaylist = textBoxNewPlaybackPlaylistName.Text;
            textBoxNewPlaybackPlaylistName.Text = string.Empty;
            InitializePage();
        }

        private void buttonPlaylistMoveToTop_Click(object sender, EventArgs e)
        {
            currentPreference.CurrentPlaybackPlaylistRef.MoveFileToFront(listBoxPlaylistFiles.SelectedIndex);
            listBoxPlaylistFiles.DataSource = currentPreference.CurrentPlaybackPlaylistRef.Playlist;
        }

        private void buttonPlaylistMoveUp_Click(object sender, EventArgs e)
        {
            currentPreference.CurrentPlaybackPlaylistRef.MoveFileUp(listBoxPlaylistFiles.SelectedIndex);
            listBoxPlaylistFiles.DataSource = currentPreference.CurrentPlaybackPlaylistRef.Playlist;
        }

        private void buttonPlaylistMoveDown_Click(object sender, EventArgs e)
        {
            currentPreference.CurrentPlaybackPlaylistRef.MoveFileDown(listBoxPlaylistFiles.SelectedIndex);
            listBoxPlaylistFiles.DataSource = currentPreference.CurrentPlaybackPlaylistRef.Playlist;
        }

        private void buttonPlaylistMoveToBottom_Click(object sender, EventArgs e)
        {
            currentPreference.CurrentPlaybackPlaylistRef.MoveFileToEnd(listBoxPlaylistFiles.SelectedIndex);
            listBoxPlaylistFiles.DataSource = currentPreference.CurrentPlaybackPlaylistRef.Playlist;
        }

        private void buttonPlaylistAddFile_Click(object sender, EventArgs e)
        {
            AddFile fileAdder = new AddFile(currentPreference.CurrentPlaybackPlaylistRef, listBoxPlaylistFiles, recordedAudioFolder);
            fileAdder.Show();
        }

        private void buttonPlaylistRemoveFile_Click(object sender, EventArgs e)
        {
            if (listBoxPlaylistFiles.SelectedItem != null)
            {
                currentPreference.CurrentPlaybackPlaylistRef.RemoveFile(listBoxPlaylistFiles.SelectedIndex);
                listBoxPlaylistFiles.DataSource = currentPreference.CurrentPlaybackPlaylistRef.Playlist;
                // todo: refresh buttons
            }
        }

        private void listBoxPlaylistFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fileCount = listBoxPlaylistFiles.Items.Count;

            if (fileCount <= 1)
            {
                buttonPlaylistMoveToTop.Enabled = false;
                buttonPlaylistMoveUp.Enabled = false;
                buttonPlaylistMoveDown.Enabled = false;
                buttonPlaylistMoveToBottom.Enabled = false;
            }
            else if (listBoxPlaylistFiles.SelectedItem != null)
            {
                var selectedIndex = listBoxPlaylistFiles.SelectedIndex;

                if (selectedIndex == 0)
                {
                    buttonPlaylistMoveToTop.Enabled = false;
                    buttonPlaylistMoveUp.Enabled = false;
                }
                else
                {
                    buttonPlaylistMoveToTop.Enabled = true;
                    buttonPlaylistMoveUp.Enabled = true;
                }

                if (selectedIndex == fileCount - 1)
                {
                    buttonPlaylistMoveDown.Enabled = false;
                    buttonPlaylistMoveToBottom.Enabled = false;
                }
                else
                {
                    buttonPlaylistMoveDown.Enabled = true;
                    buttonPlaylistMoveToBottom.Enabled = true;
                }
            }
        }
        #endregion

        #region Audio Playlist Handling
        private void comboBoxAudioPlaylists_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPreference.CurrentAudioPlaylist = (string)comboBoxAudioPlaylists.SelectedItem;

            InitializePlaylistLists();
            ButtonsAudioPlaylistSelectUpdate();
        }

        private void textBoxNewAudioPlaylistName_TextChanged(object sender, EventArgs e)
        {
            if (currentPreference.AudioPlaylistNames.Any(x => x.ToLower() == textBoxNewAudioPlaylistName.Text.ToLower()) || textBoxNewAudioPlaylistName.Text.Length < 4)
            {
                buttonCreateNewAudioPlaylist.Enabled = false;
                return;
            }

            buttonCreateNewAudioPlaylist.Enabled = true;
        }

        private void buttonDeleteAudioPlaylist_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"Do you want to delete the {comboBoxAudioPlaylists.SelectedItem} playlist", "Delete Playlist", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                var playlistToRemove = currentPreference.AudioPlaylists.First(x => x.PlaylistName == comboBoxAudioPlaylists.SelectedItem);
                currentPreference.AudioPlaylists.Remove(playlistToRemove);
                InitializePage();
            }
        }

        private void buttonCreateNewAudioPlaylist_Click(object sender, EventArgs e)
        {
            currentPreference.AudioPlaylists.Add(new WACPlaylist() { PlaylistName = textBoxNewAudioPlaylistName.Text });
            currentPreference.CurrentAudioPlaylist = textBoxNewAudioPlaylistName.Text;
            textBoxNewAudioPlaylistName.Text = string.Empty;
            InitializePage();
        }

        private void buttonAudioMoveToTop_Click(object sender, EventArgs e)
        {
            currentPreference.CurrentAudioPlaylistRef.MoveFileToFront(listBoxAudioFiles.SelectedIndex);
            listBoxAudioFiles.DataSource = currentPreference.CurrentAudioPlaylistRef.Playlist;
            // todo: refresh
        }

        private void buttonAudioMoveUp_Click(object sender, EventArgs e)
        {
            currentPreference.CurrentAudioPlaylistRef.MoveFileUp(listBoxAudioFiles.SelectedIndex);
            listBoxAudioFiles.DataSource = currentPreference.CurrentAudioPlaylistRef.Playlist;
        }

        private void buttonAudioMoveDown_Click(object sender, EventArgs e)
        {
            currentPreference.CurrentAudioPlaylistRef.MoveFileDown(listBoxAudioFiles.SelectedIndex);
            listBoxAudioFiles.DataSource = currentPreference.CurrentAudioPlaylistRef.Playlist;
        }

        private void buttonAudioMoveToBottom_Click(object sender, EventArgs e)
        {
            currentPreference.CurrentAudioPlaylistRef.MoveFileToEnd(listBoxAudioFiles.SelectedIndex);
            listBoxAudioFiles.DataSource = currentPreference.CurrentAudioPlaylistRef.Playlist;
        }

        private void buttonAudioAddFile_Click(object sender, EventArgs e)
        {
            AddFile fileAdder = new AddFile(currentPreference.CurrentAudioPlaylistRef, listBoxAudioFiles);
            fileAdder.Show();
        }

        private void buttonAudioRemoveFile_Click(object sender, EventArgs e)
        {
            if (listBoxAudioFiles.SelectedItem != null)
            {
                currentPreference.CurrentAudioPlaylistRef.RemoveFile(listBoxAudioFiles.SelectedIndex);
                listBoxAudioFiles.DataSource = currentPreference.CurrentAudioPlaylistRef.Playlist;
                // todo: refresh buttons
            }
        }

        private void listBoxAudioFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fileCount = listBoxAudioFiles.Items.Count;

            if (fileCount <= 1)
            {
                buttonAudioMoveToTop.Enabled = false;
                buttonAudioMoveUp.Enabled = false;
                buttonAudioMoveDown.Enabled = false;
                buttonAudioMoveToBottom.Enabled = false;
            }
            else if (listBoxAudioFiles.SelectedItem != null)
            {
                var selectedIndex = listBoxAudioFiles.SelectedIndex;

                if (selectedIndex == 0)
                {
                    buttonAudioMoveToTop.Enabled = false;
                    buttonAudioMoveUp.Enabled = false;
                }
                else
                {
                    buttonAudioMoveToTop.Enabled = true;
                    buttonAudioMoveUp.Enabled = true;
                }

                if (selectedIndex == fileCount - 1)
                {
                    buttonAudioMoveDown.Enabled = false;
                    buttonAudioMoveToBottom.Enabled = false;
                }
                else
                {
                    buttonAudioMoveDown.Enabled = true;
                    buttonAudioMoveToBottom.Enabled = true;
                }
            }
        }
        #endregion

        private void buttonRecording_Click(object sender, EventArgs e)
        {
            AudioRecordForm audioRecordingForm = new AudioRecordForm(recordedAudioFolder);
            audioRecordingForm.Show();
        }

        private void voicesCmBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Service.speaker.SelectVoice((string)voicesCmBox.SelectedItem);
        }
    }

    public enum ButtonState
    {
        disableAll,
        stopped,
        talking,
        voice,
        noise,
        audio,
        transition
    }
}