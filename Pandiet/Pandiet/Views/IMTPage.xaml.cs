using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pandiet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IMTPage : ContentPage
    {
        public IMTPage()
        {
            InitializeComponent();
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double weight, height, IMT;
                if (Weight_Label.Text != "" && Height_Label.Text != "")
                {
                    weight = Convert.ToDouble(Weight_Label.Text);
                    height = Convert.ToDouble(Height_Label.Text);
                    if (weight > 0 && height > 0)
                    {
                        IMT = weight / (Math.Pow((height / 100), 2));
                        if (IMT <= 16)
                        {
                            IMTResult_Label.Text = "Выраженный дефицит массы тела";
                        }
                        else if (IMT <= 18.5)
                        {
                            IMTResult_Label.Text = "Недостаточная (дефицит) масса тела";
                        }
                        else if (IMT <= 25)
                        {
                            IMTResult_Label.Text = "Норма";
                        }
                        else if (IMT <= 30)
                        {
                            IMTResult_Label.Text = "Избыточная масса тела";
                        }
                        else if (IMT <= 35)
                        {
                            IMTResult_Label.Text = "Ожирение первой степени";
                        }
                        else if (IMT <= 40)
                        {
                            IMTResult_Label.Text = "Ожирение второй степени";
                        }
                        else if (IMT > 40)
                        {
                            IMTResult_Label.Text = "Ожирение третьей степени (морбидное)";
                        }
                    }
                    else
                    {
                        IMTResult_Label.Text = "Введены нулевые или отрицательные значения роста и веса!";
                    }
                }
            }
            catch (Exception ex)
            {
                Weight_Label.Text = "0";
                Height_Label.Text = "0";
            }
        }
    }
}