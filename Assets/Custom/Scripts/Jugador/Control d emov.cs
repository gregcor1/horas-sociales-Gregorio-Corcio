using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Agrega este namespace para cambiar de escena

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb; // Rigidbody2D para el movimiento físico del jugador
    private Vector2 input;  // Vector para almacenar la entrada de movimiento del jugador
    public float speed; // Velocidad de movimiento del jugador
    public int maxHealth = 3; // Vidas máximas del jugador
    private int currentHealth; // Vidas actuales del jugador
    private AudioSource audioSource; // Referencia al componente AudioSource

    public GameObject bulletPrefab; // Prefab del proyectil que disparará el jugador
    public Transform firePoint; // Punto de origen del disparo
    public float bulletSpeed = 10f; // Velocidad del proyectil al disparar
    public AudioClip shootSound; // Clip de audio para el sonido de disparo
    public AudioClip deathSound; // Sonido de muerte al jugador
    public AudioClip collisionSound; // Sonido de colisión de la nave
    public Image[] hearts; // Arreglo de imágenes para los corazones de vida

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtener el Rigidbody2D del jugador
        currentHealth = maxHealth; // Inicializar las vidas actuales
        audioSource = GetComponent<AudioSource>(); // Obtener la referencia al AudioSource
        
        UpdateHeartsUI(); // Actualizar la UI de corazones al inicio
    }

    void Update()
    {
        input.x = Input.GetAxis("Horizontal"); // Capturar la entrada de movimiento horizontal
        input.y = Input.GetAxis("Vertical");   // Capturar la entrada de movimiento vertical

        // Detectar la entrada para disparar (tecla de espacio)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot(); // Llamar al método de disparo al presionar la tecla de espacio
        }
    }
    
    private void FixedUpdate()
    {
        // Aplicar el movimiento al Rigidbody2D del jugador
        rb.velocity = input * speed * Time.fixedDeltaTime;

        // Limitar la posición del jugador en el eje x dentro de la zona de juego
        rb.position = new Vector2(Mathf.Clamp(rb.position.x, -6f, 6f), Mathf.Clamp(rb.position.y, -3.3f, 3.33f));
    }

    private void TakeDamage()
    {
        currentHealth--; // Reducir la salud del jugador

        // Verificar si el jugador se queda sin vidas
        if (currentHealth <= 0)
        {
            Die(); // Llamar al método para manejar la muerte del jugador si se queda sin vidas
        }

        UpdateHeartsUI(); // Actualizar la UI de corazones después de recibir daño
    }

    private void Die()
    {
    // Reproducir sonido de muerte si el AudioSource y el clip de audio están asignados
    if (audioSource != null && deathSound != null)
    {
        audioSource.PlayOneShot(deathSound); // Reproducir el sonido de muerte una vez
    }



        // Cargar la escena de Game Over al morir (cambia "GameOverScene" por el nombre de tu escena)
        SceneManager.LoadScene("GameOverScene");
    }

    // Método para que el jugador dispare
    void Shoot()
    {
        // Instanciar un proyectil en el firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.velocity = firePoint.right * bulletSpeed; // Asignar velocidad al proyectil

        // Reproducir el sonido de disparo si está asignado y si el AudioSource está presente
        if (shootSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootSound); // Reproducir el sonido de disparo una vez
        }
    }

    // Método para actualizar la UI de corazones según las vidas actuales
    void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = (i < currentHealth); // Activar o desactivar corazones según las vidas actuales
        }
    }

    // Método llamado cuando el jugador colisiona con otro objeto
   private void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.CompareTag("Enemy") || collision.CompareTag("Asteroid"))
    {
        TakeDamage(); // Reducir la salud del jugador

        // Reproducir sonido de colisión si el AudioSource y el clip de audio están asignados
        if (audioSource != null && collisionSound != null)
        {
            audioSource.PlayOneShot(collisionSound); // Reproducir el sonido de colisión una vez
        }

        Debug.Log("Detecta una colisión");
    }
   }
}



