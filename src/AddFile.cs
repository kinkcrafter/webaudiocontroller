using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WebAudioController
{
    public partial class AddFile : Form
    {
        private WACPlaylist playlist;

        private ListBox listBox;

        private string baseFileDirectory;

        private List<string> toAdd = new List<string>(); 

        public AddFile(WACPlaylist parentPlaylist, ListBox targetListBox, string fileDirectory = null): this()
        {
            playlist = parentPlaylist;
            listBox = targetListBox;
            baseFileDirectory = fileDirectory;
        }

        public AddFile()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBoxFileDisplayName.Text == string.Empty )
            {
                buttonAddFile.Enabled = true;
            }
            else
            {
                if (playlist.Playlist.Any(x => x.DisplayName == textBoxFileDisplayName.Text))
                {
                    buttonAddFile.Enabled = false;
                }
                else
                {
                    buttonAddFile.Enabled = true;
                }
            }
        }

        private void AddFile_Load(object sender, EventArgs e)
        {
            if(baseFileDirectory != null)
            {
                openFileForPlaylist.InitialDirectory = baseFileDirectory;
            }

            openFileForPlaylist.Multiselect = true;
            openFileForPlaylist.Filter = "Audio Files|*.wav;*.mp3";

            var result = openFileForPlaylist.ShowDialog();

            if (result == DialogResult.OK)
            {
                toAdd.AddRange(openFileForPlaylist.FileNames);

                labelNumberOfFiles.Text = $"{toAdd.Count} Files";

                labelFileName.Text = toAdd.First();
            }
            else
            {
                this.Close();
            }
        }

        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            var nextFile = toAdd.First();

            var fileDisplayName = nextFile.Substring(nextFile.LastIndexOf('\\') + 1);

            fileDisplayName = fileDisplayName.Substring(0, fileDisplayName.Length - 4);

            if (textBoxFileDisplayName.Text != string.Empty)
            {
                fileDisplayName = textBoxFileDisplayName.Text;
            }

            playlist.AddFile(fileDisplayName, nextFile);

            listBox.DataSource = playlist.Playlist;

            toAdd.Remove(nextFile);

            if(toAdd.Count == 0)
            {
                this.Close();
                return;
            }

            labelFileName.Text = toAdd.First();

            textBoxFileDisplayName.Text = string.Empty;

            labelNumberOfFiles.Text = $"{toAdd.Count} Files";
        }

        private void buttonCancel_click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}