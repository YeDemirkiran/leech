using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Vector2 speed = Vector2.one;
    [SerializeField] Vector2 xClamp;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Vector3 position = transform.position;
            position.x += Input.GetAxisRaw("Mouse X") * speed.x;
            position.y += Input.GetAxisRaw("Mouse Y") * speed.y;
            position.x = Mathf.Clamp(position.x, xClamp.x, xClamp.y);
            transform.position = position;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
