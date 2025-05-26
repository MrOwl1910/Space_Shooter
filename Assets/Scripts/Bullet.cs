using UnityEngine;
[RequireComponent (typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        { 
            Destroy(gameObject);
        }
    }
}