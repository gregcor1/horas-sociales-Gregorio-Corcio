using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    private Rigidbody2D rb; // Rigidbody2D para el movimiento físico del jugador
    Vector2 input;  // Vector para almacenar la entrada de movimiento del jugador
    public float speed; // Velocidad de movimiento del jugador
    public int maxHealth = 3; // Vidas máximas del jugador
    private int currentHealth; // Vidas actuales del jugador
    private AudioSource audioSource; // Referencia al componente AudioSource
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtenemos el Rigidbody2D del jugador
        currentHealth = maxHealth; // Inicializa las vidas actuales
        audioSource = GetComponent<AudioSource>(); // Obtén la referencia al AudioSource
    }

    void Update()
    {
        input.x = Input.GetAxis("Horizontal"); // Capturamos la entrada de movimiento horizontal
        input.y = Input.GetAxis("Vertical");   // Capturamos la entrada de movimiento vertical
    }
    
    private void FixedUpdate()
    {
        // Aplicamos el movimiento al Rigidbody2D del jugador
        rb.velocity = input * speed * Time.fixedDeltaTime;

        // Limitamos la posición del jugador en el eje x dentro de la zona de juego
        rb.position = new Vector2(Mathf.Clamp(rb.position.x, -6f, 6f), Mathf.Clamp(rb.position.y, -3.3f, 3.33f));
    }


    private void TakeDamage()
    {
        currentHealth--; // Reduce la salud del jugador

        // Verifica si el jugador se queda sin vidas
        if (currentHealth <= 0)
        {
            Die(); // Llama al método para manejar la muerte del jugador
        }
    }

    private void Die()
    {
        // Reproduce el sonido de muerte
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.PlayOneShot(audioSource.clip); // Reproduce el sonido una vez
        }

        // Reinicia la escena o realiza otra acción cuando el jugador muere
        Application.Quit();
    }

    // Método llamado cuando el jugador colisiona con otro objeto
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el jugador colisiona con un enemigo o un asteroide
        if (collision.CompareTag("Enemy") || collision.CompareTag("Asteroid"))
        {
            TakeDamage(); // Llama al método para reducir la salud del jugador
        

             Debug.Log("Detecta una colisión");
        }
        // Destruimos el objeto con el que colisiona el jugador
        Destroy(collision.gameObject);
    }
}