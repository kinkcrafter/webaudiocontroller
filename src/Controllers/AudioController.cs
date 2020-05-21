using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAudioController.Controllers
{
    public class AudioController: ApiController
    {
        [Route("api/audio")]
        public List<string> GetPlaybackNames()
        {
            return MainForm.currentPreference.AudioPlaylists.Where(x => x.Playlist.Length > 0).Select(y => y.PlaylistName).ToList();
        }

        [HttpGet]
        [Route("api/audio/{playlistName}")]
        public List<string> GetPlaylist(string playlistName)
        {
            return MainForm.currentPreference.AudioPlaylists.First(x => x.PlaylistName == playlistName).Playlist.Select(y => y.DisplayName).ToList();
        }

        [HttpGet]
        [Route("api/audio/{playlistName}/songs/{songName}")]
        public string PlayPlayback(string playlistName, string songName)
        {
            return Service.audioHandler.ProcessCommand(AudioCommand.PlayAudio, playlistName, songName) + $" {songName}";
        }
    }
}