using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DadJoke.Controllers
{
    [ApiController]
    [Route("dad-jokes.p.rapidapi.com")]
    [Authorize(AuthenticationSchemes= "ApiKey")]
    public class JokesController : ControllerBase
    {
        private readonly ILogger<JokesController> _logger;      

        private List<Joke> _jokeList;
        
        public JokesController(ILogger<JokesController> logger)
        {
            _logger = logger;
            _jokeList = new()
            { 
                new Joke { Id=Guid.NewGuid(), Setup= "Why do Java programmers wear glasses?", Type="programming", Punchline= "Because they don't C#" },
                new Joke { Id=Guid.NewGuid(), Setup= "What's the best thing about a Boolean?", Type="programming", Punchline= "Even if you're wrong, you're only off by a bit." },
                new Joke { Id=Guid.NewGuid(), Setup= "What do you call a fashionable lawn statue with an excellent sense of rhythmn?", Type="general", Punchline= "Because they don't C#" },
                new Joke { Id=Guid.NewGuid(), Setup= "Test", Type="General", Punchline= "Test Joke" },
                new Joke { Id=Guid.NewGuid(), Setup= "Test2", Type="General", Punchline= "Test2 Joke" }
            };
        }

        [HttpGet("random/joke")]
       // [Produces("application/json")]
        //[Produces("text/html")]
        public async Task<IActionResult> GetRandomJoke([FromQuery] int count=1)
        {
            _logger.LogDebug("JokesController:GetRandomJoke: Get random joke started");
            try
            {
                if(count>=1 && count <= 5) 
                {                
                  return Ok(_jokeList.Take(count));
                }
                else
                {
                    _logger.LogWarning("JokesController:GetRandomJoke:In");
                    return BadRequest($"Invalid input count param-{count}");
                }
               
            }
            catch(Exception e)
            {
                _logger.LogError("JokesController:GetRandomJoke: Error occured while getting rondom jokes");
                return StatusCode((int)HttpStatusCode.InternalServerError,e.Message);
            }
        }
       
    }
}