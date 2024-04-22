using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // M�todo para salir del juego
    public void Exit()
    {
       # if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Detiene el juego en el editor
       #else
             debug.log("Salir del juego");
            //Application.Quit();
            // Sale de la aplicaci�n (solo funciona en compilaci�n)
        #endif
    }
}
