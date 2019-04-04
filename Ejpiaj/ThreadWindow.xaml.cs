using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ejpiaj
{
    /// <summary>
    /// Interakční logika pro ThreadWindow.xaml
    /// </summary>
    public partial class ThreadWindow : Window
    {
        ApiWrap api;
        List<Post> posts;
        string id;

        public ThreadWindow(string id, ApiWrap api)
        {
            InitializeComponent();

            this.api = api;
            this.id = id;

            Title = $"Fulčen - /{api.Board}/ Thread No.: {id}";

            Load(id);
        }

        public async Task Load(string id)
        {
            Items.Children.RemoveRange(0, Items.Children.Count);

            Thread thr = await api.GetThread(id);

            posts = thr.posts;
            foreach (var post in thr.posts)
            {
                ThreadItem item = new ThreadItem();

                item.PostBody = DisplayHelper.StripHTML(post.com);
                item.PostImageSource = $"https://media.8ch.net/file_store/thumb/{post.tim}{post.ext}";

                DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dt = dt.AddSeconds(post.time).ToLocalTime();

                item.Header = $"{post.name} {dt.ToString("MM/dd/yy HH:mm:ss")}  No. {post.no.ToString()}";

                if(post.tim != null && post.ext != null)
                {
                    item.MouseDoubleClick += (obj, e) =>
                    {
                        System.Diagnostics.Process.Start($"https://media.8ch.net/file_store/{post.tim}{post.ext}");
                    };
                }

                Items.Children.Add(item);
            }

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new ImageList(api.Board, id, posts).Show();
        }
    }
}
