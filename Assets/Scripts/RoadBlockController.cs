using UnityEngine;

/// <summary>
/// Simple representation of a road block.
/// </summary>
public class RoadBlockController : MonoBehaviour
{

    public enum Direction
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }

    [SerializeField] Direction entryDirection;
    [SerializeField] Direction exitDirection;
    
    public Direction GetEntryDirection()
    {
        return entryDirection;
    }

    public Direction GetExitDirection()
    {
        return exitDirection;
    }
}
