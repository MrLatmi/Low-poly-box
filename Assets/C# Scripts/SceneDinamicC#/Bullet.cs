using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float bulletLifetime = 2f;

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.right * bulletSpeed, ForceMode.Impulse);
        Destroy(gameObject, bulletLifetime);
    }
}

