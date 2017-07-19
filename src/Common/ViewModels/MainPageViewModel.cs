using Common.Interfaces;
using Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class MainPageViewModel
        {
            public MainPageViewModel(IKenticoCloudService kenticocloudService)
            {
                _kenticocloudService = kenticocloudService;
            }
            private readonly IKenticoCloudService _kenticocloudService;

            public async Task<List<BlogPost>> GetBlogPosts()
            {
                var blogposts = await _kenticocloudService.GetBlogPosts();
                return blogposts;
            }
        }
}
