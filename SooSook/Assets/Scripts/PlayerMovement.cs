using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private bool isMoving = false;

    private Vector2 targetPosition;

    void Update()
    { 
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);        
       
            isMoving = true;
        }

        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

           Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f);
           
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Wall"))
                {
                    isMoving = false; 
                    break;
                }
            }
        }
    }
}
