using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AVS.DevStore.API.V1.Controllers
{
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{version:apiVersion}/teste")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        public TesteController()
        {
        }

        [HttpGet]
        public string Value()
        {
            return Environment.MachineName + " | " + Environment.OSVersion.ToString() + " | " + DateTime.UtcNow;
        }
    }
}
