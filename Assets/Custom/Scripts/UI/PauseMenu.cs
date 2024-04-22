using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Referencia al panel UI de pausa

    private bool isPaused = false; // Variable para controlar el estado de pausa

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

    public void Resume()
    {
        // Desactiva el panel de pausa y reanuda el tiempo del juego
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Reanuda el tiempo del juego
        isPaused = false;
    }

    void Pause()
    {
        // Activa el panel de pausa y detiene el tiempo del juego
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Detiene el tiempo del juego
        isPaused = true;
    }

    public void QuitGame()
    {
        // Método para salir del juego (puedes usarlo en un botón de "Salir")
        Debug.Log("Quitting game...");
        Application.Quit(); // Cierra la aplicación (funciona solo en build, no en editor)
    }
}