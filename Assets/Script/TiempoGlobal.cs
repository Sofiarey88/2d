using UnityEngine;

public class TiempoGlobal : MonoBehaviour
{
    public static TiempoGlobal instancia;

    public float tiempo = 0f;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);

            // Cargar al iniciar
            CargarTiempo();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        tiempo += Time.deltaTime;
    }

    // --- Guardado ---
    public void GuardarTiempo()
    {
        PlayerPrefs.SetFloat("Tiempo", tiempo);
        PlayerPrefs.Save();
        Debug.Log("Tiempo guardado: " + tiempo);
    }

    // --- Carga ---
    public void CargarTiempo()
    {
        tiempo = PlayerPrefs.GetFloat("Tiempo", 0f);
        Debug.Log("Tiempo cargado: " + tiempo);
    }
}
