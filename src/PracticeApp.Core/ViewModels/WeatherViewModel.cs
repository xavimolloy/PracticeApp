using System;
using System.Collections.Generic;
using System.Text;
using PracticeApp.Core.Services;
using Xamarin.Forms;
using MvvmCross.Binding;
using PracticeApp.Core.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Acr.UserDialogs;
using dotMorten.Xamarin.Forms;





namespace PracticeApp.Core.ViewModels
{
    public class WeatherViewModel : BaseViewModel , INotifyPropertyChanged
    {
        RestService _restService;
        public string cityEntry;
        public event PropertyChangedEventHandler PropertyChanged;
        public WeatherData weatherData;
        public string cloudsAll;

        #region atributes and setters and getters
        public string CloudsAll
        {
            get => cloudsAll;
            set
            {
                cityEntry = value;
                OnPropertyChanged();
            }
        }
        public string longitude;
        public string Longitude
        {
            get => longitude;
            set
            {
                longitude = value;
                OnPropertyChanged();
            }
        }
        public string latitude;
        public string Latitude
        {
            get => latitude;
            set
            {
                latitude = value;
                OnPropertyChanged();
            }
        }


        public string pressure;
        public string Pressure
        {
            get => pressure;
            set
            {
                pressure = value;
                OnPropertyChanged();
            }
        }

        public string humidity;
        public string Humidity
        {
            get => humidity;
            set
            {
                humidity = value;
                OnPropertyChanged();
            }
        }
        public string tempMin;

        public string TempMin
        {
            get => tempMin;
            set
            {
                tempMin = value;
                OnPropertyChanged();
            }
        }
        public string tempMax;
        public string TempMax
        {
            get => tempMax;
            set
            {
                tempMax = value;
                OnPropertyChanged();
            }
        }
        public string type;
        public string Type
        {
            get => type;
            set
            {
                type = value;
                OnPropertyChanged();
            }
        }


        public string sysId;
        public string SysId
        {
            get => sysId;
            set
            {
               sysId = value;
                OnPropertyChanged();
            }
        }

        public string messagge;
        public string Messagge
        {
            get => messagge;
            set
            {
                messagge = value;
                OnPropertyChanged();
            }
        }

        public string country;
        public string Country
        {
            get => country;
            set
            {
                country = value;
                OnPropertyChanged();
            }
        }
        public string sunrise;
        public string Sunrise
        {
            get => sunrise;
            set
            {
                sunrise = value;
                OnPropertyChanged();
            }
        }

        public string sunset;
        public string Sunset
        {
            get => sunset;
            set
            {
                sunset = value;
                OnPropertyChanged();
            }
        }

        public string weatherId;
        public string WeatherId
        {
            get => weatherId;
            set
            {
                weatherId= value;
                OnPropertyChanged();
            }
        }

        public string visibility;
        public string Visibility
        {
            get => visibility;
            set
            {
                visibility= value;
                OnPropertyChanged();
            }
        }

        public string description;
        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }

        public string icon;

        public string Icon
        {
            get => icon;
            set
            {
                icon = value;
                OnPropertyChanged();
            }
        }

        public string windSpeed;
        public string WindSpeed
        {
            get => windSpeed;
            set
            {
                windSpeed = value;
                OnPropertyChanged();
            }
        }

        public string windSeg;
        public string WindSeg
        {
            get => windSeg;
            set
            {
                windSeg = value;
                OnPropertyChanged();
            }
        }



        public string temperatureLabel;


        public string CityEntry {
            get => cityEntry;
            set { cityEntry = value;
                OnPropertyChanged();
            }
        }


       

        public string TemperatureLabel
        {
            get => temperatureLabel;
            set
            {
                temperatureLabel = weatherData.Main.Temperature.ToString();
                OnPropertyChanged();
            }
        }

        #endregion

        public WeatherViewModel()
          {
             Initialize();
              _restService = new RestService();
           }



        private Command _getWeatherButton;

        public Command GetWeatherButton =>
         _getWeatherButton ?? (_getWeatherButton = new Command(GetWeather));

        public  async void GetWeather()
        {
                    if (!string.IsNullOrWhiteSpace(CityEntry))
                    {
                        string requestUri = "https://api.openweathermap.org/data/2.5/weather" + $"?q={CityEntry}" + "&units=metric" + $"&APPID=6a2ca32df59207872924371f8653bfb4";
                         weatherData = await _restService.GetWeatherData(requestUri);
                           UserDialogs.Instance.Alert("La temperatura en " + CityEntry + " es de: " + weatherData.Main.Temperature.ToString() + " grados. ",
                           "Hey", "Ok");
                          TemperatureLabel = weatherData.Main.Temperature.ToString();
                          CloudsAll = weatherData.Clouds.All.ToString();
                          Longitude = weatherData.Coord.Lon.ToString();
                         Latitude = weatherData.Coord.Lat.ToString();
                         Pressure = weatherData.Main.Pressure.ToString();
                         Humidity = weatherData.Main.Humidity.ToString();
                           TempMin = weatherData.Main.TempMin.ToString();
                           TempMax = weatherData.Main.TempMax.ToString();
                          sysId= weatherData.Sys.Id.ToString();
                          Type = weatherData.Sys.Type.ToString();
                         Messagge = weatherData.Sys.Message.ToString();
                         Country = weatherData.Sys.Country.ToString();
                           Sunrise = weatherData.Sys.Sunrise.ToString();
                          Sunset = weatherData.Sys.Sunset.ToString();
                         WindSpeed = weatherData.Wind.Speed.ToString();
                         WindSeg = weatherData.Wind.Deg.ToString();

                    }



        }
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private async void SuggestBox_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs args)
        {
            AutoSuggestBox box = (AutoSuggestBox)sender;
            // Only get results when it was a user typing, 
            // otherwise assume the value got filled in by TextMemberPath 
            // or the handler for SuggestionChosen.
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                if (string.IsNullOrWhiteSpace(box.Text) || box.Text.Length < 3)
                    box.ItemsSource = null;
                else
                {
                    var suggestions = await GetSuggestions(box.Text);
                    box.ItemsSource = suggestions.ToList();
                }
            }
        }



    }




}

