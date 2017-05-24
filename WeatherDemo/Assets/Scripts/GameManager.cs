using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonGameObject<GameManager>
{

    private float time = 0.0f;
    private int timeInSeconds = 0;

    private string weatherKey = "weatherKey";

    bool isPaused = false;

    private bool isCountingTime = false;

    private string weatherURL =
        "http://api.openweathermap.org/data/2.5/find?lat=58.02&lon=56.3&cnt=SECONDS&appid=51805bdd8e9120e6e0ab93ad818af091";

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
            Debug.Log("Get key " + PlayerPrefs.GetString(weatherKey));

            //TODO to table

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

            Debug.LogWarning(PlayerPrefs.GetString(weatherKey));
        }
        else
        {
            Debug.Log("ERROR: " + weatherWWW.error);
        }
    }
    #endregion

}
