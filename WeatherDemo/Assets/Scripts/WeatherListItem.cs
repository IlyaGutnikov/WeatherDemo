using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherListItem : MonoBehaviour {

	[SerializeField]
	Text cityName;

	[SerializeField]
	Text cityAirTemp;

    [SerializeField]
    Text cityWeatherMain;


	/// <summary>
	/// Устанавливает информацию в объекте
	/// </summary>
	/// <param name="_mafiaPlayer">Mafia player.</param>
	public void SetItemInfo(CityWithWeather _cityWithWeather)
	{
	    cityName.text = _cityWithWeather.cityName;
	    cityAirTemp.text = _cityWithWeather.airTemp;
	    cityWeatherMain.text = _cityWithWeather.weatherType;


	}
}
