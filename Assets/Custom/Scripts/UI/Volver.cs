using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Volver : MonoBehaviour
{
    // Método para cambiar a una escena específica
   
    
    public void Regresar(){
        SceneManager.LoadScene(1);
    }

}