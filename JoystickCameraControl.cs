using UnityEngine;

public class JoystickCameraControl : MonoBehaviour
{
    public Transform cameraTransform;
    public float moveSpeed = 5.0f;
    private float x;
    private float y;
    public FixedJoystick jsMovement;
    public LayerMask collisionLayer; // Layer mask to specify which layers to collide with

    void Update()
    {
        // Get user input or modify x and y as needed
        float moveX = jsMovement.Horizontal;
        float moveY = jsMovement.Vertical;

        // Use the camera's forward vector as the movement direction
        Vector3 moveDirection = cameraTransform.forward * moveY + cameraTransform.right * moveX;
        moveDirection.y = 0; // Prevent movement in the vertical direction (y-axis)

        // Calculate the desired position
        x = moveDirection.x * moveSpeed * Time.deltaTime;
        y = moveDirection.z * moveSpeed * Time.deltaTime;

        Vector3 currentPosition = cameraTransform.position;
        Vector3 desiredPosition = currentPosition + new Vector3(x, 0, y);

        // Perform collision detection
        if (!IsCollidingWithObjects(currentPosition, desiredPosition))
        {
            // Update the camera's position relative to its orientation
            cameraTransform.position = desiredPosition;
        }
    }

    private bool IsCollidingWithObjects(Vector3 currentPosition, Vector3 desiredPosition)
    {
        RaycastHit hit;

        if (Physics.Linecast(currentPosition, desiredPosition, out hit, collisionLayer))
        {
            return true;
        }

        return false;
    }

}
