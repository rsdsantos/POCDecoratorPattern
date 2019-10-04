using Communication.API.Application.Commands;
using Communication.API.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Communication.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/emails")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly Messages _messages;

        public EmailsController(Messages messages)
        {
            _messages = messages;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SendAsync([FromBody] SendEmailCommand command)
        {
            // Execução do Handler com acoplamento:
            //var handler = new SendEmailCommandHandler();
            //var commandResult = await handler.Handle(command);

            // Execução do Handler por IoC:
            var commandResult = await _messages.Dispatch(command);

            if (string.IsNullOrEmpty(commandResult))
                return BadRequest();

            return Ok(commandResult);
        }
    }
}
