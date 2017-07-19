using Common.Interfaces;
using Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class BlogPostDetailViewModel : BaseViewModel
    {
        public BlogPost BlogPost { get; set; }
       
        public BlogPostDetailViewModel(BlogPost blogpost = null)
        {
            Title = blogpost.Title;
            BlogPost = blogpost;
        }
    }
}
