using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Siux.Views
{
    public partial class BetGroupView : ContentView
    {
        public BetGroupView()
        {
            InitializeComponent();
            LoadView("");
        }

        private void btnSelection_click(object sender, EventArgs e)
        {
            if (((Button)sender).BackgroundColor != Color.Green)
                ((Button)sender).BackgroundColor = Color.Green;
            else
                ((Button)sender).BackgroundColor = Color.Default;
        }

        public void LoadView(string idView)
        {
            int iMin = 2;

            for (int i = iMin; i < 9; i++)
            {
                Grid masterGrid = new Grid();
                Label lblTitulo = new Label();
                Grid grid = new Grid();

                lblTitulo.BackgroundColor = Color.Gray;

                ColumnDefinition masterCol = new ColumnDefinition();
                masterCol.Width = GridLength.Star;
                masterGrid.ColumnDefinitions.Add(masterCol);

                RowDefinition rowTitle = new RowDefinition();
                rowTitle.Height = GridLength.Auto;
                RowDefinition rowGrid = new RowDefinition();
                rowGrid.Height = GridLength.Auto;
                masterGrid.RowDefinitions.Add(rowGrid);

                stkContent.Children.Add(masterGrid);
                masterGrid.Children.Add(lblTitulo, 0, 0);
                masterGrid.Children.Add(grid, 0, 1);

                ColumnDefinition colDefinitionGrid1 = new ColumnDefinition();
                colDefinitionGrid1.Width = GridLength.Star;
                grid.ColumnDefinitions.Add(colDefinitionGrid1);

                ColumnDefinition colDefinitionGrid2 = new ColumnDefinition();
                colDefinitionGrid2.Width = GridLength.Star;
                grid.ColumnDefinitions.Add(colDefinitionGrid2);

                ColumnDefinition colDefinitionGrid3 = new ColumnDefinition();
                colDefinitionGrid3.Width = GridLength.Star;
                grid.ColumnDefinitions.Add(colDefinitionGrid3);

                ColumnDefinition colDefinitionGrid4 = new ColumnDefinition();
                colDefinitionGrid4.Width = GridLength.Star;
                grid.ColumnDefinitions.Add(colDefinitionGrid4);

                ColumnDefinition colDefinitionGrid5 = new ColumnDefinition();
                colDefinitionGrid5.Width = GridLength.Star;
                grid.ColumnDefinitions.Add(colDefinitionGrid5);

                ColumnDefinition colDefinitionGrid6 = new ColumnDefinition();
                colDefinitionGrid6.Width = GridLength.Star;
                grid.ColumnDefinitions.Add(colDefinitionGrid6);

                lblTitulo.Text = "Pregunta de evento número " + i.ToString();
                for (int j = 0; j < i; j++)
                {
                    Button btnSelection = new Button();
                    btnSelection.Text = "XX YY";
                    btnSelection.Clicked += btnSelection_click;

                    if (i > 3)
                    {
                        if (i % 2 != 0)
                        {
                            RowDefinition rowDefinition = new RowDefinition();
                            rowDefinition.Height = GridLength.Auto; ;
                            grid.RowDefinitions.Add(rowDefinition);
                            grid.Children.Add(btnSelection, 0, i - iMin + j);
                            Grid.SetColumnSpan(btnSelection, 6);
                        }
                        else
                        {
                            if (j % 2 == 0)
                            {
                                RowDefinition rowDefinition = new RowDefinition();
                                rowDefinition.Height = GridLength.Auto; ;
                                grid.RowDefinitions.Add(rowDefinition);
                                grid.Children.Add(btnSelection, 0, (i - iMin) / 2 + j);
                                Grid.SetColumnSpan(btnSelection, 3);
                            }
                            else
                            {
                                RowDefinition rowDefinition = new RowDefinition();
                                rowDefinition.Height = GridLength.Auto; ;
                                grid.RowDefinitions.Add(rowDefinition);
                                grid.Children.Add(btnSelection, 3, ((i - iMin + 1) / 2) - 1 + j);
                                Grid.SetColumnSpan(btnSelection, 3);
                            }
                        }

                    }
                    else
                    {
                        if (j == 0)
                        {
                            RowDefinition rowDefinition = new RowDefinition();
                            rowDefinition.Height = GridLength.Auto; ;
                            grid.RowDefinitions.Add(rowDefinition);
                        }
                        grid.Children.Add(btnSelection, j * (6 / i), i - iMin);
                        Grid.SetColumnSpan(btnSelection, 6 / i);
                    }
                }
            }
        }
    }
}
