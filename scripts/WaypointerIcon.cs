using System.Collections;
using System.Collections.Generic;
using playerscript;
using UnityEngine;
using UnityEngine.UI;

public class WaypointerIcon : MonoBehaviour
{
    public Transform target; // The object you want to follow
    public RectTransform canvasRect; // Reference to the Canvas RectTransform

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (target != null)
        {
            // Convert world position to screen space
            Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position);

            // Check if the object is off-screen
            if (!IsInScreen(screenPos))
            {
                // If off-screen, clamp it to the screen bounds
                screenPos.x = Mathf.Clamp(screenPos.x, 0, canvasRect.rect.width);
                screenPos.y = Mathf.Clamp(screenPos.y, 0, canvasRect.rect.height);

                // Set the UI element's position
                rectTransform.position = screenPos;
            }
            else
            {
                // If on-screen, set the UI element's position directly
                rectTransform.position = screenPos;
            }
        }
    }

    private bool IsInScreen(Vector3 screenPos)
    {
        return screenPos.x >= 0 && screenPos.x <= canvasRect.rect.width &&
               screenPos.y >= 0 && screenPos.y <= canvasRect.rect.height;
    }
    
}
