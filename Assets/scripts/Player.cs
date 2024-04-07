using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anime;
    private SpriteRenderer spriteRenderer;
    private Vector3 stPosition;
    private Vector3 psPosition = new Vector3(-0.2f, -1.24f, 0);
    private bool isTurn = false;

    private int moveCnt = 0;
    private int turnCnt = 0;
    private int spawnCnt = 0;

    void Start()
    {
        anime = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        stPosition = transform.localPosition;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            CharTurn();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            CharMove();
        }
    }

    private void CharTurn()
    {
        isTurn = isTurn == true ? false : true;

        spriteRenderer.flipX = isTurn;
    }

    private void CharMove()
    {
        moveCnt++;

        MoveDirection();

        if (isFallTurn())
        {
            anime.SetBool("Die", true);
            return;
        }

        if(moveCnt > 5)
        {
            RespawnBlock();
        }
    }

    private void MoveDirection()
    {
        if (isTurn)
        {
            psPosition += new Vector3(-0.3f, 0.15f, 0);
        }
        else
        {
            psPosition += new Vector3(0.3f, 0.15f, 0);
        }

        transform.position = psPosition;
        anime.SetTrigger("Move");
    }

    private bool isFallTurn()
    {
        bool resurt = false;

        if (Gamemanager.Instance.isTurn[turnCnt] != isTurn)
        {
            resurt = true;
        }

        turnCnt++;

        if(turnCnt > Gamemanager.Instance.Blocks.Length - 1)
        {
            turnCnt = 0;
        }

        return resurt;
    }

    private void RespawnBlock()
    {
        Gamemanager.Instance.SpawnBlock(spawnCnt);

        spawnCnt++;

        if(spawnCnt > Gamemanager.Instance.Blocks.Length - 1)
        {
            spawnCnt = 0;
        }
    }
}
