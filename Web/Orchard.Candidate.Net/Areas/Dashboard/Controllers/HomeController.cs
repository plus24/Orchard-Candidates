using Orchard.Candidate.Core.Interfaces;
using Orchard.Candidate.Core.Models;
using Orchard.Candidate.Net.Filters;
using Orchard.Candidate.Net.Models;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Orchard.Candidate.Net.Areas.Dashboard.Controllers
{
    [RouteArea("Dashboard")]
    [Authorize]
    public class HomeController : Controller
    {
        private UserPostsModel _userPostsModel;
        private IApiRepo _apiRepo;
        public HomeController(IApiRepo apiRepo,UserPostsModel userPostsModel)
        {
            _apiRepo = apiRepo;
            _userPostsModel = userPostsModel;
        }
        
        [ExternalIdFilter]
        public async Task<ActionResult> Index(int? id)
        {
            //TODO: Load first page from posts API
            UserModel userModel = await _apiRepo.FetchUsersAsync(id);
            _userPostsModel.userName = userModel.username;
            _userPostsModel.postList = await _apiRepo.FetchPostsAsync(id, 5, 1);
            return View(_userPostsModel);
        }

        

        [ExternalIdFilter]
        [HttpPost]
        public async Task<PartialViewResult> _PostList(int? id, int NumberOfPost, int PageNumber)
        {
            Thread.Sleep(3000);
            var postList = await _apiRepo.FetchPostsAsync(id, NumberOfPost, PageNumber);
            ViewBag.pageNumber = PageNumber;
            return PartialView(postList);
        }
    }
}