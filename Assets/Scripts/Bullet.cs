using UnityEngine;
[RequireComponent (typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    Rigidbody2D _rb;
    public float speed = 2f;

    

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
       // transform.position = Vector2.up * speed * Time.deltaTime;

        Destroy(gameObject, 3f);
    }
    private void Update()
    {
        _rb.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        //transform.position = Vector2.up * speed * Time.deltaTime;
    }
}