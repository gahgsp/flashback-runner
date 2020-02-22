using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, Input.GetAxisRaw("Horizontal") * Time.deltaTime * 100f, 0f);
        transform.Translate(0f, 0f, Input.GetAxisRaw("Vertical") * Time.deltaTime * 3f);
    }
}
