using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Volver : MonoBehaviour
{
    // M�todo para cambiar a una escena espec�fica
   
    
    public void Regresar(){
        SceneManager.LoadScene(1);
    }

}