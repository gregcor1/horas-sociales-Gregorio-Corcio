using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Instancia estática del GameManager para acceder desde otros scripts

    public Text scoreText; // Referencia al texto de la puntuación en la interfaz de usuario
    private int score = 0; // Puntuación actual del jugador

    private const string ScoreKey = "PlayerScore"; // Clave para guardar/recuperar el puntaje en PlayerPrefs

    private void Awake()
    {
        // Asegura que solo haya una instancia del GameManager en la escena
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadScore(); // Cargar el puntaje guardado al iniciar el juego
        UpdateScoreText(); // Actualizar el texto de la puntuación en la interfaz de usuario
    }

    // Método para aumentar la puntuación del jugador
    public void IncreaseScore(int amount)
    {
        score += amount; // Incrementa la puntuación según la cantidad especificada
        UpdateScoreText(); // Actualiza el texto de la puntuación en la interfaz de usuario
        SaveScore(); // Guarda el puntaje actual en PlayerPrefs
    }

    // Método para actualizar el texto de la puntuación en la interfaz de usuario
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score; // Actualiza el texto con el valor actual de la puntuación
        }
    }

    // Método para guardar el puntaje actual en PlayerPrefs
    private void SaveScore()
    {
        PlayerPrefs.SetInt(ScoreKey, score); // Guarda el puntaje en PlayerPrefs con la clave ScoreKey
        PlayerPrefs.Save(); // Guarda los cambios en PlayerPrefs
    }

    // Método para cargar el puntaje guardado desde PlayerPrefs al iniciar el juego
    private void LoadScore()
    {
        if (PlayerPrefs.HasKey(ScoreKey))
        {
            score = PlayerPrefs.GetInt(ScoreKey); // Carga el puntaje desde PlayerPrefs usando la clave ScoreKey
        }
    }
}
