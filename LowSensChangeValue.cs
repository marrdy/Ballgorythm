using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class LowSensChangeValue : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    [SerializeField]private TMP_InputField textComponent;
    [SerializeField]private float dragStartX;
    [SerializeField]private float startValue;
    [SerializeField]private float sensitivity = 0.1f; // Adjust the sensitivity as needed.
    


    public void OnPointerDown(PointerEventData eventData)
    {
        dragStartX = eventData.position.x;
        float.TryParse(textComponent.text, out startValue);
    }

    public void OnDrag(PointerEventData eventData)
    {
        float dragOffset = eventData.position.x - dragStartX;
        float newValue = startValue + dragOffset * sensitivity;
        textComponent.text = newValue.ToString();
    }
}
