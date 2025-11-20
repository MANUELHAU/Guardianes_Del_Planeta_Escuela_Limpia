using UnityEngine;

public class SeguirJugador : MonoBehaviour
{
    [SerializeField] private Transform jugador; // Arrastra aqu� tu jugador en el Inspector
    [SerializeField] private float suavizado = 0.125f;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10);

    private void LateUpdate()
    {
        if (jugador != null)
        {
            Vector3 posicionDeseada = jugador.position + offset;
            Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posicionDeseada, suavizado);
            transform.position = posicionSuavizada;
        }
    }
}