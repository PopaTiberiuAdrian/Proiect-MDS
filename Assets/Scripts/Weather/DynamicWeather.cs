using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicWeather : MonoBehaviour {

    [SerializeField] float weatherDurationTime = 20f;
    [SerializeField] float weatherStartTime;
    [SerializeField] GameObject rainPrefab;
    int timeOfDay;
    float timer = 12;
    float skyboxBlendRange = 0.0f;
    bool doIncrease = true;
	public enum WeatherPhases
    {
        SunnyWeather,
        RainyWeather
    }

    public void SunnyWeather()
    {
        rainPrefab.SetActive(false);
    }

    public void RainyWeather()
    {
        rainPrefab.SetActive(true);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        timeOfDay = Mathf.RoundToInt(timer % 60);

        if (skyboxBlendRange >= 1.0f)
            doIncrease = false;
        if (skyboxBlendRange <= 0.0f)
            doIncrease = true;

        if (doIncrease == true)
        {
            skyboxBlendRange += 0.001f;
            //SunnyWeather();
        }
        else
        {
            skyboxBlendRange -= 0.001f;
            //RainyWeather();
        }
        
        RenderSettings.skybox.SetFloat("_Blend", skyboxBlendRange);
    }
}
