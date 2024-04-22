using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1; // Valor de la moneda

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Aumentar la puntuación
            GameManager.instance.IncreaseScore(value);

            // Destruir la moneda cuando sea recolectada
            Destroy(gameObject);
        }
    }
}