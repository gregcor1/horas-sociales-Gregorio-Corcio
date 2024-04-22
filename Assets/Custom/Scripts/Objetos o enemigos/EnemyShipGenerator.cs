using System.Collections;
using UnityEngine;

public class EnemyShipGenerator : MonoBehaviour
{
    public GameObject enemyShipPrefab; // Prefab de la nave enemiga
    public float spawnInterval = 15f; // Intervalo de tiempo entre generaciones
    private bool isGenerating = false; // Estado de generación

    void Start()
    {
        StartGenerating(); // Comienza a generar naves enemigas
    }

    // Método para comenzar a generar naves enemigas en intervalos regulares
    public void StartGenerating()
    {
        if (!isGenerating)
        {
            isGenerating = true;
            StartCoroutine(GenerateEnemyShips());
        }
    }

    // Método para detener la generación de naves enemigas
    public void StopGenerating()
    {
        if (isGenerating)
        {
            isGenerating = false;
            StopCoroutine(GenerateEnemyShips());
        }
    }

    // Método para generar una única nave enemiga
    IEnumerator GenerateEnemyShips()
    {
        while (true)
        {
            // Instancia la nave enemiga en una posición específica
            Instantiate(enemyShipPrefab, transform.position, Quaternion.identity);
            
            // Espera 15 segundos antes de generar la próxima nave enemiga
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}