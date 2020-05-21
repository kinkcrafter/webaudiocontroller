using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAudioController.Controllers
{
    public class NoiseController: ApiController
    {
        [HttpGet]
        [Route("api/noise")]
        public List<string> GetNoises()
        {
            return new List<string>() { "WhiteNoise", "PinkNoise" };
        }

        [HttpGet]
        [Route("api/noise/{noiseType}")]
        public string PlayNoise(string noiseType)
        {
            switch (noiseType.ToLower())
            {
                case "whitenoise":
                    {
                        Service.audioHandler.ProcessCommand(AudioCommand.WhiteNoise);
                        return "Playing WhiteNoise";
                    }
                case "pinknoise":
                    {
                        Service.audioHandler.ProcessCommand(AudioCommand.PinkNoise);
                        return "Playing PinkNoise";
                    }
                default:
                    {
                        return "Noise Generator not found!";
                    }
            }
        }
    }
}