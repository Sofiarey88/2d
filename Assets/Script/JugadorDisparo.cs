using UnityEngine;

public class JugadorDisparo : MonoBehaviour
{
    public GameObject flechaPrefab;
    public Transform puntoDeDisparo;
    public float tiempoEntreDisparos = 0.3f;

    float proximoDisparo = 0f;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > proximoDisparo)
        {
            Disparar();
            proximoDisparo = Time.time + tiempoEntreDisparos;
        }
    }

    void Disparar()
    {
        Instantiate(flechaPrefab, puntoDeDisparo.position, puntoDeDisparo.rotation);
    }
}
