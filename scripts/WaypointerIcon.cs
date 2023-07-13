using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaypointerIcon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform ObjectToFollow;
    public float margin;
    void Update()
    {
        float minx = this.GetComponent<Image>().GetPixelAdjustedRect().width+200/2;
        float maxx = Screen.width-minx-200;

        float miny = this.GetComponent<Image>().GetPixelAdjustedRect().height +100/ 2;
        float maxy = Screen.height - miny -100;


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
            if (pos.y<Screen.height/2)
            {
                pos.y = maxy;
            }
            {
                pos.y = miny;
            }
        }
        pos.x = Mathf.Clamp(pos.x,minx, maxx);
        pos.y = Mathf.Clamp(pos.y,miny, maxy);
        transform.position = pos;
    }
}
