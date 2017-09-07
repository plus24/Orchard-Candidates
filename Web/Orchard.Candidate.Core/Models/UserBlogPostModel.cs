using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchard.Candidate.Core.Models
{
    public class UserBlogPostModel : BlogPostModel
    {
        public int? Id { get; set; }
        public int UserId { get; set; }
    }
}
