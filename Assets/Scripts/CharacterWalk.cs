using UnityEngine;

public class CharacterWalk : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
