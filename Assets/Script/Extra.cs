using UnityEngine;

public class Extra : MonoBehaviour
{
    public int puntos = 5; // puntos que suma cuando lo agarras

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Acá sumás puntos
            GameManager.instance.SumarPuntos(puntos);

            Destroy(gameObject);
        }
    }
}
