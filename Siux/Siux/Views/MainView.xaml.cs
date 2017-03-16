using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Siux.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
    {
        #region Events
        public MainView()
        {
            InitializeComponent();
            BindingContext = new Siux.ViewModels.MainViewModel();
            LoadHorizontalMenu();

        }



        private void text_changed(object sender, TextChangedEventArgs e)
        {
            if (e.OldTextValue != null)
            {
                ViewModels.MainViewModel _mvm = ((ViewModels.MainViewModel)BindingContext);
                _mvm.ChangeMoney();
            }
        }

        #endregion

        #region Private functions
        private void LoadHorizontalMenu()
        {
            //<Label Grid.Row="{Binding Row}" Grid.Column="{Binding Col}" Margin="5,0,5,0" TextColor="#EEEEEE" Text="{Binding Row}" FontSize="12" FontAttributes="Bold" VerticalTextAlignment="Center" />
            List<HorizontalMenu> horizontalMenuList = GetDataHorizontalMenu();
            for (int i = 0; i < horizontalMenuList.Count; i++)
            {
                Label label = new Label();
                label.Text = horizontalMenuList[i].Name;
                label.Margin = new Thickness(5, 0, 5, 0);
                label.TextColor = Color.FromHex("#EEEEEE");
                label.FontSize = 12;
                label.FontAttributes = FontAttributes.Bold;
                label.VerticalTextAlignment = TextAlignment.Center;

                var tgr = new TapGestureRecognizer();
                tgr.Tapped += (s, e) => OnLabelClicked(s, e);
                label.GestureRecognizers.Add(tgr);

                
                HorizontalMenuGrid.Children.AddHorizontal(label);
                
            }
        }

        private List<HorizontalMenu> GetDataHorizontalMenu()
        {
            List<HorizontalMenu> horizontalMenuList = new List<HorizontalMenu> 
            { 
                new HorizontalMenu { Name = "Principales"},
                new HorizontalMenu { Name = "Asiáticos"},
                new HorizontalMenu { Name = "Tarjetas"},
                new HorizontalMenu { Name = "Goles"},
                new HorizontalMenu { Name = "Corners"},
                new HorizontalMenu { Name = "1ª/2ª Parte"},
                new HorizontalMenu { Name = "Jugadores"},
                new HorizontalMenu { Name = "Especiales"}
            };
            return horizontalMenuList;
        }

        private void OnLabelClicked(object sender, EventArgs e)
        {
            DisplayAlert("alerta", "click!", "ok");
        }

        private void mainScroll_Scrolled(object sender, EventArgs e)
        {
            if (scrollMenu.Y - scrollMain.ScrollY <= 0)
            {
                scrollMenu.ScrollToAsync(0, 0, true);
                DisplayAlert("alerta", "scroll!", "ok");
            }
        }

        #endregion
    }





    public class HorizontalMenu
    {
        public string ImageUrl { get; set; }
        public string Bio { get; set; }
        public string Name { get; set; }
        public int Col { get; set; }
        public int Row { get; set; }
    }
}
