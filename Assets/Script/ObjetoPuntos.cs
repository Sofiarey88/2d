using UnityEngine;

public class ObjetoPuntos : MonoBehaviour
{
    public int cantidad = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PuntosGlobales.instancia.puntos += cantidad;

            Debug.Log("Puntos actuales: " + PuntosGlobales.instancia.puntos);

            Destroy(gameObject);
        }
    }
}
