using UnityEngine;

public class DayTimeCycle : MonoBehaviour
{

    [SerializeField] int completeDayInSeconds = 30;
    
    private float _currentHourOfDay = 0.25f; // The sun always starts at 06:00 AM
    private float _clockWiseCurrentHourOfDay = 0.25f; // The sun always starts at 06:00 AM
    
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

        // Resets the day after it reaches 00:00 PM
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
