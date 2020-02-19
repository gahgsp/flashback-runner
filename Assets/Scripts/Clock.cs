using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{

    // Cached references.
    private DayTimeCycle _dayTimeCycleController;
    private TextMeshProUGUI _clockText;

    private bool _needToClearHourDisplay;
    
    // Awake is called when the script instance is being loaded
    void Awake()
    {
        _dayTimeCycleController = FindObjectOfType<DayTimeCycle>();
        _clockText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateClock();
    }

    private void UpdateClock()
    {
        DisplayHour();
        if (_needToClearHourDisplay)
        {
            Invoke(nameof(ClearHour), 2f);
        }
    }
    
    private void DisplayHour()
    {
        var currentHourOfDay = Mathf.Abs(24 * _dayTimeCycleController.GetCurrentHourOfDay());
        // TODO: Create a SAFETY CONST to explain this 0.2f that is added!
        if (currentHourOfDay >= 6f && currentHourOfDay < 6.2f)
        {
            _clockText.text = "06:00";
            _needToClearHourDisplay = true;
        } else if (currentHourOfDay >= 12f && currentHourOfDay < 12.2f)
        {
            _clockText.text = "12:00";
            _needToClearHourDisplay = true;
        } else if (currentHourOfDay >= 18f && currentHourOfDay < 18.2f)
        {
            _clockText.text = "18:00";
            _needToClearHourDisplay = true;
        } else if (currentHourOfDay >= 0f && currentHourOfDay < 0.2f)
        {
            _clockText.text = "00:00";
            _needToClearHourDisplay = true;
        }
    }

    private void ClearHour()
    {
        _clockText.text = "";
        _needToClearHourDisplay = false;
    }
}
