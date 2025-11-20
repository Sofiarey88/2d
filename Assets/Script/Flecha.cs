using UnityEngine;

public class Flecha : MonoBehaviour
{
   
    public float velocidad = 10f;
    public int daño = 1;
    public float tiempoDeVida = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // La flecha se mueve hacia adelante según el puntoDisparo.right
        rb.linearVelocity = transform.right * velocidad;

        // Se destruye sola si no choca con nada
        Destroy(gameObject, tiempoDeVida);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            collision.GetComponent<Enemigo>().RecibirDaño(daño);
            Destroy(gameObject);
        }
    }
}

    

