using System.ComponentModel;
using Xamarin.Forms;
using XamarinTest.ViewModels;

namespace XamarinTest.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}