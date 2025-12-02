using UnityEngine;
using TMPro;

public class UI_Puntos : MonoBehaviour
{
    public TextMeshProUGUI puntosTexto;

    private void Update()
    {
        puntosTexto.text = "Puntos: " + PuntosGlobales.instancia.puntos;
    }
}
