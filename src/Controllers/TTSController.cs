using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAudioController.Controllers
{
    public class TTSController: ApiController
    {
        [HttpGet]
        [Route("api/tts")]
        public List<string> GetNoises()
        {
            return new List<string>() { "WhiteNoise", "PinkNoise" };
        }

        [HttpPost]
        [Route("api/tts")]
        public string PlayNoise()
        {
            var body = Request.Content.ReadAsStringAsync().Result;

            return Service.audioHandler.ProcessCommand(AudioCommand.TTS, body) + $" {body}";
        }
    }
}