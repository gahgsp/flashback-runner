using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    [SerializeField] float cameraTranslationSpeed = 5f;
    [SerializeField] float cameraRotationSpeed = 100f;
    [SerializeField] GameObject carFrontLights;
    
    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        SwitchLight();
        ResetCamera();
        ExitGame();
    }
    
    /// <summary>
    /// Translates the Camera based on the player input.
    /// </summary>
    private void Move()
    {
        transform.Rotate(0f, Input.GetAxisRaw("Horizontal") * Time.deltaTime * cameraRotationSpeed, 0f);
    }

    /// <summary>
    /// Rotates the Camera based on the player input.
    /// </summary>
    private void Rotate()
    {
        transform.Translate(0f, 0f, Input.GetAxisRaw("Vertical") * Time.deltaTime * cameraTranslationSpeed);
    }
    
    /// <summary>
    /// Turns the lights ON/OFF.
    /// </summary>
    private void SwitchLight()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            var frontLights = carFrontLights.GetComponent<Light>();
            frontLights.enabled = !frontLights.enabled;
        }
    }

    /// <summary>
    /// Sets the Camera to the starting position.
    /// This ensures that if the player collides and the Camera turns upside down, the player can still play.
    /// </summary>
    private void ResetCamera()
    {
        if (Input.GetKeyDown(KeyCode.R))
        { 
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);   
        }
    }

    /// <summary>
    /// Exit the game when the ESC key is pressed.
    /// </summary>
    private void ExitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
