using Asp.Versioning;
using Elmah.Io.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace AVS.DevStore.API.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/teste")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        private readonly ILogger _logger;

        public TesteController(ILogger<TesteController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Valor()
        {

            //throw new Exception("Error");

            try
            {
                var i = 0;
                var result = 42 / i;
            }
            catch (DivideByZeroException e)
            {
                e.Ship(HttpContext);
            }

            _logger.LogTrace("Log de Trace");
            _logger.LogDebug("Log de Debug");
            _logger.LogInformation("Log de Informação");
            _logger.LogWarning("Log de Aviso");
            _logger.LogError("Log de Erro");
            _logger.LogCritical("Log de Problema Critico");

            return Environment.MachineName + " | " + Environment.OSVersion.ToString() + " | " + DateTime.UtcNow;
        }
    }
}
