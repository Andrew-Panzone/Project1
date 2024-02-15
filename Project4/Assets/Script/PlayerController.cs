using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Speed of the character movement
    public float turnSpeed = 500.0f; // Speed of turning left and right
    public float lookSpeed = 500.0f; // Speed of looking up and down

    private float verticalInput;
    private float horizontalInput;
    private float mouseInputX;
    private float mouseInputY;
    private float verticalLookRotation = 0f; // Track the up/down rotation

    public Transform cameraTransform;

    void Update()
    {
        // Get keyboard inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        // Get mouse inputs
        mouseInputX = Input.GetAxis("Mouse X");
        mouseInputY = Input.GetAxis("Mouse Y");

        // Move the player forward/backward and right/left
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * verticalInput);
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime * horizontalInput);

        // Rotate the player left/right
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * mouseInputX);

        // Look up/down
        verticalLookRotation -= mouseInputY * lookSpeed * Time.deltaTime;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f); // Prevent over-rotation
        cameraTransform.localEulerAngles = new Vector3(verticalLookRotation, 0f, 0f);
    }
}
