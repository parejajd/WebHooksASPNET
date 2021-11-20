
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebHooks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using WebHookReceiver.Models;
using WebHookReceiver.Services;

namespace WebHookReceiver.Controllers
{
    public class GitHubController : ControllerBase
    {
        private readonly ILogger<GitHubController> _logger;
        private readonly IGithubHandler _handler;

        public GitHubController(ILogger<GitHubController> logger,
            IGithubHandler handler)
        {
            _logger = logger;
            _handler = handler;
        }

        [GitHubWebHook(EventName = "push", Id = "It")]
        public IActionResult HandlerForItsPushes(string[] events, JObject data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _logger.LogInformation("push it", events);
            return Ok();
        }

        [GitHubWebHook(Id = "It")]
        public IActionResult HandlerForIt(string[] events, JObject data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _logger.LogInformation("It", events);
            return Ok();
        }

        [GitHubWebHook(EventName = "push")]
        public async Task<IActionResult> HandlerForPush(string id, JObject data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _logger.LogInformation("push", id);
            var model = data.ToObject<Root>();

            _logger.LogInformation($"Push de {model.head_commit.author.name} con el mensaje {model.commits[0].message}");
            await _handler.SaveCommit(model);
            return Ok();
        }

        [GitHubWebHook]
        public IActionResult GitHubHandler(string id, string @event, JObject data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _logger.LogInformation("GitHubHandler", id, @event);
            return Ok();
        }

        [GeneralWebHook]
        public IActionResult FallbackHandler(string receiverName, string id, string eventName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _logger.LogInformation("FallbackHandler", receiverName, id, eventName);
            return Ok();
        }
    }
}