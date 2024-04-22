using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Prefab de la moneda
    public float spawnRate = 2f; // Frecuencia de generación de monedas
    public float spawnRadius = 5f; // Radio de generación de monedas
    public float coinSpeed = 2f; // Velocidad de movimiento horizontal de las monedas

    private float nextSpawnTime;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnCoin();
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }

    void SpawnCoin()
    {
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        spawnPosition.z = 0f; // Asegurarse de que las monedas se generen en el mismo plano Z

        GameObject coin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D coinRigidbody = coin.GetComponent<Rigidbody2D>();

        // Establecer la velocidad de movimiento de la moneda en el eje X
        coinRigidbody.velocity = new Vector2(-coinSpeed, 0f); // Velocidad horizontal, puedes ajustar según necesites
    }
}