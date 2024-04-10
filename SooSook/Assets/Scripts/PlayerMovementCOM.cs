using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementCOM : MonoBehaviour
{
    public float speed = 5f;

    private bool isMoving = false; 

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            Vector2 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            MovePlayer(clickPos);
        }
       
        if (isMoving)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
           
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.1f);
            if (hit.collider != null && hit.collider.CompareTag("Wall"))
            {
                isMoving = false; 
            }
        }
    }

    void MovePlayer(Vector2 targetPos)
    {
        isMoving = true;
       
        Vector2 direction = targetPos - (Vector2)transform.position;

        transform.up = direction.normalized;
    }

    public void RestisMoving()
    {
        isMoving = false;
    }
}
