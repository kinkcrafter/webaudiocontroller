using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAudioController.Controllers
{
    public class MasterController: ApiController
    {
        [HttpGet]
        [Route("api/master/volume/mute")]
        public string ToggleMute()
        {
            return Service.audioHandler.ProcessCommand(AudioCommand.Mute);
        }

        [HttpGet]
        [Route("api/master/volume/set/{volumeLevel}")]
        public string SetVolume(string volumeLevel)
        {
            return Service.audioHandler.ProcessCommand(AudioCommand.SetVolume, volumeLevel);
        }

        [HttpGet]
        [Route("api/master/stop")]
        public string StopAudio()
        {
            return Service.audioHandler.ProcessCommand(AudioCommand.Stop);
        }

        [HttpGet]
        [Route("api/master/status")]
        public string GetStatus()
        {
            return MainForm.StatusText;
        }
    }
}
