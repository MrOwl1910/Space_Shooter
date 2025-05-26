using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    private float stopDistance = 5f;
    private Vector3 startPosition;
    private bool stopped = false;

    public int maxHealth = 3;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        startPosition = transform.position;
    }

    public void SetStopDistance(float distance)
    {
        stopDistance = distance;
    }

    void Update()
    {
        if (!stopped)
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            if (Vector3.Distance(startPosition, transform.position) >= stopDistance)
                stopped = true;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        // You can add explosion effects, sound, score update here
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            TakeDamage(1);
        }
    }
}//class