using UnityEngine;
using UnityEngine.EventSystems;

public class HeightCamControl : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Transform cameraTransform; // Reference to the camera's transform
    public float moveSpeed = 2.0f; // Adjust the movement speed as needed
    public float minHeight = 1.0f; // Minimum camera height
    public float maxHeight = 10.0f; // Maximum camera height
    public LayerMask collisionLayer; // Specify which layers should be considered for collision

    private Vector2 swipeStartPos;
    private Vector2 swipeInput;

    private bool isDragging = false;

    private float raycastDistance = 1.0f;

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging)
        {
            swipeStartPos = eventData.position;
            isDragging = true;
        }

        // Calculate the input vector from the swipe
        Vector2 currentPos = eventData.position;
        swipeInput = currentPos - swipeStartPos;

        // Calculate the desired camera height based on swipe input
        float newHeight = cameraTransform.position.y - swipeInput.y * moveSpeed * Time.deltaTime;

        // Clamp the camera height to stay within the specified range
        newHeight = Mathf.Clamp(newHeight, minHeight, maxHeight);

        // Cast a ray from the camera's current position to the new position to detect collisions
        Vector3 newPosition = new Vector3(cameraTransform.position.x, newHeight, cameraTransform.position.z);
        Ray ray = new Ray(cameraTransform.position, newPosition - cameraTransform.position);
        if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance, collisionLayer))
        {
            // Adjust the camera's position based on the collision hit point
            newHeight = hit.point.y;
        }

        // Update the camera's position
        cameraTransform.position = new Vector3(cameraTransform.position.x, newHeight, cameraTransform.position.z);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        swipeInput = Vector2.zero;
    }
}
