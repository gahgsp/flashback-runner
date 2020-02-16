using System.Linq;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] GameObject[] roadBlocks;

    private GameObject _lastSpawnedBlock;

    private void Awake()
    {
        for (int i = 0; i < 5; i++)
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

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    // FIXME: Redo this function
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