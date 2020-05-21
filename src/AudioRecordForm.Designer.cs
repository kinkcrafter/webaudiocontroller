namespace WebAudioController
{
    partial class AudioRecordForm
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
            this.buttonStartRecording = new System.Windows.Forms.Button();
            this.buttonStopRecording = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxRecordings = new System.Windows.Forms.ListBox();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonCloseRecorder = new System.Windows.Forms.Button();
            this.recordingNameText = new System.Windows.Forms.TextBox();
            this.recordingNameLabel = new System.Windows.Forms.Label();
            this.volumeBar = new System.Windows.Forms.ProgressBar();
            this.labelMicVolume = new System.Windows.Forms.Label();
            this.groupBoxRecording = new System.Windows.Forms.GroupBox();
            this.comboBoxVoiceSelector = new System.Windows.Forms.ComboBox();
            this.voiceInLabel = new System.Windows.Forms.Label();
            this.groupBoxRecording.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStartRecording
            // 
            this.buttonStartRecording.Location = new System.Drawing.Point(12, 121);
            this.buttonStartRecording.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.buttonStartRecording.Name = "buttonStartRecording";
            this.buttonStartRecording.Size = new System.Drawing.Size(211, 44);
            this.buttonStartRecording.TabIndex = 0;
            this.buttonStartRecording.Text = "Start Recording";
            this.buttonStartRecording.UseVisualStyleBackColor = true;
            this.buttonStartRecording.Click += new System.EventHandler(this.OnButtonStartRecordingClick);
            // 
            // buttonStopRecording
            // 
            this.buttonStopRecording.Location = new System.Drawing.Point(255, 121);
            this.buttonStopRecording.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.buttonStopRecording.Name = "buttonStopRecording";
            this.buttonStopRecording.Size = new System.Drawing.Size(211, 44);
            this.buttonStopRecording.TabIndex = 0;
            this.buttonStopRecording.Text = "Stop Recording";
            this.buttonStopRecording.UseVisualStyleBackColor = true;
            this.buttonStopRecording.Click += new System.EventHandler(this.OnButtonStopRecordingClick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(10, 263);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.progressBar1.Maximum = 30;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1091, 44);
            this.progressBar1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 231);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Recording Progress:";
            // 
            // listBoxRecordings
            // 
            this.listBoxRecordings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxRecordings.FormattingEnabled = true;
            this.listBoxRecordings.ItemHeight = 25;
            this.listBoxRecordings.Location = new System.Drawing.Point(22, 480);
            this.listBoxRecordings.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.listBoxRecordings.Name = "listBoxRecordings";
            this.listBoxRecordings.Size = new System.Drawing.Size(925, 379);
            this.listBoxRecordings.TabIndex = 8;
            this.listBoxRecordings.SelectedIndexChanged += new System.EventHandler(this.listBoxRecordings_SelectedIndexChanged);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPlay.Location = new System.Drawing.Point(973, 675);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(151, 44);
            this.buttonPlay.TabIndex = 9;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.OnButtonPlayClick);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(973, 731);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(151, 44);
            this.buttonDelete.TabIndex = 10;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.OnButtonDeleteClick);
            // 
            // buttonCloseRecorder
            // 
            this.buttonCloseRecorder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCloseRecorder.Location = new System.Drawing.Point(973, 786);
            this.buttonCloseRecorder.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.buttonCloseRecorder.Name = "buttonCloseRecorder";
            this.buttonCloseRecorder.Size = new System.Drawing.Size(151, 44);
            this.buttonCloseRecorder.TabIndex = 10;
            this.buttonCloseRecorder.Text = "Close";
            this.buttonCloseRecorder.UseVisualStyleBackColor = true;
            this.buttonCloseRecorder.Click += new System.EventHandler(this.OnCloseRecorder);
            // 
            // recordingNameText
            // 
            this.recordingNameText.Location = new System.Drawing.Point(12, 68);
            this.recordingNameText.Name = "recordingNameText";
            this.recordingNameText.Size = new System.Drawing.Size(453, 31);
            this.recordingNameText.TabIndex = 12;
            this.recordingNameText.TextChanged += new System.EventHandler(this.RecordingName_TextChanged);
            // 
            // recordingNameLabel
            // 
            this.recordingNameLabel.AutoSize = true;
            this.recordingNameLabel.Location = new System.Drawing.Point(7, 39);
            this.recordingNameLabel.Name = "recordingNameLabel";
            this.recordingNameLabel.Size = new System.Drawing.Size(172, 25);
            this.recordingNameLabel.TabIndex = 13;
            this.recordingNameLabel.Text = "Recording Name";
            // 
            // volumeBar
            // 
            this.volumeBar.Location = new System.Drawing.Point(10, 358);
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.Size = new System.Drawing.Size(1091, 47);
            this.volumeBar.TabIndex = 14;
            // 
            // labelMicVolume
            // 
            this.labelMicVolume.AutoSize = true;
            this.labelMicVolume.Location = new System.Drawing.Point(10, 319);
            this.labelMicVolume.Name = "labelMicVolume";
            this.labelMicVolume.Size = new System.Drawing.Size(264, 25);
            this.labelMicVolume.TabIndex = 15;
            this.labelMicVolume.Text = "Microphone/Audio Volume";
            // 
            // groupBoxRecording
            // 
            this.groupBoxRecording.Controls.Add(this.comboBoxVoiceSelector);
            this.groupBoxRecording.Controls.Add(this.voiceInLabel);
            this.groupBoxRecording.Controls.Add(this.recordingNameLabel);
            this.groupBoxRecording.Controls.Add(this.buttonStartRecording);
            this.groupBoxRecording.Controls.Add(this.buttonStopRecording);
            this.groupBoxRecording.Controls.Add(this.recordingNameText);
            this.groupBoxRecording.Location = new System.Drawing.Point(10, 10);
            this.groupBoxRecording.Name = "groupBoxRecording";
            this.groupBoxRecording.Size = new System.Drawing.Size(857, 208);
            this.groupBoxRecording.TabIndex = 16;
            this.groupBoxRecording.TabStop = false;
            this.groupBoxRecording.Text = "Recording";
            // 
            // comboBoxVoiceSelector
            // 
            this.comboBoxVoiceSelector.FormattingEnabled = true;
            this.comboBoxVoiceSelector.Location = new System.Drawing.Point(493, 66);
            this.comboBoxVoiceSelector.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxVoiceSelector.Name = "comboBoxVoiceSelector";
            this.comboBoxVoiceSelector.Size = new System.Drawing.Size(304, 33);
            this.comboBoxVoiceSelector.TabIndex = 24;
            this.comboBoxVoiceSelector.SelectedIndexChanged += new System.EventHandler(this.comboBoxVoiceSelector_SelectedIndexChanged);
            // 
            // voiceInLabel
            // 
            this.voiceInLabel.AutoSize = true;
            this.voiceInLabel.Location = new System.Drawing.Point(488, 37);
            this.voiceInLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.voiceInLabel.Name = "voiceInLabel";
            this.voiceInLabel.Size = new System.Drawing.Size(89, 25);
            this.voiceInLabel.TabIndex = 23;
            this.voiceInLabel.Text = "Voice In";
            // 
            // AudioRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 872);
            this.Controls.Add(this.groupBoxRecording);
            this.Controls.Add(this.labelMicVolume);
            this.Controls.Add(this.volumeBar);
            this.Controls.Add(this.buttonCloseRecorder);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.listBoxRecordings);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "AudioRecordForm";
            this.Text = "Audio Recording and Settings";
            this.groupBoxRecording.ResumeLayout(false);
            this.groupBoxRecording.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartRecording;
        private System.Windows.Forms.Button buttonStopRecording;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxRecordings;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonCloseRecorder;
        private System.Windows.Forms.TextBox recordingNameText;
        private System.Windows.Forms.Label recordingNameLabel;
        private System.Windows.Forms.ProgressBar volumeBar;
        private System.Windows.Forms.Label labelMicVolume;
        private System.Windows.Forms.GroupBox groupBoxRecording;
        private System.Windows.Forms.ComboBox comboBoxVoiceSelector;
        private System.Windows.Forms.Label voiceInLabel;
    }
}
