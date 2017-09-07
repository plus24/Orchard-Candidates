using Newtonsoft.Json;
using Orchard.Candidate.Common;
using Orchard.Candidate.Core.Models;
using Orchard.Candidate.Infrastructure.Services;
using Orchard.Candidate.Net.Filters;
using Orchard.Candidate.Net.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Orchard.Candidate.Net.Controllers.Api
{

    public class PostController : ApiController
    {
        ApiRepo apiRepo = new ApiRepo();
        //TODO: POST api/post/1
        [HttpPost]
        [ValidateModel]
        [TokenAuthorizeFilter]
        [Route("api/post/{id}")]
        public async Task<IHttpActionResult> Post([FromUri] int id, [FromBody] BlogPostModel model)
        {
            var postModel = new UserBlogPostModel
            {
                UserId = id,
                Title = model.Title,
                Body = model.Body
            };
            var result = await apiRepo.PostBlogAsync(postModel);
            if (result.Id != null)
            {
                result.CacheSet(result.Id.Value, DateTimeOffset.UtcNow.AddMinutes(180));
                return Ok("Success");
            }
            else
            {
                return Content(HttpStatusCode.NotModified, "Failed");
            }
            

        }


    }
}
