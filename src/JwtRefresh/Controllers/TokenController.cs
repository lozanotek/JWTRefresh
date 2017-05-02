using System.Web.Http;

namespace JwtRefresh.Controllers
{
    [RoutePrefix("api/token")]
    public class TokenController : ApiController
    {
        [HttpPost, Route("")]
        public string Post()
        {
            var header = this.Request.Headers.Authorization?.Parameter;
            return "token!";
        }
    }
}
