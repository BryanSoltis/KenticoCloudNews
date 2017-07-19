using Common.Helpers;
using Common.Models;
using Common.Services;
using Common.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Common.Views
{
    public partial class BlogPostsPage : ContentPage
    {
        private string strStandardMessage = "What the? Hmm...something didn't go right.\n\nMaybe wait a little bit and try again.";
        BlogPostsViewModel _viewModel;

        public BlogPostsPage()
        {
            _viewModel = new BlogPostsViewModel(new KenticoCloudService());
            InitializeComponent();
            RefreshBlogPosts(0);
        }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;
                    await RefreshBlogPosts(1000);
                    IsRefreshing = false;
                });
            }
        }

        public async Task RefreshBlogPosts(int intDelay = 0)
        {
            try
            {
                await General.Sleep(intDelay);
                var blogposts = await _viewModel.GetBlogPosts();
                lvBlogPosts.ItemsSource = blogposts;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void MessageButton_Clicked(object sender, EventArgs e)
        {
            slMessage.IsVisible = false;
        }

        async void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            try
            {
                BlogPost blog = (BlogPost)e.SelectedItem;
                await Navigation.PushAsync(new BlogPostDetailPage(new BlogPostDetailViewModel(blog)));

                // Manually deselect item
                lvBlogPosts.SelectedItem = null;

            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        protected void HandleException(Exception ex)
        {
#if DEBUG
            ShowMessage(ex.Message);
#else
                ShowMessage(strStandardMessage);
#endif
        }

        protected void ShowMessage(string strMessageText)
        {
            if (strMessageText != "")
            {
                lblMessage.Text = strMessageText;
                slMessage.IsVisible = true;
            }
            else
            {
                slMessage.IsVisible = false;
            }
        }
    }
}
