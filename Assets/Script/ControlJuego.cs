using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ControlJuego : MonoBehaviour
{
    public static ControlJuego instancia;

    [Header("UI - Game Over y Victoria")]
    public GameObject panelPerdiste;
    public GameObject panelGanaste;

    [Header("UI - Datos Finales (solo en la escena final)")]
    public TMP_Text textoTiempoFinal;
    public TMP_Text textoPuntosFinales;

    private void Awake()
    {
        instancia = this;
    }

    private void Start()
    {
        if (panelPerdiste) panelPerdiste.SetActive(false);
        if (panelGanaste) panelGanaste.SetActive(false);
    }

    // =======================
    //        PERDER
    // =======================
    public void Perder()
    {
        Time.timeScale = 0f;

        if (panelPerdiste)
        {
            panelPerdiste.SetActive(true);
            ActivarUI(panelPerdiste);
        }
    }

    // =======================
    //        GANAR
    // =======================
    public void Ganar()
    {
        Time.timeScale = 0f;

        // Leer TIEMPO y PUNTOS guardados desde PlayerPrefs
        float tiempo = PlayerPrefs.GetFloat("TiempoFinal", 0f);
        int puntos = PlayerPrefs.GetInt("PuntosFinales", 0);

        // Mostrar en UI
        if (textoTiempoFinal)
            textoTiempoFinal.text = "Tiempo: " + tiempo.ToString("F1");

        if (textoPuntosFinales)
            textoPuntosFinales.text = "Puntos: " + puntos;

        if (panelGanaste)
        {
            panelGanaste.SetActive(true);
            ActivarUI(panelGanaste);
        }
    }

    // =======================
    //     BOTÓN REINICIAR
    // =======================
    public void Reintentar()
    {
        Debug.Log("CLICK DETECTADO");

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // =======================
    //     BOTÓN IR AL MENÚ
    // =======================
    public void IrMenu(string nombreEscena)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nombreEscena);
    }

    // =======================
    //  HABILITAR UI AÚN PAUSADO
    // =======================
    private void ActivarUI(GameObject panel)
    {
        var cg = panel.GetComponent<CanvasGroup>();

        if (cg == null)
            cg = panel.AddComponent<CanvasGroup>();

        cg.interactable = true;
        cg.blocksRaycasts = true;
        cg.ignoreParentGroups = true;
    }
}
