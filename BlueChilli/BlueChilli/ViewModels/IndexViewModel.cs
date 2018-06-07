using BlueChilli.Controls;
using BlueChilli.Models;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;

namespace BlueChilli.ViewModels
{
    public class IndexViewModel : BaseViewModel
    {
        private int tapCount = 0;
        private bool isDoubleTapping = false;
        private bool mode = false;
        Point location;
        AbsoluteLayout layout;

        public Command<Point> CanvasTappedCommand { get { return new Command<Point>((p) => OnCanvasTapped(p)); } }

        private ObservableCollection<View> itemSource;
        public ObservableCollection<View> ItemSource
        {
            get { return itemSource; }
            set { SetProperty(ref itemSource, value); }
        }



        public IndexViewModel(AbsoluteLayout layout)
        {
            this.layout = layout;
        }


        public void OnCanvasTapped(Point p)
        {
            location = p;
            if (tapCount < 1)
            {
                TimeSpan tt = new TimeSpan(0, 0, 0, 1, 500);
                Device.StartTimer(tt, isDoubleTappingCheck);
            }
            tapCount++;
        }

        bool isDoubleTappingCheck()
        {
            bool result = false;

            if (tapCount > 1)
            {
                result = true;
                mode = !mode;
            }
            else
                result = false;
                

            tapCount = 0;

            isDoubleTapping = result;

            var item = sendRequest();

            return result;
        }

        private async Task<Item> sendRequest()
        {
            Item item = new Item();

            HttpClient hTTPClient = new HttpClient();

            var response = await hTTPClient.GetAsync(new Uri("http://www.colourlovers.com/api/colors/random"));

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                XmlDocument xml = new XmlDocument(); 
                xml.LoadXml(content);
                XmlNodeList xnList = xml.GetElementsByTagName("color"); 

                foreach (XmlNode xn in xnList)
                {
                    item.id = xn["id"].InnerText;
                    item.hex = xn["hex"].InnerText;
                    item.dateCreated = xn["dateCreated"].InnerText;
                    item.red = xn["rgb"]["red"].InnerText;
                    item.green = xn["rgb"]["green"].InnerText;
                    item.blue = xn["rgb"]["blue"].InnerText;
                    //item.length = Convert.ToInt32(GetRandomNumber(50, layout.Height == 0 ? 50 : layout.Height / 2));
                    item.length = Convert.ToInt32(GetRandomNumber(30, 70));

                }

                if (mode)
                {
                    var topBox = new BoxView { Color = Color.FromHex("#" + item.hex) };
                    AbsoluteLayout.SetLayoutBounds(topBox, new Rectangle(location.X, location.Y, item.length, item.length));
                    layout.Children.Add(topBox);
                }
                else
                {
                    var topBox = new CustomBoxView { Color = Color.FromHex("#" + item.hex), CornerRadius = item.length };
                    AbsoluteLayout.SetLayoutBounds(topBox, new Rectangle(location.X, location.Y, item.length, item.length));
                    layout.Children.Add(topBox);
                }

            }

            return item;
        }

        private double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

    }

     

}
