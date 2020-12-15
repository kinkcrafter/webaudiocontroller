namespace WebAudioController
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.linkLabelWebService = new System.Windows.Forms.LinkLabel();
            this.groupBoxVoiceNoise = new System.Windows.Forms.GroupBox();
            this.buttonRecording = new System.Windows.Forms.Button();
            this.buttonPlaylistRemoveFile = new System.Windows.Forms.Button();
            this.buttonPlaylistAddFile = new System.Windows.Forms.Button();
            this.buttonPlaylistMoveToBottom = new System.Windows.Forms.Button();
            this.buttonPlaylistMoveDown = new System.Windows.Forms.Button();
            this.buttonPlaylistMoveUp = new System.Windows.Forms.Button();
            this.buttonPlaylistMoveToTop = new System.Windows.Forms.Button();
            this.listBoxPlaylistFiles = new System.Windows.Forms.ListBox();
            this.buttonDeletePlaybackPlaylist = new System.Windows.Forms.Button();
            this.comboBoxPlaybackPlaylists = new System.Windows.Forms.ComboBox();
            this.buttonCreateNewPlaybackPlaylist = new System.Windows.Forms.Button();
            this.textBoxNewPlaybackPlaylistName = new System.Windows.Forms.TextBox();
            this.groupBoxAudio = new System.Windows.Forms.GroupBox();
            this.buttonAudioRemoveFile = new System.Windows.Forms.Button();
            this.listBoxAudioFiles = new System.Windows.Forms.ListBox();
            this.buttonAudioAddFile = new System.Windows.Forms.Button();
            this.buttonDeleteAudioPlaylist = new System.Windows.Forms.Button();
            this.buttonAudioMoveToBottom = new System.Windows.Forms.Button();
            this.comboBoxAudioPlaylists = new System.Windows.Forms.ComboBox();
            this.buttonAudioMoveDown = new System.Windows.Forms.Button();
            this.textBoxNewAudioPlaylistName = new System.Windows.Forms.TextBox();
            this.buttonAudioMoveUp = new System.Windows.Forms.Button();
            this.buttonAudioMoveToTop = new System.Windows.Forms.Button();
            this.buttonCreateNewAudioPlaylist = new System.Windows.Forms.Button();
            this.comboBoxSelectProfile = new System.Windows.Forms.ComboBox();
            this.buttonCreateProfile = new System.Windows.Forms.Button();
            this.textBoxNewProfileName = new System.Windows.Forms.TextBox();
            this.buttonLoadProfile = new System.Windows.Forms.Button();
            this.buttonDeleteProfile = new System.Windows.Forms.Button();
            this.timerStatusUpdater = new System.Windows.Forms.Timer(this.components);
            this.voicesCmBox = new System.Windows.Forms.ComboBox();
            this.groupBoxVoiceNoise.SuspendLayout();
            this.groupBoxAudio.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStatus.Location = new System.Drawing.Point(8, 8);
            this.textBoxStatus.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(1269, 98);
            this.textBoxStatus.TabIndex = 0;
            this.textBoxStatus.Text = "Starting Service...";
            this.textBoxStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // linkLabelWebService
            // 
            this.linkLabelWebService.AutoSize = true;
            this.linkLabelWebService.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelWebService.Location = new System.Drawing.Point(4, 68);
            this.linkLabelWebService.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabelWebService.Name = "linkLabelWebService";
            this.linkLabelWebService.Size = new System.Drawing.Size(479, 63);
            this.linkLabelWebService.TabIndex = 1;
            this.linkLabelWebService.TabStop = true;
            this.linkLabelWebService.Text = "Open Web Service";
            this.linkLabelWebService.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelWebService_LinkClicked);
            // 
            // groupBoxVoiceNoise
            // 
            this.groupBoxVoiceNoise.Controls.Add(this.voicesCmBox);
            this.groupBoxVoiceNoise.Controls.Add(this.buttonRecording);
            this.groupBoxVoiceNoise.Controls.Add(this.buttonPlaylistRemoveFile);
            this.groupBoxVoiceNoise.Controls.Add(this.buttonPlaylistAddFile);
            this.groupBoxVoiceNoise.Controls.Add(this.buttonPlaylistMoveToBottom);
            this.groupBoxVoiceNoise.Controls.Add(this.buttonPlaylistMoveDown);
            this.groupBoxVoiceNoise.Controls.Add(this.buttonPlaylistMoveUp);
            this.groupBoxVoiceNoise.Controls.Add(this.buttonPlaylistMoveToTop);
            this.groupBoxVoiceNoise.Controls.Add(this.listBoxPlaylistFiles);
            this.groupBoxVoiceNoise.Controls.Add(this.buttonDeletePlaybackPlaylist);
            this.groupBoxVoiceNoise.Controls.Add(this.comboBoxPlaybackPlaylists);
            this.groupBoxVoiceNoise.Controls.Add(this.buttonCreateNewPlaybackPlaylist);
            this.groupBoxVoiceNoise.Controls.Add(this.textBoxNewPlaybackPlaylistName);
            this.groupBoxVoiceNoise.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxVoiceNoise.Location = new System.Drawing.Point(8, 125);
            this.groupBoxVoiceNoise.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxVoiceNoise.Name = "groupBoxVoiceNoise";
            this.groupBoxVoiceNoise.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxVoiceNoise.Size = new System.Drawing.Size(627, 853);
            this.groupBoxVoiceNoise.TabIndex = 2;
            this.groupBoxVoiceNoise.TabStop = false;
            this.groupBoxVoiceNoise.Text = "Voice and Noise";
            // 
            // buttonRecording
            // 
            this.buttonRecording.Location = new System.Drawing.Point(496, 39);
            this.buttonRecording.Name = "buttonRecording";
            this.buttonRecording.Size = new System.Drawing.Size(124, 35);
            this.buttonRecording.TabIndex = 20;
            this.buttonRecording.Text = "Recording";
            this.buttonRecording.UseVisualStyleBackColor = true;
            this.buttonRecording.Click += new System.EventHandler(this.buttonRecording_Click);
            // 
            // buttonPlaylistRemoveFile
            // 
            this.buttonPlaylistRemoveFile.Location = new System.Drawing.Point(545, 387);
            this.buttonPlaylistRemoveFile.Name = "buttonPlaylistRemoveFile";
            this.buttonPlaylistRemoveFile.Size = new System.Drawing.Size(75, 46);
            this.buttonPlaylistRemoveFile.TabIndex = 19;
            this.buttonPlaylistRemoveFile.Text = "-";
            this.buttonPlaylistRemoveFile.UseVisualStyleBackColor = true;
            this.buttonPlaylistRemoveFile.Click += new System.EventHandler(this.buttonPlaylistRemoveFile_Click);
            // 
            // buttonPlaylistAddFile
            // 
            this.buttonPlaylistAddFile.Location = new System.Drawing.Point(545, 335);
            this.buttonPlaylistAddFile.Name = "buttonPlaylistAddFile";
            this.buttonPlaylistAddFile.Size = new System.Drawing.Size(75, 46);
            this.buttonPlaylistAddFile.TabIndex = 18;
            this.buttonPlaylistAddFile.Text = "+";
            this.buttonPlaylistAddFile.UseVisualStyleBackColor = true;
            this.buttonPlaylistAddFile.Click += new System.EventHandler(this.buttonPlaylistAddFile_Click);
            // 
            // buttonPlaylistMoveToBottom
            // 
            this.buttonPlaylistMoveToBottom.Location = new System.Drawing.Point(545, 283);
            this.buttonPlaylistMoveToBottom.Name = "buttonPlaylistMoveToBottom";
            this.buttonPlaylistMoveToBottom.Size = new System.Drawing.Size(75, 46);
            this.buttonPlaylistMoveToBottom.TabIndex = 17;
            this.buttonPlaylistMoveToBottom.Text = "\\\\//";
            this.buttonPlaylistMoveToBottom.UseVisualStyleBackColor = true;
            this.buttonPlaylistMoveToBottom.Click += new System.EventHandler(this.buttonPlaylistMoveToBottom_Click);
            // 
            // buttonPlaylistMoveDown
            // 
            this.buttonPlaylistMoveDown.Location = new System.Drawing.Point(545, 231);
            this.buttonPlaylistMoveDown.Name = "buttonPlaylistMoveDown";
            this.buttonPlaylistMoveDown.Size = new System.Drawing.Size(75, 46);
            this.buttonPlaylistMoveDown.TabIndex = 16;
            this.buttonPlaylistMoveDown.Text = "\\/";
            this.buttonPlaylistMoveDown.UseVisualStyleBackColor = true;
            this.buttonPlaylistMoveDown.Click += new System.EventHandler(this.buttonPlaylistMoveDown_Click);
            // 
            // buttonPlaylistMoveUp
            // 
            this.buttonPlaylistMoveUp.Location = new System.Drawing.Point(545, 179);
            this.buttonPlaylistMoveUp.Name = "buttonPlaylistMoveUp";
            this.buttonPlaylistMoveUp.Size = new System.Drawing.Size(75, 46);
            this.buttonPlaylistMoveUp.TabIndex = 15;
            this.buttonPlaylistMoveUp.Text = "/\\";
            this.buttonPlaylistMoveUp.UseVisualStyleBackColor = true;
            this.buttonPlaylistMoveUp.Click += new System.EventHandler(this.buttonPlaylistMoveUp_Click);
            // 
            // buttonPlaylistMoveToTop
            // 
            this.buttonPlaylistMoveToTop.Location = new System.Drawing.Point(545, 127);
            this.buttonPlaylistMoveToTop.Name = "buttonPlaylistMoveToTop";
            this.buttonPlaylistMoveToTop.Size = new System.Drawing.Size(75, 46);
            this.buttonPlaylistMoveToTop.TabIndex = 14;
            this.buttonPlaylistMoveToTop.Text = "//\\\\";
            this.buttonPlaylistMoveToTop.UseVisualStyleBackColor = true;
            this.buttonPlaylistMoveToTop.Click += new System.EventHandler(this.buttonPlaylistMoveToTop_Click);
            // 
            // listBoxPlaylistFiles
            // 
            this.listBoxPlaylistFiles.DisplayMember = "DisplayName";
            this.listBoxPlaylistFiles.FormattingEnabled = true;
            this.listBoxPlaylistFiles.ItemHeight = 46;
            this.listBoxPlaylistFiles.Location = new System.Drawing.Point(13, 127);
            this.listBoxPlaylistFiles.Name = "listBoxPlaylistFiles";
            this.listBoxPlaylistFiles.Size = new System.Drawing.Size(525, 694);
            this.listBoxPlaylistFiles.TabIndex = 13;
            this.listBoxPlaylistFiles.SelectedIndexChanged += new System.EventHandler(this.listBoxPlaylistFiles_SelectedIndexChanged);
            // 
            // buttonDeletePlaybackPlaylist
            // 
            this.buttonDeletePlaybackPlaylist.Location = new System.Drawing.Point(329, 39);
            this.buttonDeletePlaybackPlaylist.Name = "buttonDeletePlaybackPlaylist";
            this.buttonDeletePlaybackPlaylist.Size = new System.Drawing.Size(151, 35);
            this.buttonDeletePlaybackPlaylist.TabIndex = 12;
            this.buttonDeletePlaybackPlaylist.Text = "Delete Playlist";
            this.buttonDeletePlaybackPlaylist.UseVisualStyleBackColor = true;
            this.buttonDeletePlaybackPlaylist.Click += new System.EventHandler(this.buttonDeletePlaybackPlaylist_Click);
            // 
            // comboBoxPlaybackPlaylists
            // 
            this.comboBoxPlaybackPlaylists.FormattingEnabled = true;
            this.comboBoxPlaybackPlaylists.Location = new System.Drawing.Point(13, 39);
            this.comboBoxPlaybackPlaylists.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxPlaybackPlaylists.Name = "comboBoxPlaybackPlaylists";
            this.comboBoxPlaybackPlaylists.Size = new System.Drawing.Size(302, 54);
            this.comboBoxPlaybackPlaylists.TabIndex = 0;
            this.comboBoxPlaybackPlaylists.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlaybackPlaylists_SelectedIndexChanged);
            // 
            // buttonCreateNewPlaybackPlaylist
            // 
            this.buttonCreateNewPlaybackPlaylist.Enabled = false;
            this.buttonCreateNewPlaybackPlaylist.Location = new System.Drawing.Point(329, 80);
            this.buttonCreateNewPlaybackPlaylist.Name = "buttonCreateNewPlaybackPlaylist";
            this.buttonCreateNewPlaybackPlaylist.Size = new System.Drawing.Size(162, 35);
            this.buttonCreateNewPlaybackPlaylist.TabIndex = 9;
            this.buttonCreateNewPlaybackPlaylist.Text = "Create Playlist";
            this.buttonCreateNewPlaybackPlaylist.UseVisualStyleBackColor = true;
            this.buttonCreateNewPlaybackPlaylist.Click += new System.EventHandler(this.buttonCreateNewPlaybackPlaylist_Click);
            // 
            // textBoxNewPlaybackPlaylistName
            // 
            this.textBoxNewPlaybackPlaylistName.Location = new System.Drawing.Point(13, 77);
            this.textBoxNewPlaybackPlaylistName.Name = "textBoxNewPlaybackPlaylistName";
            this.textBoxNewPlaybackPlaylistName.Size = new System.Drawing.Size(302, 53);
            this.textBoxNewPlaybackPlaylistName.TabIndex = 10;
            this.textBoxNewPlaybackPlaylistName.TextChanged += new System.EventHandler(this.textBoxNewPlaybackPlaylistName_TextChanged);
            // 
            // groupBoxAudio
            // 
            this.groupBoxAudio.Controls.Add(this.buttonAudioRemoveFile);
            this.groupBoxAudio.Controls.Add(this.listBoxAudioFiles);
            this.groupBoxAudio.Controls.Add(this.buttonAudioAddFile);
            this.groupBoxAudio.Controls.Add(this.buttonDeleteAudioPlaylist);
            this.groupBoxAudio.Controls.Add(this.buttonAudioMoveToBottom);
            this.groupBoxAudio.Controls.Add(this.comboBoxAudioPlaylists);
            this.groupBoxAudio.Controls.Add(this.buttonAudioMoveDown);
            this.groupBoxAudio.Controls.Add(this.textBoxNewAudioPlaylistName);
            this.groupBoxAudio.Controls.Add(this.buttonAudioMoveUp);
            this.groupBoxAudio.Controls.Add(this.buttonAudioMoveToTop);
            this.groupBoxAudio.Controls.Add(this.buttonCreateNewAudioPlaylist);
            this.groupBoxAudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAudio.Location = new System.Drawing.Point(649, 125);
            this.groupBoxAudio.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxAudio.Name = "groupBoxAudio";
            this.groupBoxAudio.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxAudio.Size = new System.Drawing.Size(628, 853);
            this.groupBoxAudio.TabIndex = 3;
            this.groupBoxAudio.TabStop = false;
            this.groupBoxAudio.Text = "Audio";
            // 
            // buttonAudioRemoveFile
            // 
            this.buttonAudioRemoveFile.Location = new System.Drawing.Point(542, 387);
            this.buttonAudioRemoveFile.Name = "buttonAudioRemoveFile";
            this.buttonAudioRemoveFile.Size = new System.Drawing.Size(75, 46);
            this.buttonAudioRemoveFile.TabIndex = 25;
            this.buttonAudioRemoveFile.Text = "-";
            this.buttonAudioRemoveFile.UseVisualStyleBackColor = true;
            this.buttonAudioRemoveFile.Click += new System.EventHandler(this.buttonAudioRemoveFile_Click);
            // 
            // listBoxAudioFiles
            // 
            this.listBoxAudioFiles.DisplayMember = "DisplayName";
            this.listBoxAudioFiles.FormattingEnabled = true;
            this.listBoxAudioFiles.ItemHeight = 46;
            this.listBoxAudioFiles.Location = new System.Drawing.Point(11, 127);
            this.listBoxAudioFiles.Name = "listBoxAudioFiles";
            this.listBoxAudioFiles.Size = new System.Drawing.Size(525, 694);
            this.listBoxAudioFiles.TabIndex = 14;
            this.listBoxAudioFiles.SelectedIndexChanged += new System.EventHandler(this.listBoxAudioFiles_SelectedIndexChanged);
            // 
            // buttonAudioAddFile
            // 
            this.buttonAudioAddFile.Location = new System.Drawing.Point(542, 335);
            this.buttonAudioAddFile.Name = "buttonAudioAddFile";
            this.buttonAudioAddFile.Size = new System.Drawing.Size(75, 46);
            this.buttonAudioAddFile.TabIndex = 24;
            this.buttonAudioAddFile.Text = "+";
            this.buttonAudioAddFile.UseVisualStyleBackColor = true;
            this.buttonAudioAddFile.Click += new System.EventHandler(this.buttonAudioAddFile_Click);
            // 
            // buttonDeleteAudioPlaylist
            // 
            this.buttonDeleteAudioPlaylist.Location = new System.Drawing.Point(327, 39);
            this.buttonDeleteAudioPlaylist.Name = "buttonDeleteAudioPlaylist";
            this.buttonDeleteAudioPlaylist.Size = new System.Drawing.Size(151, 35);
            this.buttonDeleteAudioPlaylist.TabIndex = 17;
            this.buttonDeleteAudioPlaylist.Text = "Delete Playlist";
            this.buttonDeleteAudioPlaylist.UseVisualStyleBackColor = true;
            this.buttonDeleteAudioPlaylist.Click += new System.EventHandler(this.buttonDeleteAudioPlaylist_Click);
            // 
            // buttonAudioMoveToBottom
            // 
            this.buttonAudioMoveToBottom.Location = new System.Drawing.Point(542, 283);
            this.buttonAudioMoveToBottom.Name = "buttonAudioMoveToBottom";
            this.buttonAudioMoveToBottom.Size = new System.Drawing.Size(75, 46);
            this.buttonAudioMoveToBottom.TabIndex = 23;
            this.buttonAudioMoveToBottom.Text = "\\\\//";
            this.buttonAudioMoveToBottom.UseVisualStyleBackColor = true;
            this.buttonAudioMoveToBottom.Click += new System.EventHandler(this.buttonAudioMoveToBottom_Click);
            // 
            // comboBoxAudioPlaylists
            // 
            this.comboBoxAudioPlaylists.FormattingEnabled = true;
            this.comboBoxAudioPlaylists.Location = new System.Drawing.Point(11, 37);
            this.comboBoxAudioPlaylists.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxAudioPlaylists.Name = "comboBoxAudioPlaylists";
            this.comboBoxAudioPlaylists.Size = new System.Drawing.Size(302, 54);
            this.comboBoxAudioPlaylists.TabIndex = 13;
            this.comboBoxAudioPlaylists.SelectedIndexChanged += new System.EventHandler(this.comboBoxAudioPlaylists_SelectedIndexChanged);
            // 
            // buttonAudioMoveDown
            // 
            this.buttonAudioMoveDown.Location = new System.Drawing.Point(542, 231);
            this.buttonAudioMoveDown.Name = "buttonAudioMoveDown";
            this.buttonAudioMoveDown.Size = new System.Drawing.Size(75, 46);
            this.buttonAudioMoveDown.TabIndex = 22;
            this.buttonAudioMoveDown.Text = "\\/";
            this.buttonAudioMoveDown.UseVisualStyleBackColor = true;
            this.buttonAudioMoveDown.Click += new System.EventHandler(this.buttonAudioMoveDown_Click);
            // 
            // textBoxNewAudioPlaylistName
            // 
            this.textBoxNewAudioPlaylistName.Location = new System.Drawing.Point(11, 75);
            this.textBoxNewAudioPlaylistName.Name = "textBoxNewAudioPlaylistName";
            this.textBoxNewAudioPlaylistName.Size = new System.Drawing.Size(302, 53);
            this.textBoxNewAudioPlaylistName.TabIndex = 15;
            this.textBoxNewAudioPlaylistName.TextChanged += new System.EventHandler(this.textBoxNewAudioPlaylistName_TextChanged);
            // 
            // buttonAudioMoveUp
            // 
            this.buttonAudioMoveUp.Location = new System.Drawing.Point(542, 179);
            this.buttonAudioMoveUp.Name = "buttonAudioMoveUp";
            this.buttonAudioMoveUp.Size = new System.Drawing.Size(75, 46);
            this.buttonAudioMoveUp.TabIndex = 21;
            this.buttonAudioMoveUp.Text = "/\\";
            this.buttonAudioMoveUp.UseVisualStyleBackColor = true;
            this.buttonAudioMoveUp.Click += new System.EventHandler(this.buttonAudioMoveUp_Click);
            // 
            // buttonAudioMoveToTop
            // 
            this.buttonAudioMoveToTop.Location = new System.Drawing.Point(542, 127);
            this.buttonAudioMoveToTop.Name = "buttonAudioMoveToTop";
            this.buttonAudioMoveToTop.Size = new System.Drawing.Size(75, 46);
            this.buttonAudioMoveToTop.TabIndex = 20;
            this.buttonAudioMoveToTop.Text = "//\\\\";
            this.buttonAudioMoveToTop.UseVisualStyleBackColor = true;
            this.buttonAudioMoveToTop.Click += new System.EventHandler(this.buttonAudioMoveToTop_Click);
            // 
            // buttonCreateNewAudioPlaylist
            // 
            this.buttonCreateNewAudioPlaylist.Enabled = false;
            this.buttonCreateNewAudioPlaylist.Location = new System.Drawing.Point(327, 78);
            this.buttonCreateNewAudioPlaylist.Name = "buttonCreateNewAudioPlaylist";
            this.buttonCreateNewAudioPlaylist.Size = new System.Drawing.Size(162, 35);
            this.buttonCreateNewAudioPlaylist.TabIndex = 14;
            this.buttonCreateNewAudioPlaylist.Text = "Create Playlist";
            this.buttonCreateNewAudioPlaylist.UseVisualStyleBackColor = true;
            this.buttonCreateNewAudioPlaylist.Click += new System.EventHandler(this.buttonCreateNewAudioPlaylist_Click);
            // 
            // comboBoxSelectProfile
            // 
            this.comboBoxSelectProfile.FormattingEnabled = true;
            this.comboBoxSelectProfile.Location = new System.Drawing.Point(269, 74);
            this.comboBoxSelectProfile.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxSelectProfile.Name = "comboBoxSelectProfile";
            this.comboBoxSelectProfile.Size = new System.Drawing.Size(277, 54);
            this.comboBoxSelectProfile.TabIndex = 4;
            this.comboBoxSelectProfile.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectProfile_SelectedIndexChanged);
            // 
            // buttonCreateProfile
            // 
            this.buttonCreateProfile.Enabled = false;
            this.buttonCreateProfile.Location = new System.Drawing.Point(1112, 74);
            this.buttonCreateProfile.Name = "buttonCreateProfile";
            this.buttonCreateProfile.Size = new System.Drawing.Size(142, 35);
            this.buttonCreateProfile.TabIndex = 5;
            this.buttonCreateProfile.Text = "Create Profile";
            this.buttonCreateProfile.UseVisualStyleBackColor = true;
            this.buttonCreateProfile.Click += new System.EventHandler(this.buttonCreateProfile_Click);
            // 
            // textBoxNewProfileName
            // 
            this.textBoxNewProfileName.Location = new System.Drawing.Point(848, 74);
            this.textBoxNewProfileName.Name = "textBoxNewProfileName";
            this.textBoxNewProfileName.Size = new System.Drawing.Size(258, 53);
            this.textBoxNewProfileName.TabIndex = 6;
            this.textBoxNewProfileName.TextChanged += new System.EventHandler(this.textBoxNewProfileName_TextChanged);
            // 
            // buttonLoadProfile
            // 
            this.buttonLoadProfile.Enabled = false;
            this.buttonLoadProfile.Location = new System.Drawing.Point(566, 72);
            this.buttonLoadProfile.Name = "buttonLoadProfile";
            this.buttonLoadProfile.Size = new System.Drawing.Size(130, 35);
            this.buttonLoadProfile.TabIndex = 7;
            this.buttonLoadProfile.Text = "Load Profile";
            this.buttonLoadProfile.UseVisualStyleBackColor = true;
            this.buttonLoadProfile.Click += new System.EventHandler(this.buttonLoadProfile_Click);
            // 
            // buttonDeleteProfile
            // 
            this.buttonDeleteProfile.Location = new System.Drawing.Point(702, 72);
            this.buttonDeleteProfile.Name = "buttonDeleteProfile";
            this.buttonDeleteProfile.Size = new System.Drawing.Size(140, 35);
            this.buttonDeleteProfile.TabIndex = 8;
            this.buttonDeleteProfile.Text = "Delete Profile";
            this.buttonDeleteProfile.UseVisualStyleBackColor = true;
            this.buttonDeleteProfile.Click += new System.EventHandler(this.buttonDeleteProfile_Click);
            // 
            // timerStatusUpdater
            // 
            this.timerStatusUpdater.Interval = 250;
            this.timerStatusUpdater.Tick += new System.EventHandler(this.timerStatusUpdater_Tick);
            // 
            // voicesCmBox
            // 
            this.voicesCmBox.FormattingEnabled = true;
            this.voicesCmBox.Location = new System.Drawing.Point(498, 80);
            this.voicesCmBox.Name = "voicesCmBox";
            this.voicesCmBox.Size = new System.Drawing.Size(121, 54);
            this.voicesCmBox.TabIndex = 21;
            this.voicesCmBox.SelectedIndexChanged += new System.EventHandler(this.voicesCmBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(23F, 46F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 986);
            this.Controls.Add(this.buttonDeleteProfile);
            this.Controls.Add(this.buttonLoadProfile);
            this.Controls.Add(this.textBoxNewProfileName);
            this.Controls.Add(this.buttonCreateProfile);
            this.Controls.Add(this.comboBoxSelectProfile);
            this.Controls.Add(this.groupBoxAudio);
            this.Controls.Add(this.groupBoxVoiceNoise);
            this.Controls.Add(this.linkLabelWebService);
            this.Controls.Add(this.textBoxStatus);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainForm";
            this.Text = "Web Audio Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBoxVoiceNoise.ResumeLayout(false);
            this.groupBoxVoiceNoise.PerformLayout();
            this.groupBoxAudio.ResumeLayout(false);
            this.groupBoxAudio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.LinkLabel linkLabelWebService;
        private System.Windows.Forms.GroupBox groupBoxVoiceNoise;
        private System.Windows.Forms.GroupBox groupBoxAudio;
        private System.Windows.Forms.ComboBox comboBoxPlaybackPlaylists;
        private System.Windows.Forms.ComboBox comboBoxSelectProfile;
        private System.Windows.Forms.Button buttonCreateProfile;
        private System.Windows.Forms.TextBox textBoxNewProfileName;
        private System.Windows.Forms.Button buttonLoadProfile;
        private System.Windows.Forms.Button buttonDeleteProfile;
        private System.Windows.Forms.Button buttonDeletePlaybackPlaylist;
        private System.Windows.Forms.Button buttonCreateNewPlaybackPlaylist;
        private System.Windows.Forms.TextBox textBoxNewPlaybackPlaylistName;
        private System.Windows.Forms.Button buttonDeleteAudioPlaylist;
        private System.Windows.Forms.ComboBox comboBoxAudioPlaylists;
        private System.Windows.Forms.TextBox textBoxNewAudioPlaylistName;
        private System.Windows.Forms.Button buttonCreateNewAudioPlaylist;
        private System.Windows.Forms.Button buttonPlaylistRemoveFile;
        private System.Windows.Forms.Button buttonPlaylistAddFile;
        private System.Windows.Forms.Button buttonPlaylistMoveToBottom;
        private System.Windows.Forms.Button buttonPlaylistMoveDown;
        private System.Windows.Forms.Button buttonPlaylistMoveUp;
        private System.Windows.Forms.Button buttonPlaylistMoveToTop;
        private System.Windows.Forms.ListBox listBoxPlaylistFiles;
        private System.Windows.Forms.Button buttonAudioRemoveFile;
        private System.Windows.Forms.ListBox listBoxAudioFiles;
        private System.Windows.Forms.Button buttonAudioAddFile;
        private System.Windows.Forms.Button buttonAudioMoveToBottom;
        private System.Windows.Forms.Button buttonAudioMoveDown;
        private System.Windows.Forms.Button buttonAudioMoveUp;
        private System.Windows.Forms.Button buttonAudioMoveToTop;
        private System.Windows.Forms.Timer timerStatusUpdater;
        private System.Windows.Forms.Button buttonRecording;
        private System.Windows.Forms.ComboBox voicesCmBox;
    }
}

