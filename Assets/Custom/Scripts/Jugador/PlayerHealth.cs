using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3; // Vidas máximas del jugador
    private int currentHealth; // Vidas actuales del jugador

    private void Start()
    {
        currentHealth = maxHealth; // Inicializa las vidas actuales
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Reduce la salud del jugador según el daño recibido

        // Verifica si el jugador se queda sin vidas
        if (currentHealth <= 0)
        {
            Die(); // Llama al método para manejar la muerte del jugador
        }
    }

    private void Die()
    {
        // Aquí puedes implementar lógica adicional al morir el jugador, como reiniciar el nivel o mostrar una pantalla de Game Over
        Debug.Log("Player died!");
    }
}