using System.Linq;
using UnityEngine;

/// <summary>
/// This class is responsible for the creation of the infinite road using the available road blocks.
/// The road is procedurally created and new road blocks can be added.
/// </summary>
public class RoadManager : MonoBehaviour
{
    // All available road blocks.
    [SerializeField] GameObject[] roadBlocks;

    private GameObject _lastSpawnedBlock;

    private void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnRoadBlock();
        }
    }

    // Enable is called when the game object is enabled or created
    private void OnEnable()
    {
        TriggerEnterEvent.OnEnterEvent += SpawnRoadBlock;
    }

    // Disable is called whenever the game object is disabled or destroyed
    private void OnDisable()
    {
        TriggerEnterEvent.OnEnterEvent -= SpawnRoadBlock;
    }
    
    /// <summary>
    /// Spawn a new road block, using the last spawned block as reference to choose the best next block.
    /// </summary>
    private void SpawnRoadBlock()
    {
        if (_lastSpawnedBlock != null)
        {
            var nextBlockRoad = GetBestRoadBlock();
            var spawnedBlock = Instantiate(nextBlockRoad,
                nextBlockRoad.transform.position, Quaternion.identity, transform);
            _lastSpawnedBlock = spawnedBlock;
        }
        else
        {
            var roadBlock = roadBlocks[2];
            var spawnedBlock = Instantiate(roadBlock,
                new Vector3(transform.position.x, transform.position.y,
                    roadBlock.GetComponent<Collider>().bounds.extents.z * 2), Quaternion.identity, transform);
            _lastSpawnedBlock = spawnedBlock;
        }
    }

    /// <summary>
    /// Contains the logic to retrieve from the available road blocks the best option based on the last
    /// road block that was spawned.
    /// </summary>
    private GameObject GetBestRoadBlock()
    {
        var lastRoadBlockExitDirection = _lastSpawnedBlock.GetComponent<RoadBlockController>().GetExitDirection();
        var bestEntryDirection = RoadBlockController.Direction.NORTH;
        var lastRoadBlockPosition = _lastSpawnedBlock.transform.position;
        switch (lastRoadBlockExitDirection)
        {
            case RoadBlockController.Direction.EAST:
                bestEntryDirection = RoadBlockController.Direction.WEST;
                lastRoadBlockPosition +=
                    new Vector3(_lastSpawnedBlock.GetComponent<Collider>().bounds.extents.x * 2, 0, 0);
                break;
            case RoadBlockController.Direction.WEST:
                bestEntryDirection = RoadBlockController.Direction.EAST;
                lastRoadBlockPosition +=
                    new Vector3(_lastSpawnedBlock.GetComponent<Collider>().bounds.extents.x * 2 * -1, 0, 0);
                break;
            case RoadBlockController.Direction.NORTH:
                bestEntryDirection = RoadBlockController.Direction.SOUTH;
                lastRoadBlockPosition +=
                    new Vector3(0, 0, _lastSpawnedBlock.GetComponent<Collider>().bounds.extents.z * 2);
                break;
        }

        var possibleRoadBlocks = roadBlocks
            .Where(roadBlock => roadBlock.GetComponent<RoadBlockController>().GetEntryDirection() == bestEntryDirection)
            .ToList();

        var bestRoadBlockIndex = Random.Range(0, possibleRoadBlocks.Count);
        var bestRoadBlock = possibleRoadBlocks[bestRoadBlockIndex];
        bestRoadBlock.transform.position = lastRoadBlockPosition;
        
        return bestRoadBlock;
    }
}