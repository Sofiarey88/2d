using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int vida = 3;
    public float velocidad = 3f;

    public int dañoAlPlayer = 10;

    private Transform jugador;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb != null)
            rb.gravityScale = 0;

        jugador = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (jugador == null || rb == null) return;

        Vector2 direccion = (jugador.position - transform.position).normalized;
        rb.MovePosition(rb.position + direccion * velocidad * Time.deltaTime);

        if (direccion.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);
    }

    // --------------------------
    // VIDA DEL ENEMIGO
    // --------------------------
    public void RecibirDaño(int cantidad)
    {
        vida -= cantidad;
        if (vida <= 0)
            Destroy(gameObject);
    }

    // --------------------------
    // DAÑO AL PLAYER
    // --------------------------
    private void AplicarDañoA(GameObject obj)
    {
        // Buscamos el script en el objeto o en sus padres en caso de que el collider esté en un hijo.
        var player = obj.GetComponent<MovimientoJugador>() ?? obj.GetComponentInParent<MovimientoJugador>();
        if (player != null)
        {
            player.TomarDaño(dañoAlPlayer);
            Debug.Log($"Enemigo: apliqué {dañoAlPlayer} de daño a {obj.name}");
        }
        else
        {
            Debug.Log($"Enemigo: colisión con '{obj.name}' pero no tiene MovimientoJugador");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AplicarDañoA(collision.gameObject);
        }
    }

    // Por si el enemigo usa colisiones físicas (no-trigger)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            AplicarDañoA(collision.collider.gameObject);
        }
    }
}