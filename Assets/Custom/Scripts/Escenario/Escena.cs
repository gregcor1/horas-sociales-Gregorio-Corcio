using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escene : MonoBehaviour
{
    // M�todo para cambiar a una escena espec�fica
   
    
    public void iniciar(){
        SceneManager.LoadScene(0);
    }

}
