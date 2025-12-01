using UnityEngine;

public class Flecha : MonoBehaviour
{
    public float velocidad = 10f;

    void Update()
    {
        transform.Translate(Vector3.right * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            Destroy(collision.gameObject); // destruye al enemigo
            Destroy(gameObject);           // destruye la flecha
        }
    }
}
