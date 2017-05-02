using System.Web.Http;

namespace JwtRefresh.Controllers
{
    [RoutePrefix("api/message")]
    public class MessageController : ApiController
    {
        [HttpGet, Route("")]
        public string Get()
        {
            var header = this.Request.Headers.Authorization.Parameter;
            return "Hello from Angular!";
        }
    }
}