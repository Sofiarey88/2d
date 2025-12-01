using UnityEngine;


public class EnemigoDisparador : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    public float tiempoEntreDisparos = 1.5f;

    public float rangoDisparo = 6f;  // distancia para empezar a disparar
    public int vida = 3;

    private Transform jugador;
    private float proximoDisparo = 0f;

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (jugador == null) return;

        float distancia = Vector2.Distance(transform.position, jugador.position);

        // Solo dispara si el jugador está cerca
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
        transform.rotation = Quaternion.Euler(0, 0, angulo);
    }

    void Disparar()
    {
        Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);
    }

    public void RecibirDaño(int dmg)
    {
        vida -= dmg;
        if (vida <= 0)
            Destroy(gameObject);
    }
}


