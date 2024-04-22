using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int damageAmount = 1; // Cantidad de daño que inflige el meteorito

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si la colisión es con la nave del jugador
        if (other.CompareTag("Player"))
        {
            // Obtiene el componente PlayerHealth de la nave del jugador
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // Aplica daño a la nave del jugador
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}