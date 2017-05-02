using System.Web.Http;

namespace JwtRefresh.Controllers
{
    [RoutePrefix("api/token")]
    public class TokenController : ApiController
    {
        [HttpGet, Route("")]
        public string Get()
        {
            return "token!";
        }
    }
}