using DMS_App.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMS_App.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DMS_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostsPage : ContentPage
    {
        public ObservableCollection<UsersPosts> PostsCollection;


        public PostsPage()
        {
            InitializeComponent();
            PostsCollection = new ObservableCollection<UsersPosts>();
            getPosts();

        }

        private async void getPosts()
        {
            var  posts = await ApiService.GetPosts();
            foreach (var post in posts)
            {
                PostsCollection.Add(post);
            }
            PostsCV.ItemsSource = PostsCollection;
        }
    }
}