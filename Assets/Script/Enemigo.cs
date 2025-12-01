using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int vida = 3;
    public float velocidad = 3f;

    private Transform jugador;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // El enemigo NO usa gravedad porque vuela
        if (rb != null)
        {
            rb.gravityScale = 0;
        }

        // Busca al jugador por tag
        jugador = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (jugador == null) return;

        // Dirección hacia el jugador
        Vector2 direccion = (jugador.position - transform.position).normalized;

        // Movimiento volando hacia el jugador
        rb.MovePosition(rb.position + direccion * velocidad * Time.deltaTime);

        // Mirar hacia el jugador (opcional)
        if (direccion.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);
    }


    // --- VIDA Y DAÑO ---
    public void RecibirDaño(int cantidad)
    {
        vida -= cantidad;
        if (vida <= 0)
            Destroy(gameObject);
    }

    // Si toca al jugador lo mata
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject); // Mata al jugador
        }
    }
}
