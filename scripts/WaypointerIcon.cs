
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaypointerIcon : MonoBehaviour
{ public Transform targetObject;  // The object to follow
    public float offset = 10f;      // Offset from the object's position
    public float margin = 20f;      // Margin from the edge of the screen
    private RectTransform rectTransform;
    private Camera mainCamera;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (targetObject != null)
        {
            // Convert the target object's position to screen space
            Vector3 screenPos = mainCamera.WorldToScreenPoint(targetObject.position);

            // Check if the object is within the screen boundaries
            if (screenPos.z > 0 &&
                screenPos.x >= margin && screenPos.x <= Screen.width - margin &&
                screenPos.y >= margin && screenPos.y <= Screen.height - margin)
            {
                // Set the UI element's position to follow the object on the screen
                rectTransform.position = screenPos + Vector3.up * offset;
            }
            else
            {
                // Object is out of the screen, keep the UI element inside the screen
                Vector3 clampedPos = new Vector3(
                    Mathf.Clamp(screenPos.x, margin, Screen.width - margin),
                    Mathf.Clamp(screenPos.y, margin, Screen.height - margin),
                    screenPos.z
                );
                rectTransform.position = clampedPos + Vector3.up * offset;
            }
        }
    }
}