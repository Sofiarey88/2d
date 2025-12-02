using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int vida = 3;
    public float velocidad = 3f;
    public int danoAlPlayer = 1; // resta 1 vida (círculo) por toque

    private Transform jugador;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null) rb.gravityScale = 0f;
        jugador = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (jugador == null || rb == null) return;
        Vector2 direccion = (jugador.position - transform.position).normalized;
        rb.MovePosition(rb.position + direccion * velocidad * Time.deltaTime);
        transform.localScale = new Vector3(direccion.x > 0 ? 1 : -1, 1, 1);
    }

    public void RecibirDaño(int cantidad)
    {
        vida -= cantidad;
        if (vida <= 0) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        MovimientoJugador player = collision.GetComponent<MovimientoJugador>();
        if (player != null)
        {
            player.TomarDaño(danoAlPlayer);
        }
    }
}
