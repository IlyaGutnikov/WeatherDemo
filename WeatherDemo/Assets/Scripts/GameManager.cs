using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonGameObject<GameManager>
{

    private float time = 0.0f;
    private int timeInSeconds = 0;

    bool isPaused = false;

    private bool isCountingTime = false;

	// Use this for initialization
	void Start () {
		
        StartTimer();
	}
	
	// Update is called once per frame
	void Update () {

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

    private void StartTimer()
    {
        time = 0;
        timeInSeconds = 0;
        isCountingTime = true;
    }

    private void StopTimer()
    {
        isCountingTime = false;

        if (time > 0)
        {
            timeInSeconds = (int) time % 60;
            Debug.Log("timeInSeconds " + timeInSeconds);
        }
        else
        {
            Debug.LogError("time is 0");
        }
    }


}
