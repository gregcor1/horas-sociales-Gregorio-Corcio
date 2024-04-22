using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab del proyectil que disparará la nave del jugador
    public Transform firePoint; // Punto de origen del disparo
    public float bulletSpeed = 10f; // Velocidad del proyectil

    void Update()
    {
        // Verifica si se presiona la tecla de espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Dispara un proyectil
            Shoot();
        }
    }

    void Shoot()
    {
        // Instancia un proyectil en el punto de origen del disparo
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Accede al componente Rigidbody2D del proyectil y establece su velocidad
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Establece la velocidad del proyectil
            rb.velocity = firePoint.right * bulletSpeed;
        }
    }
}