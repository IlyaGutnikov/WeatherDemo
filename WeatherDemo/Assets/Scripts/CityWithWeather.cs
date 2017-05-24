using System.Collections;
using System.Collections.Generic;

public class CityWithWeather
{
    private string cityName;
    private string airTemp;
    private string weatherType;

    public CityWithWeather(string _cityName, string _airTemp, string _weatherType)
    {
        cityName = _cityName;
        airTemp = _airTemp;
        weatherType = _weatherType;
    }
}
