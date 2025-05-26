using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
   [SerializeField] float movespeed = 1f;

    public GameObject UI;
    Rigidbody2D _rb;
    Vector2 MoveDirection;

    public bool IsDead = false;

    public Shooting weapon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        UI.SetActive (false);
        _rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if(!IsDead) 
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            MoveDirection = new Vector2(moveX, moveY).normalized;
            if (Input.GetMouseButtonDown(0))
            {
                FindObjectOfType<AudioManeger>().Play("Shoot");
                weapon.Fire();
            }
        }

        if(IsDead)
        {
            UI.SetActive(true);
            _rb.velocity = new Vector2(transform.position.x, transform.position.y);
        }
    }
    private void FixedUpdate()
    {
        if (!IsDead)
        {
            _rb.velocity = new Vector2(MoveDirection.x * movespeed, MoveDirection.y * movespeed);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EnemyBullet"))
        {
            IsDead = true;
        }
    }

}//class