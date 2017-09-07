using Orchard.Candidate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchard.Candidate.Core.Interfaces
{
    public interface IApiRepo
    {
        Task<List<UserBlogPostModel>> FetchPostsAsync(int? userid, int NumberOfPost, int PageNumber);
        Task<UserModel> FetchUsersAsync(int? id);
        Task<UserBlogPostModel> PostBlogAsync(UserBlogPostModel model);
    }
}

