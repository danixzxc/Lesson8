using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    class WeatherModel
    {
        int t,p;
        public string TEMPERATURE { get { return $"{t.ToString()}℃"; } set { int.TryParse(value, out t); } }
        public string PRESSURE { get { return $"{p.ToString()}мм.рт.ст."; } set { int.TryParse(value, out p); }}

        public string CityName { get; set; }

        //public override string ToString()
        //{
        //    return $"{PRESSURE} мм.рт.ст. {TEMPERATURE} ℃";
        // }

    }
}
