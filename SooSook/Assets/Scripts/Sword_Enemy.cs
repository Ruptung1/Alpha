using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player playerComponent))
        {
            playerComponent.TakeDamage(1);
        }
    }
}
