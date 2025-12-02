using System;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad = 10f;
    public int daño = 1; // daño que hará la bala (configurable desde el Inspector)

    void Update()
    {
        transform.Translate(Vector3.right * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Buscar el componente de salud del jugador (MovimientoJugador)
            var jugador = collision.GetComponent<MovimientoJugador>() ?? collision.GetComponentInParent<MovimientoJugador>();
            if (jugador != null)
            {
                jugador.TomarDaño(daño); // restar vida en lugar de destruir el jugador
            }

            Destroy(gameObject); // destruir solo la bala
        }
    }
}

