using System.Collections;
using System.Collections.Generic;

public class CityWithWeather
{
    public string cityName;
    public string airTemp;
    public string weatherType;

    public CityWithWeather(string _cityName, string _airTemp, string _weatherType)
    {
        cityName = _cityName;
        airTemp = _airTemp;
        weatherType = _weatherType;
    }
}
