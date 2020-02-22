﻿using TMPro;
using UnityEngine;

public class Distance : MonoBehaviour
{

    [SerializeField] GameObject player;

    private TextMeshProUGUI _distanceText;
    
    private float _distanceTravelled;
    private Vector3 _lastPlayerPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        _lastPlayerPosition = player.transform.position;
        _distanceText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        var currentPlayerPosition = player.transform.position;
        _distanceTravelled += Vector3.Distance(currentPlayerPosition, _lastPlayerPosition);
        _lastPlayerPosition = currentPlayerPosition;
        if (_distanceTravelled >= 1f)
        {
            // Format the distance to only get the "Integer" part of it.
            _distanceText.text = _distanceTravelled.ToString("F0") + " m";
        }
    }
}
