using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HideShowMap : MonoBehaviour
{
    
    public Button SideButton;
    public Button TopButton;
    public Texture SideTexture;
    public Texture TopTexture;
    public RawImage MiniMap;
    public IconFollow[] Icons;
    public SideViewMiniCam svc;
    public TMP_Text xz;

    public MiniMapSetPosToPlayer minimaptop;
    public SideViewMiniCam minimapside;
    public TMP_Text Z;
    public TMP_Text YX;
    public Color Xcolor;
    public Color Ycolor;
    public Color Zcolor;
    float origsizetopcam;
    float origsizesidecam;
    public Slider zoomer;
    void Start()
    {
        Debug.Log(minimaptop.distanceToOrthSize);
        Debug.Log(minimapside.distanceToOrthSize);
         TopViewToggle();
    }
    public void hidemap()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
        
    }
    public void SideViewToggle()
    {
        
        MiniMap.GetComponent<RawImage>().texture = SideTexture;
        foreach(IconFollow ICf in Icons)
        {
            ICf.sideviewOn= true;
        }
        SideButton.interactable = false;
        TopButton.interactable = true;
        xz.text = svc.anglestate + "+";
        if(svc.anglestate == "X")
        {
            xz.color = Xcolor;
        }
        else
        {
            xz.color = Zcolor;
        }
        YX.text = "Y+";
        YX.color =Ycolor;
        Z.gameObject.SetActive(false);
         xz.gameObject.SetActive(true);
    }

    public void TopViewToggle()
    {
        MiniMap.GetComponent<RawImage>().texture =TopTexture;
        foreach(IconFollow ICf in Icons)
        {
            ICf.sideviewOn = false;
        }
        SideButton.interactable = true;
        TopButton.interactable = false;
          YX.text = "X+";
          YX.color = Xcolor;
           Z.text = "Z+";
           Z.color = Zcolor;
            Z.gameObject.SetActive(true);
           xz.gameObject.SetActive(false);
    }
    public void SliderZooming()
    {
       minimaptop.GetComponent<Camera>().orthographicSize =  minimaptop.distanceToOrthSize * zoomer.value;
        minimapside.GetComponent<Camera>().orthographicSize =  minimapside.distanceToOrthSize * zoomer.value;
    }
}
