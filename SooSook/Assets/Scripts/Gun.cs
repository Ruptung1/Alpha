using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform FirePoint;
    public float BulletSpeed = 25f;

    public Transform player;


    private void Start()
    {
        InvokeRepeating("Fire", 0f, 2f);
    }

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(FirePoint.up * BulletSpeed, ForceMode2D.Impulse);
     }

   
}
