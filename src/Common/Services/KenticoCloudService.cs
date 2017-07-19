using Common.Interfaces;
using Common.Models;
using Common.Resolvers;
using KenticoCloud.Delivery;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
   public class KenticoCloudService : IKenticoCloudService
    {

        private DeliveryClient client;
        private static string strKenticoCloudProjectID = "4e9bdd7a-2db8-4c33-a13a-0c368ec2f108"; // Update to your Kentico Cloud Project ID
        public KenticoCloudService()
        {
            client = new DeliveryClient(strKenticoCloudProjectID);
            client.InlineContentItemsProcessor.RegisterTypeResolver(new HostedVideoResolver());
        }

        public async Task<List<BlogPost>> GetBlogPosts()
        {
            List<BlogPost> lstBlogPosts = new List<BlogPost>();

            try
            {
                var response = await client.GetItemsAsync<BlogPost>(
                    new EqualsFilter("system.type", BlogPost.Codename),
                    new ElementsParameter(BlogPost.TitleCodename, BlogPost.DateCodename, BlogPost.AuthorCodename, BlogPost.UrlSlugCodename, BlogPost.HeaderImageCodename, BlogPost.TopicCodename, BlogPost.PerexCodename),
                    new LimitParameter(10),
                    new OrderParameter("elements." + BlogPost.DateCodename, SortOrder.Descending)
                );

                foreach(BlogPost blog in response.Items)
                {
                    lstBlogPosts.Add(blog);
                }
            }
            catch (Exception)
            {
            }
            return lstBlogPosts;
        }

        public async Task<List<BlogPost>> GetAuthorBlogPosts(string strAuthor)
        {
            List<BlogPost> lstBlogPosts = new List<BlogPost>();

            try
            {
                var response = await client.GetItemsAsync<BlogPost>(
                    new EqualsFilter("system.type", BlogPost.Codename),
                    new ElementsParameter(BlogPost.TitleCodename, BlogPost.DateCodename, BlogPost.AuthorCodename, BlogPost.UrlSlugCodename, BlogPost.HeaderImageCodename, BlogPost.TopicCodename, BlogPost.PerexCodename),
                    new ContainsFilter("elements." + BlogPost.AuthorCodename, strAuthor),
                    new OrderParameter("elements." + BlogPost.DateCodename, SortOrder.Descending)
                );

                foreach (BlogPost blog in response.Items)
                {
                    lstBlogPosts.Add(blog);
                }
            }
            catch (Exception)
            {
            }
            return lstBlogPosts;
        }
    }
}
