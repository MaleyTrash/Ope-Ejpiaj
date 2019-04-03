using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ejpiaj
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApiWrap api;

        public MainWindow()
        {
            InitializeComponent();

            Load("v");
        }

        public void Load(string board)
        {
            api = new ApiWrap(board);

            Title = $"Fulčen - /{api.Board}/";
            _ = GenerateCatalogAsync();
        }

        public async Task GenerateCatalogAsync()
        {
            Items.Children.RemoveRange(0, Items.Children.Count);

            var catalog = await api.GetCatalog();

            foreach(var i in catalog)
            {
                foreach(var thread in i.threads)
                {
                    CatalogItem item = new CatalogItem();

                    item.ID = thread.id;
                    item.Title = thread.sub;
                    item.Body = DisplayHelper.StripHTML(thread.com);
                    item.ImageSource = $"https://media.8ch.net/file_store/thumb/{thread.tim}{thread.ext}";
                    item.Stats = $"R: {thread.replies} I: {thread.images + thread.omitted_images}";

                    item.MouseDoubleClick += (sender, e) =>
                    {
                        new ThreadWindow(thread.no.ToString(), api).Show();
                    };

                    Items.Children.Add(item);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Load(BoardText.Text);
        }
    }
}
