using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WpfApp
{
    class DataProvider
    {
        static Dictionary<string, string> urls;

        static DataProvider()
        {
            urls = new Dictionary<string, string>();
            urls.Add("Киев", @"https://xml.meteoservice.ru/export/gismeteo/point/37.xml");
            urls.Add("Минск", @"https://xml.meteoservice.ru/export/gismeteo/point/113.xml");
        }

        HttpClient httpClient;

        public DataProvider()
        {
            httpClient = new HttpClient();
        }

        public ObservableCollection<WeatherModel> GetWetherModels()
        {
            ObservableCollection<WeatherModel> temp = new ObservableCollection<WeatherModel>();

            foreach (var url in urls)
            {
                var req = httpClient.GetStringAsync(url.Value).Result;
                //Debug.WriteLine(req);
                var colWeather = XDocument.Parse(req)
                                      .Descendants("MMWEATHER")
                                      .Descendants("REPORT")
                                      .Descendants("TOWN")
                                      .Descendants("FORECAST")
                                      .ToList();

                foreach (var FORECAST in colWeather)
                {
                    temp.Add(
                        new WeatherModel()
                        {
                            CityName = url.Key,
                            PRESSURE = FORECAST.Element("PRESSURE").Attribute("max").Value,
                            TEMPERATURE = FORECAST.Element("TEMPERATURE").Attribute("max").Value
                        }
                        );
                }

            }

            return temp;
        }


    }
}
