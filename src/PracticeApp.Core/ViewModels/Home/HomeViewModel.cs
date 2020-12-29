using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Xamarin.Forms;
using MvvmCross.Forms;
using MvvmCross;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MvvmCross.ViewModels;
using Acr.UserDialogs;
using MvvmCross.Navigation;

namespace PracticeApp.Core.ViewModels.Home
{
    public class HomeViewModel :  BaseViewModel, INotifyPropertyChanged
    {
        
        //Commands for Mvvm usage and example
        private Command _wellDoneMessagge;
        
        public Command WellDoneMessagge =>
         _wellDoneMessagge ?? (_wellDoneMessagge = new Command(Congratulate));

        private Command _goToWeather;

        public Command GoToWeather =>
            _goToWeather ?? (_goToWeather = new Command(TravelToWeather));
        
        public event PropertyChangedEventHandler PropertyChanged;

        public HomeViewModel()
        {

        }
        public string textOnEntry = "Try writing something";
        

        public string EntryTextBind
        {
            get
            {
                return $"{TextOnEntry}";
            }

        }

        public string TextOnEntry
        {
            get =>textOnEntry;
            set
            {
                textOnEntry = value;
                 OnPropertyChanged();
                OnPropertyChanged(nameof(EntryTextBind));
               
            }
        }
        public void OnPropertyChanged([CallerMemberName] string name="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void TravelToWeather()
        {
            Mvx.IoCProvider.Resolve<IMvxNavigationService>().Navigate<WeatherViewModel>();
            
        }
        public void Congratulate()
        {
            UserDialogs.Instance.Alert("well done, next we will try do do a page with a an observable collection",
             "We are just starting" +
             "that displays information using an api", "Can't wait");
        }
  
    }

}

 
