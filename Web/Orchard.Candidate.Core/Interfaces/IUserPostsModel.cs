using System.Collections.Generic;
using Orchard.Candidate.Core.Models;

namespace Orchard.Candidate.Core.Interfaces
{
    public interface IUserPostsModel
    {
        List<UserBlogPostModel> postList { get; set; }
        string userName { get; set; }
    }
}