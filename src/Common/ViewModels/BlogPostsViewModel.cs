using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    class BlogPostsViewModel
    {
        public BlogPostsViewModel(IKenticoCloudService kenticocloudService)
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