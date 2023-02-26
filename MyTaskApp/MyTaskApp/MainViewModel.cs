using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyTaskApp
{
    internal class MainViewModel : BindableObject
    {
        private ICommand _setOnCommand;

        public ICommand SetOnCommand
        {
            get
            {
                if (_setOnCommand == null)
                    _setOnCommand = new Command<object>(
                        async o =>
                        {
                            try
                            {
                                // Turn On
                                await Flashlight.TurnOnAsync();

                                // Turn Off

                            }
                            catch (FeatureNotSupportedException fnsEx)
                            {
                                // Handle not supported on device exception
                            }
                            catch (PermissionException pEx)
                            {
                                // Handle permission exception
                            }
                            catch (Exception ex)
                            {
                                // Unable to turn on/off flashlight
                            }
                        });
                return _setOnCommand;
            }

        }

        private ICommand _setOffCommand;

        public ICommand SetOffCommand
        {
            get
            {
                if (_setOffCommand == null)
                    _setOffCommand = new Command<object>(
                        async o =>
                        {
                            try
                            {
                                await Flashlight.TurnOffAsync();
                            }
                            catch (FeatureNotSupportedException fnsEx)
                            {
                                // Handle not supported on device exception
                            }
                            catch (PermissionException pEx)
                            {
                                // Handle permission exception
                            }
                            catch (Exception ex)
                            {
                                // Unable to turn on/off flashlight
                            }
                        });
                return _setOffCommand;
            }

        }


        private string _latitude;
        public string Latitude
        {
            get { return _latitude; }
            set { _latitude = value;
                OnPropertyChanged(nameof(Latitude));

            }
        }

        private string _longitude;
        public string Longitude
        {
            get { return _longitude; }
            set { _longitude = value;
            OnPropertyChanged(nameof(Longitude));
            }
        }

        private string _altitude;
        public string Altitude
        {
            get { return _altitude; }
            set { _altitude = value; 
            OnPropertyChanged(nameof(Altitude));
            }
        }

        private ICommand _location;

        public ICommand Location
        {
            get
            {

                if (_location == null)
                    _location = new Command<object>(
                        async o =>
                        {
                            try
                            {
                               
                                var location = await Geolocation.GetLocationAsync();

                                if (location != null)
                                {
                                    Latitude = location.Latitude.ToString();
                                    Longitude = location.Longitude.ToString();
                                    Altitude = location.Altitude.ToString();    
                                }
                            }
                            catch (FeatureNotSupportedException fnsEx)
                            {
                                // Handle not supported on device exception
                            }
                            catch (FeatureNotEnabledException fneEx)
                            {
                                // Handle not enabled on device exception
                            }
                            catch (PermissionException pEx)
                            {
                                // Handle permission exception
                            }
                            catch (Exception ex)
                            {
                                // Unable to get location
                            }
                        });
                return _location;

            }
        }



        private ICommand _tts;
            
        public  ICommand TTS
        {
            get {
               
            {
                    if (_tts == null)
                        _tts = new Command<object>(
                            async o =>
                            {
                                await TextToSpeech.SpeakAsync("Hello World");
                            });
                    return _setOffCommand;
                }
            }
            
        }

    }
}
