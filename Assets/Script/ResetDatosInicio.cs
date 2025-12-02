using UnityEngine;

public class ResetDatosInicio : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteKey("TiempoFinal");
        PlayerPrefs.DeleteKey("PuntosFinales");

        // Reiniciar tus globales también
        TiempoGlobal.instancia.tiempo = 0f;
        PuntosGlobales.instancia.puntos = 0;
    }
}
