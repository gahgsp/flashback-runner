using UnityEngine;

/// <summary>
/// Represents the event that is published when a player reaches the end of a road block.
/// This signals that a new road block must be created.
/// </summary>
public class TriggerEnterEvent : MonoBehaviour
{
    public delegate void EnterEvent();
    public static event EnterEvent OnEnterEvent;

    private bool _isTriggered;
    
    private void OnTriggerEnter(Collider other)
    {
        // Only one execution per road block.
        if (_isTriggered) return;
        // We are only interested if we collide with the "Player" object.
        if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
        _isTriggered = true;
        // The event could be null if there is no subscriber to it.
        OnEnterEvent?.Invoke();
    }
}
