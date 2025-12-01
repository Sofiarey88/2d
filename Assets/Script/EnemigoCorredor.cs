using UnityEngine;

public class EnemigoCorredor : MonoBehaviour
{
    public float fuerzaSaltoX = 8f;
    public float fuerzaSaltoY = 18f;
    public float tiempoEntreSaltos = 0.1f;

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

        // Limpio la velocidad para que todos los saltos sean iguales
        rb.linearVelocity = Vector2.zero;

        // SALTO CONSTANTE: arriba + hacia el jugador
        rb.AddForce(new Vector2(fuerzaSaltoX * direccion, fuerzaSaltoY), ForceMode2D.Impulse);
    }
}
