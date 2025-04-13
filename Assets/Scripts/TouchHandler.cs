using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class TouchHandler : MonoBehaviour
{
    [SerializeField] private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        //if ((Touchscreen.current != null) && Touchscreen.current.primaryTouch.press.isPressed)
        if (Touch.activeTouches.Count > 0)
        {
            //Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
            Touch activeTouch = Touch.activeTouches[0];
            Vector2 touchPos = activeTouch.screenPosition;

            Vector2 worldPos = cam.ScreenToWorldPoint(new Vector3(touchPos.x, touchPos.y, cam.nearClipPlane));
            Debug.Log("Touch Position: " + worldPos);

            transform.position = worldPos;
        }

        // Codigo compatible con un for each de touches entrantes en la pantalla.
        //foreach(Touch touch in Touch.activeTouches)
        //{
        //    if (touch.phase == 0) // podemos poner los distintos pahse... para evaluar
        //    {

        //    }
        //    else
        //    {

        //    }

        //    // decidimos que hacer con los touches... cuando los queremos gestionar..
        //texto
        //}
    }
}
