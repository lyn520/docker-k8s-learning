using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpGet]
        [ActionName(nameof(TestDownload))]
        public IActionResult TestDownload()
        {
            string fileDownloadName = "hello.txt";
            var buffer = Encoding.UTF8.GetBytes("Hello World!");
            var stream = new MemoryStream(buffer);
            return File(stream, "application/octet-stream", fileDownloadName);
        }
    }
}
