using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //taken fromt the resources of the gamedevCourse
    public Transform target;
    public Vector3 offset;
    [Range(2, 10)]
    public float smoothFactor;
    
    private void LateUpdate()
    {
        Follow();
    }
    void Follow()
    {

        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;

    }
}
