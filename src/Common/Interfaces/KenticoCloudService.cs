using Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IKenticoCloudService
    {
        Task<List<BlogPost>> GetBlogPosts();

        Task<List<BlogPost>> GetAuthorBlogPosts(string strAuthor);
    }
}
