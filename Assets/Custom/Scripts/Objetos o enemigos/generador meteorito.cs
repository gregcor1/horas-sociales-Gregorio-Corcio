using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generadormeteorito : MonoBehaviour
{
    public GameObject prefabAsteroide; // Prefab del meteorito
    private int asteroidesEnJuego; // Contador de meteoritos en juego

    void Start()
    {
        asteroidesEnJuego = 0; // Inicializar el contador de meteoritos en juego
        StartCoroutine(oleadaAsteroides()); // Comenzar la rutina de generación de meteoritos
    }

    // Método para crear un meteorito
    public void CrearAsteroide()
    {
        float randomY;
        for (int i = 0; i < 5; i++) // Generar 5 meteoritos en cada ciclo
        {
            randomY = Random.Range(-3.25f, 3.25f); // Generar una posición Y aleatoria
            GameObject a = Instantiate(prefabAsteroide) as GameObject; // Instanciar un nuevo meteorito
            a.transform.position = new Vector3(10f, randomY, 0); // Establecer la posición del meteorito
            a.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-100f, 5f)); // Aplicar fuerza al meteorito
            asteroidesEnJuego++; // Incrementar el contador de meteoritos en juego
        }
    }

    // Rutina para generar meteoritos continuamente
    System.Collections.IEnumerator oleadaAsteroides()
    {
        while (true) // Bucle infinito
        {
            yield return new WaitForSeconds(2.5f); // Esperar 2.5 segundo antes de generar la siguiente oleada
            CrearAsteroide(); // Generar una nueva oleada de meteoritos
        }
    }
}