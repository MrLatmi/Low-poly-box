using UnityEngine;
using System.Collections;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothness;
    public Vector3 offset = new Vector3(0, 1, -10);

    private Vector3 velocity = Vector3.zero;
    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private bool isMoving = true;

    void Start()
    {
        initialRotation = transform.rotation;
        targetRotation = transform.rotation;
    }

    void FixedUpdate()
    {
        isMoving = false;

        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothness);


        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 1f);

    }

    public void FlipX()
    {
 
        targetRotation = Quaternion.Euler(targetRotation.eulerAngles.x, targetRotation.eulerAngles.y * -1, targetRotation.eulerAngles.z);
        offset.x *= -1;
    }
}
