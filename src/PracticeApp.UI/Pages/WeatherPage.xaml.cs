using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PracticeApp.Core.ViewModels;
using dotMorten.Xamarin.Forms;

namespace PracticeApp.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : MvxContentPage<WeatherViewModel>
    {
        public WeatherPage()
        {
            InitializeComponent();

        }

        private void SuggestBox_QuerySubmitted(object sender, AutoSuggestBoxQuerySubmittedEventArgs e)
        {

        }

        private void SuggestBox_QuerySubmitted_1(object sender, AutoSuggestBoxQuerySubmittedEventArgs e)
        {

        }
    }
}
