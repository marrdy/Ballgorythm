using UnityEngine;
using UnityEngine.UI;

public class ScrollRectRotation : MonoBehaviour
{
    public ScrollRect scrollRect;
    public Transform targetObject;
    public float rotationSpeed = 10.0f;

    private Vector2 previousScrollPosition;

    private void Start()
    {
        if (scrollRect == null || targetObject == null)
        {
            Debug.LogError("Scroll Rect or Target Object not assigned.");
            enabled = false;
            return;
        }

        // Store the initial scroll position
        previousScrollPosition = scrollRect.normalizedPosition;
    }

    public void Scrolling()
    {
        if (scrollRect.normalizedPosition != previousScrollPosition)
        {
            // Calculate the difference in horizontal scroll position
            float delta = scrollRect.normalizedPosition.x - previousScrollPosition.x;
            // Rotate the target object based on the scroll movement
            Vector3 rotation = targetObject.rotation.eulerAngles;
            rotation.y += delta * rotationSpeed;
            targetObject.rotation = Quaternion.Euler(rotation);
            previousScrollPosition = scrollRect.normalizedPosition;
        }
    }
}
