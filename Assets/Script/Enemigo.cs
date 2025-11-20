using UnityEngine;

public class Enemigo : MonoBehaviour
{

    public int vida = 3;

    public void RecibirDaño(int cantidad)
    {
        vida -= cantidad;

        if (vida <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        Destroy(gameObject);
    }
}
