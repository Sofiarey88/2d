using UnityEngine;

public class PuntosGlobales : MonoBehaviour
{
    public static PuntosGlobales instancia;

    public int puntos = 0;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);

            // Cargar al iniciar
            CargarPuntos();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // --- Guardado ---
    public void GuardarPuntos()
    {
        PlayerPrefs.SetInt("Puntos", puntos);
        PlayerPrefs.Save();
        Debug.Log("Puntos guardados: " + puntos);
    }

    // --- Carga ---
    public void CargarPuntos()
    {
        puntos = PlayerPrefs.GetInt("Puntos", 0);
        Debug.Log("Puntos cargados: " + puntos);
    }
}
