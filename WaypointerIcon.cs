using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaypointerIcon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform ObjectToFollow;
    void Update()
    {
        float minx = this.GetComponent<Image>().GetPixelAdjustedRect().width/2;
        float maxx = Screen.width-minx;

        float miny = this.GetComponent<Image>().GetPixelAdjustedRect().width / 2;
        float maxy = Screen.width - minx;


        Vector2 pos = Camera.main.WorldToScreenPoint(ObjectToFollow.position);
        if (Vector3.Dot((ObjectToFollow.position - transform.position),transform.forward)<0)
        {
            if (pos.x<Screen.width/2)
            {
                pos.x = maxx;
            }
            {
                pos.x = minx;
            }
        }
        pos.x = Mathf.Clamp(pos.x,minx, maxx);
        pos.y = Mathf.Clamp(pos.y,miny, maxy);
        transform.position = pos;
    }
}
