using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAudioController.Controllers
{
    public class talkController: ApiController
    {
        [HttpPost]
        [Route("api/talk")]
        //public string TalkToStream(HttpPostedFile)
        public async Task<IHttpActionResult> TalkToStream()
        {
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);

            var file = provider.Contents[0];

            var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
            var fileType = filename.Split('.').Last();
            var buffer = await file.ReadAsByteArrayAsync();
            //Do whatever you want with filename and its binary data.
            var fullFile = $@"{MainForm.liveAudioFolder}\{Guid.NewGuid()}.{fileType}";
            File.WriteAllBytes(fullFile, buffer);

            Service.audioHandler.ProcessCommand(AudioCommand.PlayLiveVoice, fullFile);

            return Ok();
        }
    }
}