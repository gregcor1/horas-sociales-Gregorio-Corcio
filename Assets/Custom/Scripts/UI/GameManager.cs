using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Instancia estática del GameManager para acceder desde otros scripts
    public static GameManager instance;

    // Referencia al texto de la puntuación en la interfaz de usuario
    public Text scoreText;

    // Puntuación actual del jugador
    private int score = 0;

    // Método que se llama cuando se inicia el juego
    private void Awake()
    {
        // Verifica si ya hay una instancia de GameManager
        if (instance == null)
        {
            // Si no hay una instancia, establece esta como la instancia actual
            instance = this;
        }
        else if (instance != this)
        {
            // Si ya hay una instancia y no es esta, destruye esta instancia
            Destroy(gameObject);
        }
    }

    // Método para aumentar la puntuación del jugador
    public void IncreaseScore(int amount)
    {
        // Aumenta la puntuación según la cantidad especificada
        score += amount;

        // Actualiza el texto de la puntuación en la interfaz de usuario
        UpdateScoreText();
    }

    // Método para actualizar el texto de la puntuación en la interfaz de usuario
    void UpdateScoreText()
    {
        // Verifica si el texto de la puntuación está asignado
        if (scoreText != null)
        {
            // Actualiza el texto de la puntuación con el valor actual de la puntuación
            scoreText.text = "Score: " + score;
        }
    }
}