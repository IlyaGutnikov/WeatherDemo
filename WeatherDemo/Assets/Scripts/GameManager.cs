using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class GameManager : SingletonGameObject<GameManager>
{

    private float time = 0.0f;
    private int timeInSeconds = 0;

    private string weatherKey = "weatherKey";

    private bool isCountingTime = false;

    private string weatherURL =
        "http://api.openweathermap.org/data/2.5/find?lat=58.02&lon=56.3&cnt=SECONDS&appid=51805bdd8e9120e6e0ab93ad818af091";

    [SerializeField]
    private WeatherListScrollView scrollView;

    #region BASIC

    // Use this for initialization
    void Start()
    {
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {

        if (isCountingTime)
        {
            time += Time.deltaTime;
        }
    }

    void OnDestroy()
    {

    }

    void OnApplicationQuit()
    {
        StopTimer();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            StopTimer();
        }
        else
        {
            StartTimer();
        }
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            StopTimer();
        }
        else
        {
            StartTimer();
        }
    }

    #endregion

    #region TIMER

    private void StartTimer()
    {
        time = 0;
        timeInSeconds = 0;
        isCountingTime = true;

        if (PlayerPrefs.HasKey(weatherKey))
        {
            scrollView.DeleteAllWeatherListItems();

            scrollView.AddAllWeatherListItems(parseJson(PlayerPrefs.GetString(weatherKey)));

            PlayerPrefs.DeleteKey(weatherKey);
        }
    }

    private void StopTimer()
    {
        isCountingTime = false;

        if (time > 0)
        {
            timeInSeconds = (int)time % 60;
            Debug.Log("timeInSeconds " + timeInSeconds);

            StartCoroutine(GetWeather());
        }
        else
        {
            Debug.LogError("time is 0");
        }
    }

    #endregion

    #region GET_WEATHER

    IEnumerator GetWeather()
    {

        weatherURL = weatherURL.Replace("SECONDS", timeInSeconds.ToString());
        Debug.Log(weatherURL);

        WWW weatherWWW = new WWW(weatherURL);

        yield return weatherWWW;
        if (weatherWWW.error == null)
        {
            Debug.Log(weatherWWW.text);

            PlayerPrefs.SetString(weatherKey, weatherWWW.text);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("ERROR: " + weatherWWW.error);
        }
    }
    #endregion

    #region PARSE_JSON

    private List<CityWithWeather> parseJson(string _json)
    {
        var json = JSON.Parse(_json);

        List<CityWithWeather> cityWithWeathers = new List<CityWithWeather>();

        int listCount = json["list"].Count;

        for (int i = 0; i < listCount; i++)
        {
            cityWithWeathers.Add(new CityWithWeather(
                json["list"][i]["name"].ToString(),
                json["list"][i]["main"]["temp"].ToString(),
                json["list"][i]["weather"][0]["main"].ToString()));

            //Debug.Log(json["list"][i]["name"]);
            //Debug.Log(json["list"][i]["main"]["temp"]);
            //Debug.Log(json["list"][i]["weather"][0]["main"]);
        }

        return cityWithWeathers;
    }

    #endregion

}
