using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Web;
using HtmlAgilityPack;
using System.ServiceModel.Syndication;


namespace PALottoPick3
{
    class Program
    {
        static void Main(string[] args)
        {
            GetMidDay();
            GetEvening();

            Console.ReadLine();
        }

        private static void GetMidDay()
        {
            string url = "http://feeds.feedblitz.com/PennsylvaniaLottery-WinningNumbers-DailyNumberMid-Day";
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();

            foreach (SyndicationItem item in feed.Items)
            {
                if (item.PublishDate.ToString("MM-dd-yyyy") == DateTime.Today.ToString("MM-dd-yyyy"))
                {
                    var complete = item.Summary.Text.Substring(17, 12).Replace(" ", ",");
                    string[] delimiters = { "," };
                    string[] numbers = complete.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                    var ball1 = numbers[0];
                    var ball2 = numbers[1];
                    var ball3 = numbers[2];
                    var wild = numbers[4];

                    Console.WriteLine("Day Drawing");
                    Console.WriteLine("Publish Date: " + item.PublishDate.ToString("MM-dd-yyyy"));
                    Console.WriteLine("Ball 1: " + ball1);
                    Console.WriteLine("Ball 2: " + ball2);
                    Console.WriteLine("Ball 3: " + ball3);
                    Console.WriteLine("Wild: " + wild);
                }
                else
                {

                }
            }
        }

        private static void GetEvening()
        {
            string url = "http://feeds.feedblitz.com/PennsylvaniaLottery-WinningNumbers-DailyNumberEvening";
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();

            foreach (SyndicationItem item in feed.Items)
            {
                if (item.PublishDate.ToString("MM-dd-yyyy") == DateTime.Today.AddDays(-1).ToString("MM-dd-yyyy"))
                //if (item.PublishDate.ToString("MM-dd-yyyy") == DateTime.Today.ToString("MM-dd-yyyy"))
                {
                    var complete = item.Summary.Text.Substring(17, 12).Replace(" ", ",");
                    string[] delimiters = { "," };
                    string[] numbers = complete.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                    var ball1 = numbers[0];
                    var ball2 = numbers[1];
                    var ball3 = numbers[2];
                    var wild = numbers[4];

                    Console.WriteLine("Evening Drawing");
                    Console.WriteLine("Publish Date: " + item.PublishDate.ToString("MM-dd-yyyy"));
                    Console.WriteLine("Ball 1: " + ball1);
                    Console.WriteLine("Ball 2: " + ball2);
                    Console.WriteLine("Ball 3: " + ball3);
                    Console.WriteLine("Wild: " + wild);
                }
                else
                {

                }
            }
        }
    }
}
