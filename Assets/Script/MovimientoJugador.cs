using UnityEngine;
using UnityEngine.UI;

public class MovimientoJugador : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 5f;
    public float fuerzaSalto = 7f;

    private Rigidbody2D rb;
    private bool enSuelo;

    [Header("Vidas")]
    public int vidasMax = 4;
    public int vidasActuales;

    [Header("UI Corazones")]
    public Image[] corazones;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vidasActuales = vidasMax;
        ActualizarCorazones();
    }

    private void Update()
    {
        float movimiento = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(movimiento * velocidad, rb.linearVelocity.y);

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && enSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        enSuelo = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        enSuelo = false;
    }

    // --- MÉTODO QUE LLAMAN LOS ENEMIGOS ---
    public void TomarDaño(int cantidad)
    {
        vidasActuales -= cantidad;
        if (vidasActuales < 0) vidasActuales = 0;

        ActualizarCorazones();

        if (vidasActuales == 0)
        {
            // LLAMAR A CONTROLJUEGO SIN FindObjectOfType
            ControlJuego.instancia.Perder();
        }
    }

    void ActualizarCorazones()
    {
        if (corazones == null || corazones.Length == 0) return;

        for (int i = 0; i < corazones.Length; i++)
        {
            corazones[i].enabled = i < vidasActuales;
        }
    }
}
