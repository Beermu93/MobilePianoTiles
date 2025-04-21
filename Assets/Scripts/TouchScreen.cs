using UnityEngine;
using UnityEngine.InputSystem;
public class TouchController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    private void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }
    private void Update()
    {        // Verificar si hay toques en la pantalla
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            // Obtener la posición del toque
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

            // Convertir posición de toque a posición en el mundo
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, mainCamera.nearClipPlane));
            worldPosition.z = 0; // Para un juego 2D// Mover el objeto a la posición del toque
            transform.position = worldPosition;
        }
        else
        {
            transform.position = new Vector3(-10, 0, 0);
        }
    }
}
