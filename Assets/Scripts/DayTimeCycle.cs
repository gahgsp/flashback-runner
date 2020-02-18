using UnityEngine;

public class DayTimeCycle : MonoBehaviour
{

    [SerializeField] int completeDayInSeconds = 30;
    
    private float _currHourOfDay = 0.25f; // The sun always starts at 06:00 AM
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // We add 90º to make the sun rise at 180º (0.25 of a day that is equal to 06:00 AM)
        transform.localRotation = Quaternion.Euler((_currHourOfDay * 360f) + 90, 90, 0);
        _currHourOfDay -= (Time.deltaTime / completeDayInSeconds);
    }
}
