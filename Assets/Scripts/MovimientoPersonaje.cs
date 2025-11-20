using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidad = 5f;
    private Rigidbody2D rb; // Rigidbody para 2D
    // --- INVENTARIO: CONTADORES DE BASURA ---
    public int basuraPlastico = 0;
    public int basuraPapel = 0;
    public int basuraVidrio = 0; 
    public int basuraOrganica = 0;
    // ----------------------------------------

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    void FixedUpdate()
    {
        // 1. Lectura del Input (Traslación)
        float inputX = Input.GetAxis("Horizontal"); // -1 (izquierda) a 1 (derecha)
        float inputY = Input.GetAxis("Vertical");

        // 2. Aplicar la Traslación (Movimiento)
        Vector2 movimiento = new Vector2(inputX, inputY);
        rb.linearVelocity = movimiento * velocidad;

        // 3. Llamar a la función de rotación para actualizar la dirección
        // Solo llamamos a esta función si hay movimiento
        if (inputX != 0)
        {
            RotarPersonaje(inputX);
        }
    }
    
    // FUNCIÓN: Añadir la basura al inventario
    public void AñadirBasura(string tipo)
    {
        switch (tipo)
        {
            case "Plastico":
                basuraPlastico++;
                break;
            case "Papel":
                basuraPapel++;
                break;
            case "Vidrio":
                basuraVidrio++;
                break;
            case "Organica":
                basuraOrganica++;
                break;
        }
        Debug.Log("Recolectado " + tipo + ". Total de Plástico: " + basuraPlastico);
    }

    // Rotación (Giro del Sprite)
    void RotarPersonaje(float direccionX)
    {
        // Si la dirección es negativa (izquierda), gira 180 grados en Y.
        if (direccionX < 0)
        {
            // Usamos transform.localScale.x para voltear el sprite 2D
            transform.localScale = new Vector3(-1, 1, 1); 
        }
        // Si la dirección es positiva (derecha), usa la escala normal.
        else if (direccionX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); 
        }
    }
}