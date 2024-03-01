using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeControl : MonoBehaviour, IDragHandler, IEndDragHandler
{

    public CinemachineFreeLook[] freeLookCameras;
    public float rotationSpeed = 2.0f;
    public float sensitivity = 0.01f;
    public Image area;
    string mousexString = "Mouse X", mouseyString = "Mouse Y";
    private Vector2 swipeStartPos;
    private Vector2 swipeInput;

    private bool isDragging = false;

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(area.rectTransform, eventData.position, eventData.enterEventCamera, out Vector2 passout))
        {
            foreach (CinemachineFreeLook cm in freeLookCameras) 
            {
                cm.m_XAxis.m_InputAxisName = mousexString;
                cm.m_YAxis.m_InputAxisName = mouseyString;
            }
           
        }


    }

    public void OnEndDrag(PointerEventData eventData)
    {
        foreach (CinemachineFreeLook cm in freeLookCameras)
        {
            cm.m_XAxis.m_InputAxisName = "";
            cm.m_YAxis.m_InputAxisName = "";
            cm.m_XAxis.m_InputAxisValue = 0;
            cm.m_YAxis.m_InputAxisValue = 0;

        }
       
    }
}
