using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAudioController.Controllers
{
    public class PlaybackController: ApiController
    {
        [HttpGet]
        [Route("api/playbacks")]
        public List<string> GetPlaybackNames()
        {
            return MainForm.currentPreference.PlaybackPlaylists.Where(x => x.Playlist.Length > 0).Select(y => y.PlaylistName).ToList();
        }
        
        [HttpGet]
        [Route("api/playbacks/{playlistName}")]
        public List<string> GetPlaylist(string playlistName)
        {
            var results = MainForm.currentPreference.PlaybackPlaylists.First(x => x.PlaylistName == playlistName).Playlist.Select(y => y.DisplayName).ToList();

            return results;
        }

        [HttpGet]
        [Route("api/playbacks/{playlistName}/songs/{songName}")]
        public string PlayPlayback(string playlistName, string songName)
        {
            return Service.audioHandler.ProcessCommand(AudioCommand.PlayVoice, playlistName, songName) + $" {songName}";
        }
    }
}