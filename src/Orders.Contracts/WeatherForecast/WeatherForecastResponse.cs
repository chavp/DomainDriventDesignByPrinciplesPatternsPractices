using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Contracts.WeatherForecast
{
    public class WeatherForecastResponse
    {
        public WeatherForecastData[] WeatherForecasts { get; set; }
    }
}
