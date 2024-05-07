using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject gamePanel; // Referencia al panel de juego
    public GameObject pausePanel; // Referencia al panel de pausa

    private bool isPaused = false; // Variable para controlar el estado de pausa

    private void Start()
    {
        // Al inicio del juego, asegúrate de que el panel de pausa esté desactivado
        pausePanel.SetActive(false);
    }

    private void Update()
    {
        // Verifica si se presiona la tecla de pausa (por ejemplo, "P" o "Esc")
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume(); // Reanuda el juego si ya está en pausa
            }
            else
            {
                Pause(); // Pausa el juego si no está en pausa
            }
        }
    }

    void Pause()
    {
        // Desactiva el panel de juego y activa el panel de pausa
        gamePanel.SetActive(false);
        pausePanel.SetActive(true);

        Time.timeScale = 0f; // Detiene el tiempo del juego
        isPaused = true;
    }

    public void Resume()
    {
        // Reanuda el juego al activar el panel de juego y desactivar el panel de pausa
        pausePanel.SetActive(false);
        gamePanel.SetActive(true);

        Time.timeScale = 1f; // Reanuda el tiempo del juego
        isPaused = false;
    }

    public void QuitGame()
    {
        // Método para salir del juego (puedes usarlo en un botón de "Salir" dentro del panel de pausa)
        Debug.Log("Quitting game...");
        Application.Quit(); // Cierra la aplicación (funciona solo en build, no en editor)
    }
}

