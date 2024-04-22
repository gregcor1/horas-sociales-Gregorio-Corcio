using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escene : MonoBehaviour
{
    // Método para cambiar a una escena específica
   
    
    public void iniciar(){
        SceneManager.LoadScene(0);
    }

}
