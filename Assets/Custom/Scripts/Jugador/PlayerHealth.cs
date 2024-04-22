using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3; // Vidas m�ximas del jugador
    private int currentHealth; // Vidas actuales del jugador

    private void Start()
    {
        currentHealth = maxHealth; // Inicializa las vidas actuales
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Reduce la salud del jugador seg�n el da�o recibido

        // Verifica si el jugador se queda sin vidas
        if (currentHealth <= 0)
        {
            Die(); // Llama al m�todo para manejar la muerte del jugador
        }
    }

    private void Die()
    {
        // Aqu� puedes implementar l�gica adicional al morir el jugador, como reiniciar el nivel o mostrar una pantalla de Game Over
        Debug.Log("Player died!");
    }
}