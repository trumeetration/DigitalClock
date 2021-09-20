using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Clock
{
    public partial class MainPage : ContentPage
    {
        int[,,] numberMatrix = new int[10, 7, 5]
        {
            {
                {0, 1, 1, 1, 0}, {1, 0, 0, 0, 1}, {1, 0, 0, 0, 1}, {1, 0, 0, 0, 1}, {1, 0, 0, 0, 1}, {1, 0, 0, 0, 1},
                {0, 1, 1, 1, 0}
            },
            {
                {0, 0, 1, 0, 0}, {0, 1, 1, 0, 0}, {0, 0, 1, 0, 0}, {0, 0, 1, 0, 0}, {0, 0, 1, 0, 0}, {0, 0, 1, 0, 0},
                {0, 1, 1, 1, 0}
            },
            {
                {0, 1, 1, 1, 0}, {1, 0, 0, 0, 1}, {0, 0, 0, 0, 1}, {0, 0, 0, 1, 0}, {0, 0, 1, 0, 0}, {0, 1, 0, 0, 0},
                {1, 1, 1, 1, 1}
            },
            {
                {0, 1, 1, 1, 0}, {1, 0, 0, 0, 1}, {0, 0, 0, 0, 1}, {0, 0, 1, 1, 0}, {0, 0, 0, 0, 1}, {1, 0, 0, 0, 1},
                {0, 1, 1, 1, 0},
            },
            {
                {0, 0, 0, 1, 0}, {0, 0, 1, 1, 0}, {0, 1, 0, 1, 0}, {1, 0, 0, 1, 0}, {1, 1, 1, 1, 1}, {0, 0, 0, 1, 0},
                {0, 0, 0, 1, 0}
            },
            {
                {1, 1, 1, 1, 1}, {1, 0, 0, 0, 0}, {1, 1, 1, 1, 0}, {0, 0, 0, 0, 1}, {0, 0, 0, 0, 1}, {1, 0, 0, 0, 1},
                {0, 1, 1, 1, 0}
            },
            {
                {0, 0, 1, 1, 0}, {0, 1, 0, 0, 0}, {1, 0, 0, 0, 0}, {1, 1, 1, 1, 0}, {1, 0, 0, 0, 1}, {1, 0, 0, 0, 1},
                {0, 1, 1, 1, 0}
            },
            {
                {1, 1, 1, 1, 1}, {0, 0, 0, 0, 1}, {0, 0, 0, 1, 0}, {0, 0, 1, 0, 0}, {0, 1, 0, 0, 0}, {0, 1, 0, 0, 0},
                {0, 1, 0, 0, 0}
            },
            {
                {0, 1, 1, 1, 0}, {1, 0, 0, 0, 1}, {1, 0, 0, 0, 1}, {0, 1, 1, 1, 0}, {1, 0, 0, 0, 1}, {1, 0, 0, 0, 1},
                {0, 1, 1, 1, 0}
            },
            {
                {0, 1, 1, 1, 0}, {1, 0, 0, 0, 1}, {1, 0, 0, 0, 1}, {0, 1, 1, 1, 1}, {0, 0, 0, 0, 1}, {0, 0, 0, 1, 0},
                {0, 1, 1, 0, 0}
            }
        };

        private int _hourHigh = -1;
        private int _hourLow = -1;
        private int _minHigh = -1;
        private int _minLow = -1;
        private int _secHigh = -1;
        private int _secLow = -1;
        private BoxView[,,] digitDotBoxViews = new BoxView[6, 7, 5];

        public MainPage()
        {
            InitializeComponent();
            Grid dotsFirst = GetDoubleDotGrid();
            Grid dotsSecond = GetDoubleDotGrid();
            Grid[] timeGrids = new Grid[8];
            for (int i = 0; i < 6; i++)
            {
                timeGrids[i] = new Grid
                {
                    RowDefinitions =
                    {
                        new RowDefinition {Height = new GridLength(15, GridUnitType.Absolute)},
                        new RowDefinition {Height = new GridLength(15, GridUnitType.Absolute)},
                        new RowDefinition {Height = new GridLength(15, GridUnitType.Absolute)},
                        new RowDefinition {Height = new GridLength(15, GridUnitType.Absolute)},
                        new RowDefinition {Height = new GridLength(15, GridUnitType.Absolute)},
                        new RowDefinition {Height = new GridLength(15, GridUnitType.Absolute)},
                        new RowDefinition {Height = new GridLength(15, GridUnitType.Absolute)}
                    },
                    ColumnDefinitions =
                    {
                        new ColumnDefinition {Width = new GridLength(15, GridUnitType.Absolute)},
                        new ColumnDefinition {Width = new GridLength(15, GridUnitType.Absolute)},
                        new ColumnDefinition {Width = new GridLength(15, GridUnitType.Absolute)},
                        new ColumnDefinition {Width = new GridLength(15, GridUnitType.Absolute)},
                        new ColumnDefinition {Width = new GridLength(15, GridUnitType.Absolute)}
                    },
                    ColumnSpacing = 0,
                    RowSpacing = 0
                };
                for (int j = 0; j < 7; j++)
                for (int k = 0; k < 5; k++)
                {
                    BoxView boxView = new BoxView()
                    {
                        Color = Color.Aquamarine,
                        WidthRequest = 15,
                        HeightRequest = 15
                    };
                    digitDotBoxViews[i, j, k] = boxView;
                    timeGrids[i].Children.Add(boxView, k, j);
                }
            }

            this.Content = new StackLayout()
            {
                Children = {timeGrids[0], timeGrids[1], dotsFirst, timeGrids[2], timeGrids[3], dotsSecond, timeGrids[4], timeGrids[5]},
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            Device.StartTimer(TimeSpan.FromMilliseconds(100), UpdateTime);
        }

        private bool UpdateTime()
        {
            var time = DateTime.Now;
            var hourHigh = time.Hour / 10;
            var hourLow = time.Hour % 10;
            var minuteHigh = time.Minute / 10;
            var minuteLow = time.Minute % 10;
            var secondHigh = time.Second / 10;
            var secondLow = time.Second % 10;
            if (hourHigh != _hourHigh)
            {
                SetGridNumber(0, hourHigh);
                _hourHigh = hourHigh;
            }
            if (hourLow != _hourLow)
            {
                SetGridNumber(1, hourLow);
                _hourLow = hourLow;
            }
            if (minuteHigh != _minHigh)
            {
                SetGridNumber(2, minuteHigh);
                _minHigh = minuteHigh;
            }
            if (minuteLow != _minLow)
            {
                SetGridNumber(3, minuteLow);
                _minLow = minuteLow;
            }
            if (secondHigh != _secHigh)
            {
                SetGridNumber(4, secondHigh);
                _secHigh = secondHigh;
            }
            if (secondLow != _secLow)
            {
                SetGridNumber(5, secondLow);
                _secLow = secondLow;
            }
            return true;
        }

        Grid GetDoubleDotGrid()
        {
            Grid doubleDotsGrid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition {Height = new GridLength(15, GridUnitType.Absolute)},
                    new RowDefinition {Height = new GridLength(15, GridUnitType.Absolute)},
                    new RowDefinition {Height = new GridLength(15, GridUnitType.Absolute)},
                    new RowDefinition {Height = new GridLength(15, GridUnitType.Absolute)},
                    new RowDefinition {Height = new GridLength(15, GridUnitType.Absolute)},
                    new RowDefinition {Height = new GridLength(15, GridUnitType.Absolute)},
                    new RowDefinition {Height = new GridLength(15, GridUnitType.Absolute)},
                },
                RowSpacing = 0,
                Margin = 10
            };
            doubleDotsGrid.Children.Add(new BoxView()
            {
                Color = Color.Red,
                WidthRequest = 15,
                HeightRequest = 15
            }, 0, 1);
            doubleDotsGrid.Children.Add(new BoxView()
            {
                Color = Color.Red,
                WidthRequest = 15,
                HeightRequest = 15
            }, 0, 4);
            return doubleDotsGrid;
        }
        

        void SetGridNumber(int position, int digit)
        {
            for (int colIndex = 0; colIndex < 5; colIndex++)
            {
                for (int rowIndex = 0; rowIndex < 7; rowIndex++)
                {
                    if (numberMatrix[digit, rowIndex, colIndex] == 0)
                        digitDotBoxViews[position, rowIndex, colIndex].Color = Color.Aquamarine;
                    else
                        digitDotBoxViews[position, rowIndex, colIndex].Color = Color.Red;

                }

            }
        }
    }
}