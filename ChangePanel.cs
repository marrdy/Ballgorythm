using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePanel : MonoBehaviour
{
 
    public GameObject xpanel;
    public GameObject ypanel;
    public GameObject zpanel;
    public void panelx()
    {
       xpanel.SetActive(true);
       ypanel.SetActive(false);
       zpanel.SetActive(false);
    }
     public void panely()
     {
        xpanel.SetActive(false);
        ypanel.SetActive(true);
        zpanel.SetActive(false);
    }
    public void panelz()
    {
        xpanel.SetActive(false);
        ypanel.SetActive(false);
        zpanel.SetActive(true);
    }
}
