using UnityEngine;

public class EnemigoDisparador : MonoBehaviour
{
    [Header("Disparo")]
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    public float tiempoEntreDisparos = 1.5f;
    public float rangoDisparo = 6f;  // distancia mínima para disparar

    [Header("Vida")]
    public int vida = 3;
    public int dañoAlPlayer = 1;  // daño al jugador al tocarlo

    [Header("Drop")]
    public GameObject monedaPrefab;   // ← AGREGADO

    private Transform jugador;
    private float proximoDisparo = 0f;

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (jugador == null)
            Debug.LogWarning("No se encontró el Player con tag 'Player'");
    }

    void Update()
    {
        if (jugador == null) return;

        float distancia = Vector2.Distance(transform.position, jugador.position);

        // Solo dispara si el jugador está dentro del rango
        if (distancia <= rangoDisparo)
        {
            ApuntarAlJugador();

            if (Time.time >= proximoDisparo)
            {
                Disparar();
                proximoDisparo = Time.time + tiempoEntreDisparos;
            }
        }
    }

    void ApuntarAlJugador()
    {
        Vector3 dir = jugador.position - transform.position;
        float angulo = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        // SOLO rota el punto de disparo, no el enemigo
        puntoDisparo.rotation = Quaternion.Euler(0, 0, angulo);
    }

    void Disparar()
    {
        Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);
        Debug.Log("¡Bala disparada!");
    }

    public void RecibirDaño(int dmg)
    {
        vida -= dmg;
        if (vida <= 0)
        {
            SoltarMoneda();    // ← AGREGADO
            Destroy(gameObject);
        }
    }

    void SoltarMoneda()    // ← AGREGADO
    {
        if (monedaPrefab != null)
        {
            Instantiate(monedaPrefab, transform.position, Quaternion.identity);
            Debug.Log("Moneda soltada!");
        }
        else
        {
            Debug.LogWarning("No asignaste monedaPrefab en el enemigo");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            MovimientoJugador pj = collision.collider.GetComponent<MovimientoJugador>();
            if (pj != null)
            {
                pj.TomarDaño(dañoAlPlayer);
                Debug.Log("El jugador recibió daño al chocar con el enemigo");
            }
        }
    }
}
