using UnityEngine;

public class EnemigoCorredor : MonoBehaviour
{
    public float fuerzaSaltoX = 4f;
    public float fuerzaSaltoY = 8f;
    public float tiempoEntreSaltos = 0.5f;

    private Rigidbody2D rb;
    private Transform jugador;

    float proximoSalto = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Time.time >= proximoSalto)
        {
            Saltar();
            proximoSalto = Time.time + tiempoEntreSaltos;
        }
    }

    void Saltar()
    {
        if (jugador == null) return;

        float direccion = Mathf.Sign(jugador.position.x - transform.position.x);

        // Reinicio velocidad para saltos consistentes
        rb.linearVelocity = Vector2.zero;

        rb.AddForce(new Vector2(fuerzaSaltoX * direccion, fuerzaSaltoY), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            MovimientoJugador pj = collision.collider.GetComponent<MovimientoJugador>();

            if (pj != null)
            {
                pj.TomarDaño(2);   // le quita 2 vidas
                Debug.Log("El enemigo hizo daño: -2 vidas");
            }
        }
    }
}
