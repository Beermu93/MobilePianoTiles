using System;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.SceneManagement;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class TouchHandler : MonoBehaviour
{
    public static TouchHandler Instance;
    public Action<Vector3> OnTouch;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable() { EnhancedTouchSupport.Disable(); }

    private void Update()
    {
        if (Touch.activeTouches.Count > 0)
        {
            Touch activeTouch = Touch.activeTouches[0];
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(
                new Vector3(
                    activeTouch.screenPosition.x,
                    activeTouch.screenPosition.y,
                    -Camera.main.transform.position.z
                )
            );

            Vector2 worldPos2D = new Vector2(worldPos.x, worldPos.y);
            RaycastHit2D hit = Physics2D.Raycast(worldPos2D, Vector2.zero);

            if (hit.collider != null)
            {
                TileAction tile = hit.collider.GetComponent<TileAction>();
                if (tile != null) { tile.OnTouch(); }
            }
            else 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            } 
        }
    }
}
