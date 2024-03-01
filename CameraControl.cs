using UnityEngine;
using UnityEngine.EventSystems;

public class CameraControl : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Transform cameraTransform; // Reference to the camera's transform
    public float rotationSpeed = 2.0f; // Adjust the base rotation speed as needed
    public float sensitivity = 0.01f; // Adjust the sensitivity to control rotation based on swipe distance

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

        // Adjust the rotation based on swipe input and sensitivity
        float rotationX = swipeInput.y * rotationSpeed * sensitivity;
        float rotationY = swipeInput.x * rotationSpeed * sensitivity;

        // Apply the rotation to the camera's transform
        cameraTransform.Rotate(Vector3.up, rotationY, Space.World);
        cameraTransform.Rotate(Vector3.left, rotationX, Space.Self);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        swipeInput = Vector2.zero;
    }
}
