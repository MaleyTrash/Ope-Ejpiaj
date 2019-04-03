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
    public partial class ThreadItem : UserControl
    {
        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(string), typeof(CatalogItem));
        public string Header
        {
            get
            {
                return this.GetValue(HeaderProperty) as string;
            }
            set
            {
                this.SetValue(HeaderProperty, value);
            }
        }

        public static readonly DependencyProperty PostBodyProperty = DependencyProperty.Register("PostBody", typeof(string), typeof(CatalogItem));
        public string PostBody
        {
            get
            {
                return this.GetValue(PostBodyProperty) as string;
            }
            set
            {
                this.SetValue(PostBodyProperty, value);
            }
        }

        public static readonly DependencyProperty PostImageSourceProperty = DependencyProperty.Register("PostImageSource", typeof(string), typeof(CatalogItem));
        public string PostImageSource
        {
            get
            {
                return this.GetValue(PostImageSourceProperty) as string;
            }
            set
            {
                this.SetValue(PostImageSourceProperty, value);
            }
        }

        public ThreadItem()
        {
            InitializeComponent();

            DataContext = this;
        }


    }
}
