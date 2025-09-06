using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Contracts.WeatherForecast
{
    public class WeatherForecastData
    {
        internal WeatherForecastData() { }

        public DateOnly Date { get; init; }

        public int TemperatureC { get; init; }

        public int TemperatureF { get; init; }

        public string? Summary { get; init; }
    }
}
