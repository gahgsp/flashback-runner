using UnityEngine;

public class RoadManager : MonoBehaviour
{

    [SerializeField] GameObject roadBlock;

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
            var spawnedBlock = Instantiate(roadBlock,
                _lastSpawnedBlock.transform.position +
                new Vector3(0, 0, _lastSpawnedBlock.GetComponent<Collider>().bounds.extents.z * 2), Quaternion.identity, transform);
            _lastSpawnedBlock = spawnedBlock;
        }
        else
        {
            var spawnedBlock = Instantiate(roadBlock,
                new Vector3(transform.position.x, transform.position.y,
                    roadBlock.GetComponent<Collider>().bounds.extents.z * 2), Quaternion.identity, transform);
            _lastSpawnedBlock = spawnedBlock;
        }
    }
}
