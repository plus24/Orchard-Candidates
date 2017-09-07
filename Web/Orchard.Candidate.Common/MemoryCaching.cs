using Orchard.Candidate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Orchard.Candidate.Common
{
public static class Cacher
    {
        public static bool CacheSet(this UserBlogPostModel userBlogPostModel,int id,DateTimeOffset expirationtimeOffset)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Add("userBlogPost"+id, userBlogPostModel, expirationtimeOffset);
        }
        public static List<UserBlogPostModel> CacheGetAll(this List<UserBlogPostModel> list)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            var userBlogPostModelList = new List<UserBlogPostModel>();
            foreach (var item in MemoryCache.Default.Where(x=>x.Key.Contains("userBlogPost")))
            {
                userBlogPostModelList.Add((UserBlogPostModel)memoryCache.Get(item.Key));
            }
            return userBlogPostModelList;
        }
    }
}
