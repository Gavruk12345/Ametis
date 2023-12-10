using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    public float speed = 5f;       // Швидкість руху
    public float distance = 5f;    // Дальність руху вгору і вниз

    private float initialY;        // Початкова позначка Y

    void Start()
    {
        initialY = transform.position.y;
    }

    void Update()
    {
        // Рух вверх і вниз в межах визначеної дальності
        float newY = initialY + Mathf.PingPong(Time.time * speed, distance * 2) - distance;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
