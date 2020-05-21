namespace WebAudioController
{
    partial class AddFile
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
            this.openFileForPlaylist = new System.Windows.Forms.OpenFileDialog();
            this.textBoxFileDisplayName = new System.Windows.Forms.TextBox();
            this.labelFileName = new System.Windows.Forms.Label();
            this.labelDisplayName = new System.Windows.Forms.Label();
            this.buttonAddFile = new System.Windows.Forms.Button();
            this.labelNumberOfFiles = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileForPlaylist
            // 
            this.openFileForPlaylist.FileName = "openFileForPlaylist";
            // 
            // textBoxFileDisplayName
            // 
            this.textBoxFileDisplayName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFileDisplayName.Location = new System.Drawing.Point(133, 58);
            this.textBoxFileDisplayName.Name = "textBoxFileDisplayName";
            this.textBoxFileDisplayName.Size = new System.Drawing.Size(598, 30);
            this.textBoxFileDisplayName.TabIndex = 0;
            this.textBoxFileDisplayName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFileName.Location = new System.Drawing.Point(66, 15);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(155, 25);
            this.labelFileName.TabIndex = 1;
            this.labelFileName.Text = "No File Selected";
            // 
            // labelDisplayName
            // 
            this.labelDisplayName.AutoSize = true;
            this.labelDisplayName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDisplayName.Location = new System.Drawing.Point(21, 65);
            this.labelDisplayName.Name = "labelDisplayName";
            this.labelDisplayName.Size = new System.Drawing.Size(106, 20);
            this.labelDisplayName.TabIndex = 2;
            this.labelDisplayName.Text = "Display Name";
            // 
            // buttonAddFile
            // 
            this.buttonAddFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddFile.Location = new System.Drawing.Point(25, 110);
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new System.Drawing.Size(167, 39);
            this.buttonAddFile.TabIndex = 3;
            this.buttonAddFile.Text = "Add File";
            this.buttonAddFile.UseVisualStyleBackColor = true;
            this.buttonAddFile.Click += new System.EventHandler(this.buttonAddFile_Click);
            // 
            // labelNumberOfFiles
            // 
            this.labelNumberOfFiles.AutoSize = true;
            this.labelNumberOfFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberOfFiles.Location = new System.Drawing.Point(20, 15);
            this.labelNumberOfFiles.Name = "labelNumberOfFiles";
            this.labelNumberOfFiles.Size = new System.Drawing.Size(23, 25);
            this.labelNumberOfFiles.TabIndex = 4;
            this.labelNumberOfFiles.Text = "0";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(227, 110);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(167, 39);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_click);
            // 
            // AddFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 198);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelNumberOfFiles);
            this.Controls.Add(this.buttonAddFile);
            this.Controls.Add(this.labelDisplayName);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.textBoxFileDisplayName);
            this.Name = "AddFile";
            this.Text = "Add File To Playlist";
            this.Load += new System.EventHandler(this.AddFile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileForPlaylist;
        private System.Windows.Forms.TextBox textBoxFileDisplayName;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Label labelDisplayName;
        private System.Windows.Forms.Button buttonAddFile;
        private System.Windows.Forms.Label labelNumberOfFiles;
        private System.Windows.Forms.Button buttonCancel;
    }
}