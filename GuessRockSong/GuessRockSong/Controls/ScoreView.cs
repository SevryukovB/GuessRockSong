using GuessRockSong.Helpers;
using Xamarin.Forms;

namespace GuessRockSong.Controls
{
    class ScoreView : AbsoluteLayout
    {
        public static readonly BindableProperty PointsProperty =
        BindableProperty.Create("Points", // название обычного свойства
            typeof(int), // возвращаемый тип 
            typeof(ScoreView), // тип,  котором объявляется свойство
            0,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: OnEventPointsChanged
        );

        public int Points
        {
            set
            {
                SetValue(PointsProperty, value);
            }
            get
            {
                return (int)GetValue(PointsProperty);
            }
        }

        static void OnEventPointsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var spaceLayout = (ScoreView)bindable;
            spaceLayout.Points = (int)newValue;
        }

        public static readonly BindableProperty GenreIdProperty =
        BindableProperty.Create("GenreId", // название обычного свойства
            typeof(int), // возвращаемый тип 
            typeof(ScoreView), // тип,  котором объявляется свойство
            0,
            defaultBindingMode: BindingMode.TwoWay
        );

        public int GenreId
        {
            set
            {
                SetValue(GenreIdProperty, value);
            }
            get
            {
                return (int)GetValue(GenreIdProperty);
            }
        }

        public static readonly BindableProperty CustomVisibleProperty =
        BindableProperty.Create("CustomVisible", // название обычного свойства
            typeof(bool), // возвращаемый тип 
            typeof(ScoreView), // тип,  котором объявляется свойство
            false,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: OnVisibleChanged
        );

        public bool CustomVisible
        {
            set
            {
                SetValue(CustomVisibleProperty, value);
            }
            get
            {
                return (bool)GetValue(CustomVisibleProperty);
            }
        }

        private static void OnVisibleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //await Task.Delay(100);
            if ((bool)oldValue != false) return;
            var spaceLayout = (ScoreView)bindable;
            spaceLayout.IsVisible = true;

            if (WriteScore(spaceLayout.GenreId, spaceLayout.Points))
            {
                spaceLayout.label1.Text = $"Congratilations! Your new score";
            }
            else
            {
                spaceLayout.label1.Text = "Your score";
            }
            spaceLayout.label2.Text = $"{spaceLayout.Points}";

        }

        private static bool WriteScore(int genreId, int currentPoints)
        {
            var score = Data.GetScore(genreId);
            if (currentPoints > score.Points)
            {
                score.Points = currentPoints;
                Data.WriteScore(score);
                return true;
            }
            return false;
        }

        Label label1 = new Label { FontSize = 24, TextColor = Color.White, FontFamily = "Roboto-Light.ttf#Roboto-Light", HorizontalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center };
        Label label2 = new Label { FontSize = 30, TextColor = Color.FromHex("#f93c6a"), FontFamily = "Roboto-Thin.ttf#Roboto-Thin", HorizontalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center };

        public ScoreView()
        {
            IsVisible = false;
            BackgroundColor = new Color(0, 0, 0, 0.8);
            HeightRequest = Application.Current.MainPage.Height;
            WidthRequest = Application.Current.MainPage.Width;

            Image triangle1 = new Image { Source = "Triangle1.png" };
            Image circle1 = new Image { Source = "Circle1.png" };
            Image circle2 = new Image { Source = "Circle2.png" };
            Image wave1 = new Image { Source = "Wave1.png" };
            Image circle3 = new Image { Source = "Circle3.png" };
            StackLayout stack = new StackLayout { Children = { label1, label2 }, WidthRequest = Application.Current.MainPage.Width };
            Image circle4 = new Image { Source = "Circle4.png" };
            Image wave2 = new Image { Source = "Wave2.png" };
            Image triangle2 = new Image { Source = "Triangle2.png" };
            Image circle5 = new Image { Source = "Circle5.png" };
            Image triangle3 = new Image { Source = "Triangle3.png" };

            SetLayoutBounds(triangle1, new Rectangle(GetСoordinateX(7), GetСoordinateY(10), AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            SetLayoutBounds(circle1, new Rectangle(GetСoordinateX(50), GetСoordinateY(4), AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            SetLayoutBounds(circle2, new Rectangle(GetСoordinateX(90), GetСoordinateY(12), AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            SetLayoutBounds(wave1, new Rectangle(GetСoordinateX(18), GetСoordinateY(20), AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            SetLayoutBounds(circle3, new Rectangle(GetСoordinateX(10), GetСoordinateY(34), AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            SetLayoutBounds(stack, new Rectangle(0, GetСoordinateY(40), AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            SetLayoutBounds(circle4, new Rectangle(GetСoordinateX(80), GetСoordinateY(50), AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            SetLayoutBounds(wave2, new Rectangle(0, GetСoordinateY(53), AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            SetLayoutBounds(triangle2, new Rectangle(GetСoordinateX(5), GetСoordinateY(75), AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            SetLayoutBounds(circle5, new Rectangle(GetСoordinateX(55), GetСoordinateY(70), AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            SetLayoutBounds(triangle3, new Rectangle(GetСoordinateX(78), GetСoordinateY(80), AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            Children.Add(triangle1);
            Children.Add(circle1);
            Children.Add(circle2);
            Children.Add(wave1);
            Children.Add(circle3);
            Children.Add(stack);
            Children.Add(circle4);
            Children.Add(wave2);
            Children.Add(triangle2);
            Children.Add(circle5);
            Children.Add(triangle3);
        }

        private double GetСoordinateX(double perecent) => Application.Current.MainPage.Width * perecent / 100;
        private double GetСoordinateY(double perecent) => Application.Current.MainPage.Height * perecent / 100;
    }
}
