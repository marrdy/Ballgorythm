using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform target;
    private void Update()
    {

        Vector3 direction = transform.position - target.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }


}