using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioNivel : MonoBehaviour
{
    public string siguienteEscena;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            // Guardar puntos y tiempo ANTES de cambiar de escena
            if (PuntosGlobales.instancia != null)
                PuntosGlobales.instancia.GuardarPuntos();

            if (TiempoGlobal.instancia != null)
                TiempoGlobal.instancia.GuardarTiempo();

            // Cambiar de escena
            SceneManager.LoadScene(siguienteEscena);
        }
    }
}
