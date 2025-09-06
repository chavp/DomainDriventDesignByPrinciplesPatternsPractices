using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Contracts.WeatherForecast
{
    public class WeatherForecastDataBuilder
    {
        DateOnly _date;
        int _temperatureC;
        int _temperatureF;
        string? _summary;

        private WeatherForecastDataBuilder() { }
        
        public static WeatherForecastDataBuilder Empty => new WeatherForecastDataBuilder();

        public WeatherForecastDataBuilder Date(DateOnly date)
        {
            _date = date;
            return this;
        }

        public WeatherForecastDataBuilder TemperatureC(int temperatureC)
        {
            _temperatureC = temperatureC;
            _temperatureF = 32 + (int)(temperatureC / 0.5556);
            return this;
        }
        public WeatherForecastDataBuilder Summary(string? summary)
        {
            _summary = summary;
            return this;
        }

        public WeatherForecastData Buid() => new WeatherForecastData
        {
            Date = _date,
            Summary = _summary,
            TemperatureC = _temperatureC,
            TemperatureF = _temperatureF,
        };


    }
}
