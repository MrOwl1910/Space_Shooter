using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public GameObject[] _shootPoint;

    public GameObject bullet;

   [SerializeField] float movespeed = 1f;

    Rigidbody2D _rb;

    float shoottime = 1f;
    [SerializeField]
    float delaytime = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
       
            BulletShoot();
        
        Debug.Log(shoottime + "and " + delaytime);
        PlayerInput();
    }

    void BulletShoot()
    {
        foreach (var shootpoint in _shootPoint)
        {
                Instantiate(bullet, shootpoint.transform.position, Quaternion.identity);           
        }
    }

    void PlayerInput()
    {
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _rb.position = new Vector2(transform.position.x + - movespeed, transform.position.y);
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            _rb.position = new Vector2(transform.position.x + movespeed, transform.position.y);
        }
    }
}//class