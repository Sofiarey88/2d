using UnityEngine;
using TMPro;

public class UI_Tiempo : MonoBehaviour
{
    public TMP_Text textoTiempo;

    private void Update()
    {
        textoTiempo.text = "Tiempo: " + TiempoGlobal.instancia.tiempo.ToString("F2");
    }
}
