using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab del proyectil que disparará la nave enemiga
    public float speed = 5f; // Velocidad de movimiento de la nave enemiga
    public float fireRate = 1f; // Frecuencia de disparo en segundos
    public AudioClip shootSound; // AudioClip para el sonido de disparo
    private AudioSource audioSource; // Referencia al AudioSource
    public int damageAmount = 1; // Cantidad de daño que inflige el enemigo (nuevo)
    private Rigidbody2D rb; // Rigidbody2D de la nave enemiga

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtenemos el componente Rigidbody2D de la nave enemiga
        audioSource = GetComponent<AudioSource>(); // Obtenemos el componente AudioSource

        // Iniciamos el método para que la nave enemiga reaparezca cada 15 segundos
        InvokeRepeating("RespawnEnemy", 0f, 15f); // Llama al método RespawnEnemy cada 15 segundos desde el inicio
    }

    void Update()
    {
        // Movemos la nave enemiga hacia la izquierda con la velocidad especificada
        rb.velocity = new Vector2(-speed, 0f); // Asigna una velocidad al Rigidbody2D para mover la nave hacia la izquierda
    }

    // Método para que la nave enemiga reaparezca
    void RespawnEnemy()
    {
        // Posicionamos la nave enemiga fuera de la pantalla en el lado derecho
        transform.position = new Vector3(10f, Random.Range(-3.25f, 3.25f), 0f); // Coloca la nave en una posición aleatoria en el lado derecho de la pantalla
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si la colisión es con la nave del jugador
        if (other.CompareTag("Player"))
        {
            // Obtiene el componente PlayerHealth de la nave del jugador
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // Aplica daño a la nave del jugador
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
    /* Método para que la nave enemiga dispare
    void Fire()
    {
        // Instanciamos un proyectil en la posición de la nave enemiga
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity); // Crea un nuevo proyectil en la posición de la nave

        // Asignamos una velocidad al proyectil para que se mueva hacia la izquierda
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-10f, 0f); // Asigna una velocidad al proyectil para que se mueva hacia la izquierda

        // Reproducimos el sonido de disparo si está asignado y si el AudioSource está presente
        if (shootSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootSound); // Reproduce el clip de audio de disparo una vez
        }
    

    // Método que se llama cuando se activa el objeto
    void OnEnable()
    {
        // Llamamos al método Fire() repetidamente con la frecuencia de disparo especificada
        InvokeRepeating("Fire", 0f, fireRate); // Llama al método Fire cada cierto intervalo de tiempo (fireRate) desde que el objeto se activa
    }

    // Método que se llama cuando se desactiva el objeto
    void OnDisable()
    {
        // Cancelamos la repetición del disparo
        CancelInvoke("Fire"); // Detiene la repetición de la llamada al método Fire cuando el objeto se desactiva
    }*/
    
}