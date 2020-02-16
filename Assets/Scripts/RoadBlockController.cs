using UnityEngine;

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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Direction GetEntryDirection()
    {
        return entryDirection;
    }

    public Direction GetExitDirection()
    {
        return exitDirection;
    }
}
