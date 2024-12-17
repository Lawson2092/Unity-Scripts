using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed
    public float mouseSensitivity = 2f; // Mouse sensitivity
    public Transform playerCamera; // Assign the player's camera in the inspector

    private float xRotation = 0f;

    void Start()
    {
        // Lock the cursor to the center of the screen and make it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        MovePlayer();
        RotateCamera();
    }

    void MovePlayer()
    {
        // Get input for movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate direction
        Vector3 direction = transform.right * horizontal + transform.forward * vertical;

        // Apply movement
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }

    void RotateCamera()
    {
        // Get mouse movement input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate player horizontally
        transform.Rotate(Vector3.up * mouseX);

        // Rotate camera vertically
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp vertical rotation
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}