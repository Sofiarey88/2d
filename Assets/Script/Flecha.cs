using UnityEngine;

public class Flecha : MonoBehaviour
{
    public float velocidad = 10f;
    public int daño = 1;

    void Update()
    {
        transform.Translate(Vector3.right * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemigo")) return;

        // Detecta distintos tipos de enemigos
        var enemigo1 = collision.GetComponent<Enemigo>();
        var enemigo2 = collision.GetComponent<EnemigoCorredor>();
        var enemigo3 = collision.GetComponent<EnemigoDisparador>();

        if (enemigo1 != null)
            enemigo1.RecibirDaño(daño);

        if (enemigo2 != null)
            enemigo2.RecibirDaño(daño);

        if (enemigo3 != null)
            enemigo3.RecibirDaño(daño);

        Destroy(gameObject);
    }
}
