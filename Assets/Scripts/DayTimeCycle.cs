using UnityEngine;

public class DayTimeCycle : MonoBehaviour
{

    [SerializeField] int completeDayInSeconds = 30;

    private Light _sunLight;
    
    private float _currentHourOfDay = 0.25f; // The sun always starts at 06:00 AM
    private float _clockWiseCurrentHourOfDay = 0.25f; // The sun always starts at 06:00 AM
    
    // Start is called before the first frame update
    void Start()
    {
        _sunLight = GetComponent<Light>();
    }
    
    // Update is called once per frame
    void Update()
    {
        // We add 90º to make the sun rise at 180º (0.25 of a day that is equal to 06:00 AM)
        transform.localRotation = Quaternion.Euler((_currentHourOfDay * 360f) + 90, 90, 0);
        
        // This variable is used to handle the inverted Unit Circle on Unity, so we can rotate the Sun as it does
        // on real life, from East to West
        _currentHourOfDay -= (Time.deltaTime / completeDayInSeconds);
        
        // And this is where we handle the hours "naturally" so we can use on our clock
        _clockWiseCurrentHourOfDay += (Time.deltaTime / completeDayInSeconds);
        
        // Adjust the Sun light intensity by hour
        UpdateSunIntensity();
        
        // Resets the day after it reaches 00:00 PM
        ResetDayHour();
        
    }

    private void UpdateSunIntensity()
    {
        if (_clockWiseCurrentHourOfDay >= 0.25f && _clockWiseCurrentHourOfDay <= 0.75f)
        {
            _sunLight.intensity = 5f;
        }
        else
        {
            _sunLight.intensity = 1f;
        }
    }

    private void ResetDayHour()
    {
        if (_clockWiseCurrentHourOfDay >= 1)
        {
            _clockWiseCurrentHourOfDay = 0;
        }
    }

    public float GetCurrentHourOfDay()
    {
        return _clockWiseCurrentHourOfDay;
    }
}
