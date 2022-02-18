using HW.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HW
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private readonly ComicsViewModel _vm = new ComicsViewModel();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = _vm;
        }
    }
}
