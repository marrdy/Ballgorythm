using UnityEngine;
using UnityEngine.UI;

public class CategoryButton : MonoBehaviour
{
    public GameObject contentPanel; // Reference to the panel containing the content for this category.
    public bool isExpanded; // Flag to keep track of whether the content is currently expanded or not.

    private void Start()
    {
        // Hide the content panel at the start.
        contentPanel.SetActive(false);
        isExpanded = false;
    }

    public void OnClickCategory()
    {
        // Toggle the content panel's active state and update the isExpanded flag.
        isExpanded = !isExpanded;
        contentPanel.SetActive(isExpanded);
    }
}
