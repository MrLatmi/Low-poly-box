using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public float bulletSpeed = 10f;
    public float bulletLifetime = 2f;
    public float shootDelay = 0.5f;

    private float timeSinceLastShot = 0f;
    public float fireRate = 0.5f; // ����� ����� ����������
    private bool isShooting = false; // ���� ��� ��������, ���������� �� � ������ ������ ��������

    void Start()
    {
        // �������� ������� �������� � �������� ����������
        InvokeRepeating("Fire", fireRate, fireRate);
    }

    void Fire()
    {
        if (!isShooting)
        {
            isShooting = true;

            // ������� ������ �� �������
            GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);

            // ���������� ������ � ����������� �������� �����
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.velocity = transform.forward * bulletSpeed;

            // ������������� ����� ����� �������
            Destroy(bullet, bulletLifetime);

            isShooting = false;
        }
    }

}
