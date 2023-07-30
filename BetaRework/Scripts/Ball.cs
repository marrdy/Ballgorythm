using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool rolling = false;
    public ForceData[] forcesData; // Array of ForceData for forces and intervals
    private int currentForceIndex = 0;
    private Rigidbody rb;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

   

    public void StartApplyingForces()
    {
        currentForceIndex = 0;
        rb.velocity = Vector3.zero; // Reset the velocity to avoid interfering forces
        rb.angularVelocity = Vector3.zero; // Reset angular velocity
        StartCoroutine(ApplyForcesCoroutine());
    }

    private IEnumerator ApplyForcesCoroutine()
    {
        while (currentForceIndex < forcesData.Length)
        {
            rb.AddForce(forcesData[currentForceIndex].force, ForceMode.Force);
            yield return new WaitForSeconds(forcesData[currentForceIndex].intervalBetweenForces);
            currentForceIndex++;
        }
    }

    public void ResetBall()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        currentForceIndex = 0;
        StopAllCoroutines(); // Stop any running coroutines when resetting the ball
    }

}
[System.Serializable]
public class ForceData
{
    public Vector3 force;
    public float intervalBetweenForces;
}
