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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ejpiaj
{
    /// <summary>
    /// Interakční logika pro CatalogItem.xaml
    /// </summary>
    public partial class CatalogItem : UserControl
    {
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(CatalogItem));
        public string Title
        {
            get
            {
                return this.GetValue(TitleProperty) as string;
            }
            set
            {
                this.SetValue(TitleProperty, value);
            }
        }

        public static readonly DependencyProperty BodyProperty = DependencyProperty.Register("Body", typeof(string), typeof(CatalogItem));
        public string Body
        {
            get
            {
                return this.GetValue(BodyProperty) as string;
            }
            set
            {
                this.SetValue(BodyProperty, value);
            }
        }

        public static readonly DependencyProperty IDProperty = DependencyProperty.Register("ID", typeof(string), typeof(CatalogItem));
        public string ID
        {
            get
            {
                return this.GetValue(IDProperty) as string;
            }
            set
            {
                this.SetValue(IDProperty, "ID: " + value);
            }
        }

        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(string), typeof(CatalogItem));
        public string ImageSource
        {
            get
            {
                return this.GetValue(ImageSourceProperty) as string;
            }
            set
            {
                this.SetValue(ImageSourceProperty, value);
            }
        }

        public static readonly DependencyProperty StatsProperty = DependencyProperty.Register("Stats", typeof(string), typeof(CatalogItem));
        public string Stats
        {
            get
            {
                return this.GetValue(StatsProperty) as string;
            }
            set
            {
                this.SetValue(StatsProperty, value);
            }
        }

        public CatalogItem()
        {
            InitializeComponent();

            DataContext = this;
        }


    }
}
