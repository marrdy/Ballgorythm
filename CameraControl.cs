using UnityEngine;
using UnityEngine.EventSystems;

public class CameraControl : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Transform cameraTransform; // Reference to the camera's transform
    public float rotationSpeed = 2.0f; // Adjust the rotation speed as needed

    private Vector2 swipeStartPos;
    private Vector2 swipeInput;

    private bool isDragging = false;

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

        // Rotate the camera based on swipe input
        float rotationX = swipeInput.y * rotationSpeed;
        float rotationY = -swipeInput.x * rotationSpeed; // Invert horizontal rotation for typical FPS controls

        // Apply the rotation to the camera's transform
        cameraTransform.Rotate(Vector3.up, rotationY, Space.World);
        cameraTransform.Rotate(Vector3.right, rotationX, Space.Self);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        swipeInput = Vector2.zero;
    }
}
