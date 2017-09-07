using Newtonsoft.Json;
using Orchard.Candidate.Common;
using Orchard.Candidate.Core.Interfaces;
using Orchard.Candidate.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Orchard.Candidate.Infrastructure.Services
{
    public class ApiRepo : IApiRepo
    {
        private string baseaddress = "https://jsonplaceholder.typicode.com/";
        public async Task<UserModel> FetchUsersAsync(int? id)
        {
            var userModel = new UserModel();
            userModel = await GetJsonApi<UserModel>(userModel, baseaddress, "users/" + id);
            return userModel;
        }

        public async Task<List<UserBlogPostModel>> FetchPostsAsync(int? userid, int NumberOfPost, int PageNumber)
        {
            var UserPost = new List<UserBlogPostModel>();
            UserPost.AddRange(UserPost.CacheGetAll());
            UserPost.AddRange(await GetJsonApi<List<UserBlogPostModel>>(UserPost, baseaddress, "users/" + userid + "/posts"));
            return UserPost.OrderByDescending(x => x.Id).Skip((PageNumber - 1) * NumberOfPost).Take(NumberOfPost).ToList();
        }

        public async Task<UserBlogPostModel> PostBlogAsync(UserBlogPostModel model)
        {
            var result = await PostJsonApi<UserBlogPostModel>(model, baseaddress, "posts");
            var userBlogPostModel = JsonConvert.DeserializeObject<UserBlogPostModel>(result);
            return userBlogPostModel;
        }

        private async Task<T> GetJsonApi<T>(T model, string baseAddress, string requestUri)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(requestUri).Result;
            var result = response.Content.ReadAsAsync<T>().Result;
            return result;
        }

        private async Task<string> PostJsonApi<T>(T model, string baseAddress, string requestUri)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsJsonAsync(requestUri, model);
            var result = response.Content.ReadAsStringAsync().Result;
            return result;
        }
    }
}
