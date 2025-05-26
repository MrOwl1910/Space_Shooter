using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject BulletPreFab;
    public Transform FirePoint;

    public Transform parent;

    public float FireForce = 20f;

    public void Fire()
    {
        GameObject Bullet = Instantiate(BulletPreFab, FirePoint.position, Quaternion.identity, parent);

        Bullet.GetComponent<Rigidbody2D>().AddForce(FirePoint.up * FireForce, ForceMode2D.Impulse);
    }

   
}
