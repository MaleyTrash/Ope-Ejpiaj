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
    /// Interakční logika pro ImageList.xaml
    /// </summary>
    public partial class ImageList : Window
    {
        private int ctr = 0;

        public ImageList(string board, string id, List<Post> posts)
        {
            InitializeComponent();

            Title = $"Fulčen - /{board}/ Image Gallery Thread No.: {id}";

            foreach(var i in posts)
            {
                if (i.tim == null && i.ext == null) continue;

                string url = $"https://media.8ch.net/file_store/thumb/{i.tim}{i.ext}";
                addItem(url);

                if (i.extra_files == null || i.extra_files.Count < 1) continue;
                foreach(var x in i.extra_files)
                {
                    string exUrl = $"https://media.8ch.net/file_store/thumb/{x.tim}{x.ext}";
                    addItem(exUrl);
                }
            }
        }

        private void addItem(string url)
        {
            Image img = new Image();

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(url, UriKind.Absolute);
            bitmap.EndInit();

            img.Source = bitmap;
            img.MaxWidth = 200;

            img.MouseLeftButtonDown += (sender, e) =>
            {
                System.Diagnostics.Process.Start(url.Replace("/thumb", ""));
            };

            StackPanel panel = new StackPanel();
            switch(ctr)
            {
                case 0: panel = Panel0; break;
                case 1: panel = Panel1; break;
                case 2: panel = Panel2; break;
                case 3: panel = Panel3; break;
            }

            panel.Children.Add(img);
            if (++ctr > 3) ctr = 0;
        }
    }
}
