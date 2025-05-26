using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5f;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
