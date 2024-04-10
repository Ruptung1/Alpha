using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.TryGetComponent<Player>(out Player playerComponent))
        {
            playerComponent.TakeDamage(1);
            Destroy(gameObject);

        }
        if (collision.gameObject.tag != null )
        {
            Destroy(gameObject);
        }
        
    }
    void Awake()
    {
        Invoke("DeleteBullet", 2f);
    }

    private void DeleteBullet()
    {
        Destroy(gameObject);
    }
}
