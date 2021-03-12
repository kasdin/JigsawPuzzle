using Plugin.ImageEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JigsawPuzzle
{
    public partial class MainPage : ContentPage
    {
        private ImageSource horseImageSource = "horse.JPG";

        public object StackMain { get; private set; }

        public MainPage()
        {
            InitializeComponent();
        }


        private void StartGameHorse(object sender, EventArgs e)
        {
            int column = 0;
            int row = 0;
            int angle = 0;
            Image imageSwitch = null;
            Image imageSwitch1 = null;
            PictureGrid.IsVisible = false;
            MainGrid.IsVisible = true;
            List<Image>test = new List<Image>();
            for (int i = 1; i <= 9; i++)
            {
                if (i == 4 || i == 7 )
                {
                    column++;
                    row = 0; 
                }
                Random ran = new Random();
                Image image = new Image();
                image.Source = "ho" + ran.Next(1,9) + ".jpg";
                while (MainGrid.Children.Contains(image))
                {
                    image.Source = "ho" + ran.Next(1, 9) + ".jpg";
                }


                image.HorizontalOptions = LayoutOptions.CenterAndExpand;
                image.VerticalOptions = LayoutOptions.CenterAndExpand;

                var tapGestureRecognizer2 = new TapGestureRecognizer();
                tapGestureRecognizer2.Tapped += (s, ee) =>
                {
                    Console.WriteLine("Image has been tapped 2 times");
                    angle += 90;
                    if (angle >= 361)
                    {
                        angle = 0; 
                    }

                    ((Image) s).RotateTo(angle);
                };
                image.GestureRecognizers.Add(tapGestureRecognizer2);
                tapGestureRecognizer2.NumberOfTapsRequired = 2; 
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (s, ee) =>
                {
                    Console.WriteLine("Image has been tapped 1 times");
                    
                };
                image.GestureRecognizers.Add(tapGestureRecognizer);
                tapGestureRecognizer.NumberOfTapsRequired = 1; 
                MainGrid.Children.Add(image, row, column);
                row++;
                
            }









        }
        int angle = 0;

        private void rotateButton_Clicked(object sender, EventArgs e)
        {

            angle += 90;
            //imageProfile.RotateX(angle);
        }

        private void StartGameHead(object sender, EventArgs e)
        {
            PictureGrid.IsVisible = false;
            //MainGrid.IsVisible = true;
            

        }
    }
}
