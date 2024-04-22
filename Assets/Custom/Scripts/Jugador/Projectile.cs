using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f; // Velocidad del proyectil

    void Update()
    {
        // Mueve el proyectil hacia adelante
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto colisionado es el jugador (ignora la colisi�n)
        if (other.CompareTag("Player"))
        {
            return; // Sale de la funci�n sin hacer nada
        }

        // Verifica si el objeto colisionado es un enemigo o un asteroide
        if (other.CompareTag("Enemy") || other.CompareTag("Asteroid"))
        {
            Destroy(other.gameObject); // Destruye el objeto colisionado
        }

        // Destruye el proyectil despu�s de la colisi�n
        Destroy(gameObject);
    }
}
