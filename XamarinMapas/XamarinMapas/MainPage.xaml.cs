using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;


namespace XamarinMapas
{
    public partial class MainPage : ContentPage
    {
        private String mapSessionToken;

        public MainPage()
        {
            InitializeComponent();
            mapSessionToken = PlaceSearchRemoteService.CreateSessionToken();
        }

        private async void ButtonGetLocation_Clicked(object sender, EventArgs e)
        {
            await RetrieveLocation();
        }

        private async Task RetrieveLocation()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                LabelLat.Text = location.Latitude.ToString();
                LabelLong.Text = location.Longitude.ToString();

                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude)
                    , Distance.FromKilometers(2)));
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Handle not supported on device exception",
                    fnsEx.Message, "Ok");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Handle permission exception",
                pEx.Message, "Ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Unable to get location",
                ex.Message, "Ok");
            }
        }

        private async void edtBusca_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Pega o texto
            String text = edtBusca.Text;
            if (text.Length < 10)
                return;
            //Usa a API do google pra pegar os matches
            PlaceSearchRemoteService searchService = new PlaceSearchRemoteService();
            await searchService.Lookup(text, mapSessionToken);
            //Pra cada match, pegar a posição espacial
            //pra cada posição espacial, marcar
        }
    }
}
