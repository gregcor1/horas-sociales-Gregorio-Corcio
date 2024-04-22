using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Método para salir del juego
    public void Exit()
    {
       # if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Detiene el juego en el editor
       #else
             debug.log("Salir del juego");
            //Application.Quit();
            // Sale de la aplicación (solo funciona en compilación)
        #endif
    }
}
