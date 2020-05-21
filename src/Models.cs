using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace WebAudioController
{
    [JsonObject]
    public class MasterSettings
    {
        [JsonProperty("preferenceName")]
        public string PreferenceName { get; set; }
    }

    [JsonObject]
    public class WACPreference
    {
        public WACPreference()
        {
            PlaybackPlaylists = new List<WACPlaylist>();
            AudioPlaylists = new List<WACPlaylist>();
        }

        [JsonProperty("preferenceName")]
        public string PreferenceName { get; set; }

        [JsonProperty]
        public string CurrentPlaybackPlaylist { get; set; }

        [JsonProperty]
        public string CurrentAudioPlaylist { get; set; }

        public List<string> PlaybackPlaylistNames { get { return PlaybackPlaylists.Select(x => { return x.PlaylistName; }).ToList(); } }

        [JsonProperty]
        public List<WACPlaylist> PlaybackPlaylists { get; set; }

        public List<string> AudioPlaylistNames { get { return AudioPlaylists.Select(x => { return x.PlaylistName; }).ToList(); } }

        [JsonProperty]
        public List<WACPlaylist> AudioPlaylists { get; set; }

        internal WACPlaylist CurrentPlaybackPlaylistRef { get { return PlaybackPlaylists.First(x => x.PlaylistName == CurrentPlaybackPlaylist); } }

        internal WACPlaylist CurrentAudioPlaylistRef { get { return AudioPlaylists.First(x => x.PlaylistName == CurrentAudioPlaylist); } }
    }

    [JsonObject]
    public class WACPlaylist
    {
        public WACPlaylist()
        {
            Playlist = new WACAudioFile[0];
        }

        public void AddFile(string displayName, string filePath, string iconPath = "")
        {
            WACAudioFile[] tempSongArray = new WACAudioFile[Playlist.Length + 1];

            Playlist.CopyTo(tempSongArray, 0);

            tempSongArray[Playlist.Length] = new WACAudioFile(filePath, displayName, iconPath);

            Playlist = tempSongArray;
        }

        public void MoveFileUp(int index)
        {
            if (index != 0)
            {
                WACAudioFile temp = Playlist[index - 1];
                Playlist[index - 1] = Playlist[index];
                Playlist[index] = temp;
            }
        }

        public void MoveFileDown(int index)
        {
            if (index != Playlist.Length - 1)
            {
                WACAudioFile temp = Playlist[index + 1];
                Playlist[index + 1] = Playlist[index];
                Playlist[index] = temp;
            }
        }

        public void MoveFileToFront(int index)
        {
            if (index != 0)
            {
                WACAudioFile temp = Playlist[0];
                Playlist[0] = Playlist[index];
                Playlist[index] = temp;
            }
        }

        public void MoveFileToEnd(int index)
        {
            if (index != 0)
            {
                WACAudioFile temp = Playlist[Playlist.Length - 1];
                Playlist[Playlist.Length - 1] = Playlist[index];
                Playlist[index] = temp;
            }
        }

        public void RemoveFile(int songIndex)
        {
            List<WACAudioFile> tmpArray = new List<WACAudioFile>(Playlist);

            tmpArray.RemoveAt(songIndex);

            Playlist = tmpArray.ToArray();
        }

        [JsonProperty]
        public string PlaylistName { get; set; }

        [JsonProperty]
        public WACAudioFile[] Playlist { get; set; }
    }

    [JsonObject]
    public class WACAudioFile
    {
        public WACAudioFile(string filePath, string displayName = null, string iconPath = "")
        {
            IconPath = iconPath;
            FilePath = filePath;
            if (displayName != null)
            {
                DisplayName = displayName;
            }
            else
            {
                DisplayName = FileName;
            }
        }

        [JsonProperty]
        public string DisplayName { get; set; }
        public string FilePath { get; set; }
        [JsonProperty]
        public string FileName { get { return FilePath.Split('/').Last(); } }
        public string IconPath { get; set; }
    }
}
