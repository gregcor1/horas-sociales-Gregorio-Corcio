using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int damageAmount = 1; // Cantidad de da�o que inflige el meteorito

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si la colisi�n es con la nave del jugador
        if (other.CompareTag("Player"))
        {
            // Obtiene el componente PlayerHealth de la nave del jugador
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // Aplica da�o a la nave del jugador
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}