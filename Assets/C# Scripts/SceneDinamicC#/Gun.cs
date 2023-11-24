using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public float bulletSpeed = 10f;
    public float bulletLifetime = 2f;
    public float shootDelay = 0.5f;

    private float timeSinceLastShot = 0f;
    public float fireRate = 0.5f; // время между выстрелами
    private bool isShooting = false; // флаг для проверки, происходит ли в данный момент стрельба

    void Start()
    {
        // Вызываем функцию выстрела с заданным интервалом
        InvokeRepeating("Fire", fireRate, fireRate);
    }

    void Fire()
    {
        if (!isShooting)
        {
            isShooting = true;

            // Создаем снаряд из префаба
            GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);

            // Направляем снаряд в направлении поворота пушки
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.velocity = transform.forward * bulletSpeed;

            // Устанавливаем время жизни снаряда
            Destroy(bullet, bulletLifetime);

            isShooting = false;
        }
    }

}
