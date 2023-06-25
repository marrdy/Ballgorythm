using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapSetPosToPlayer : MonoBehaviour
{
    public Transform playerpos;
    public Transform goalpos;
    public float distanceToOrthSize;
    public int height = 100;
    public SpriteRenderer gridlines;
    void Start()
    {
        distanceToOrthSize = Vector3.Distance(playerpos.position, goalpos.position) + 60;
        this.GetComponent<Camera>().orthographicSize = distanceToOrthSize;
        this.transform.position = new Vector3(playerpos.position.x, playerpos.position.y+height, playerpos.position.z);
        gridlines.transform.position = new Vector3(playerpos.position.x, playerpos.position.y, playerpos.position.z);
        gridlines.transform.localScale = new Vector3(distanceToOrthSize, distanceToOrthSize, distanceToOrthSize);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
