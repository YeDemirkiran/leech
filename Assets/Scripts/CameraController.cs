using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Vector2 speed = Vector2.one;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 position = transform.position;
            position.x += Input.GetAxisRaw("Mouse X") * speed.x;
            position.y += Input.GetAxisRaw("Mouse Y") * speed.y;
            transform.position = position;
        }
    }
}
