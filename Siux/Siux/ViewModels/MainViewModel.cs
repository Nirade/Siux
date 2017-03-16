using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Siux.Views;
using Xamarin.Forms;

namespace Siux.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Variables privadas

        private string _message;
        private string _liveMessage;
        private int count;
        string _countDisplay = "You clicked 0 times.";

        private double _beforeTax;
        private double _afterTax;
        private double _tipPercent;
        private double _tipAmount;
        private double _total;

        #endregion

        #region Load
        public MainViewModel()
        {
            Message = "Xiux App 2017";
            IncreaseCountCommand = new Command(IncreaseCount);
            ChangeMoneyCommand = new Command(ChangeMoney);
            ChangeTipPercentCommand = new Command(ChangeTipPercent);

            cargarDatosPrueba();

            

        }

        void cargarDatosPrueba()
        {
            Zoos = new ObservableCollection<HorizontalMenu>
            {
                new HorizontalMenu
                {
                    ImageUrl = "http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/23c1dd13-333a-459e-9e23-c3784e7cb434/2016-06-02_1049.png",
                    Name = "Woodland Park Zoo",
                    Bio = "Bio Woodland Zoo",
                    Col = 0
                },
                new HorizontalMenu
                {
                    ImageUrl =    "http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/6b60d27e-c1ec-4fe6-bebe-7386d545bb62/2016-06-02_1051.png",
                    Name = "Cleveland Zoo",
                    Bio = "Bio Cleveland Zoo",
                    Col = 1
                },
                new HorizontalMenu
                {
                    ImageUrl = "http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/e8179889-8189-4acb-bac5-812611199a03/2016-06-02_1053.png",
                    Name = "Phoenix Zoo",
                    Bio = "Bio Phoenix Zoo",
                    Col = 2
                }
            };
        }

        #endregion

        #region Propiedades

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        public string LiveMessage
        {
            get { return _liveMessage; }
            set
            {
                _liveMessage = value;
                OnPropertyChanged();
            }
        }
               

        public string CountDisplay
        {
            get { return _countDisplay; }
            set
            {
                _countDisplay = value;
                OnPropertyChanged();
            }
        }

        public ICommand IncreaseCountCommand { get; set; }
        public ICommand ChangeMoneyCommand { get; set; }
        public ICommand ChangeTipPercentCommand { get; set; }
        //public event EventHandler txtMoney_TextChanged;

        //void txtMoney_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    ChangeMoney();
        //}



        public double BeforeTax
        {
            get { return _beforeTax; }
            set
            {
                _beforeTax = value;
            }
        }
        public double AfterTax
        {
            get { return _afterTax; }
            set
            {
                _afterTax = value;
                OnPropertyChanged();
            }
        }
        public double TipPercent
        {
            get { return _tipPercent; }
            set
            {
                _tipPercent = value;
                OnPropertyChanged();
            }
        }
        public double TipAmount
        {
            get { return _tipAmount; }
            set
            {
                _tipAmount = value;
                OnPropertyChanged();
            }
        }
        public double Total
        {
            get { return _total; }
            set
            {
                _total = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<HorizontalMenu> Zoos { get; set; }


        #endregion

        #region Funciones
        void IncreaseCount()
        {
            CountDisplay = "You clicked " + ++count + "times";
        }
        public void ChangeMoney()
        {
            AfterTax = BeforeTax * 1.1;
            TipAmount = BeforeTax * TipPercent / 100;
            Total = BeforeTax + TipAmount;
        }
        void ChangeTipPercent()
        {
            TipAmount = BeforeTax * TipPercent / 100;
            Total = AfterTax + TipAmount;
        }

        void pruevasGrid()
        {
            //Grid g = new Grid;
            //g.BackgroundColor = Color.Pink;   
            //g.WidthRequest = 48;
            //g.HeightRequest = 48;
            //g.VerticalOptions = LayoutOptions.End;
            //g.HorizontalOptions= LayoutOptions.Start;
            //g.TranslationX = AbsoluteLayout.GetLayoutBounds(LeftButton).Location.X; // para ponerlo justo despues de este control??
            //g.TranslationY = AbsoluteLayout.GetLayoutBounds(LeftButton).Location.Y; // para ponerlo jusro despues de este control??
            //PageSizedGrid.Children.Add(g); //para añadirlo a la pagina o vista que se quiera
        }


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion



        public class MyTemplateSelector : DataTemplateSelector
        {
            private readonly DataTemplate templateOne;
            private readonly DataTemplate templateTwo;

            public MyTemplateSelector()
            {
                this.templateOne = new DataTemplate(typeof(MainView));
                //this.templateTwo = new DataTemplate(typeof(MainView));
            }

            protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
            {
                //if ((int)item % 2 == 0)
                //return templateTwo;
                return templateOne;
            }
        }

    }
}
