using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Candidate.Core.Interfaces;

namespace Orchard.Candidate.Core.Models
{
    public class UserPostsModel : IUserPostsModel
    {
        public List<UserBlogPostModel> postList { get; set; }
        public string userName { get; set; }
    }
}