using UnityEngine;

public class ControlVictoria : MonoBehaviour
{
    private bool yaGano = false;

    void Update()
    {
        if (yaGano) return;

        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemigo");

        if (enemigos.Length == 0)
        {
            yaGano = true;

            // Guardar datos en PlayerPrefs
            PlayerPrefs.SetFloat("TiempoFinal", TiempoGlobal.instancia.tiempo);
            PlayerPrefs.SetInt("PuntosFinales", PuntosGlobales.instancia.puntos);
            PlayerPrefs.Save();

            // Llamar a GANAR
            ControlJuego.instancia.Ganar();
        }
    }
}
