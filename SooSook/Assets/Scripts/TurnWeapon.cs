using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnWeapon : MonoBehaviour
{
    public Transform target; 
    public float radius = 2f;
    public float speed = 2f; 

    private float angle = 0f; 

    void Update()
    {
        float x = target.position.x + radius * Mathf.Cos(angle);
        float y = target.position.y + radius * Mathf.Sin(angle);


        transform.position = new Vector2(x, y);

        Vector2 direction = target.position - transform.position;
        float angleToTarget = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotationToTarget = Quaternion.AngleAxis(angleToTarget, Vector3.forward);
        transform.rotation = rotationToTarget;

        angle += speed * Time.deltaTime;
    }
}