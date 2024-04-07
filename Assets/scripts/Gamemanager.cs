using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager Instance;

    [Header("계단")]
    [Space(10)]
    public GameObject[] Blocks;
    public bool[] isTurn;

    private enum State {Start, Left, Right };
    private State state;
    private Vector3 psPosition;

    void Start()
    {
        Instance = this;

        Init();
        InitBlocks();
    }

    private void Init()
    {
        state = State.Start;
        psPosition = Vector3.zero;

        isTurn = new bool[Blocks.Length];

        for (int i = 0; i < Blocks.Length; i++)
        {
            Blocks[i].transform.position = Vector3.zero;
            isTurn[i] = false;
        }
    }

    private void InitBlocks()
    {
        for (int i = 0; i < Blocks.Length; i++)
        {
            switch (state)
            {
                case State.Start:
                    Blocks[i].transform.position = new Vector3(0.1f, -1.3f, 0);
                    state = State.Right;
                    break;

                case State.Left:
                    Blocks[i].transform.position = psPosition + new Vector3(-0.3f, 0.15f, 0);
                    isTurn[i] = true;
                    break;

                case State.Right:
                    Blocks[i].transform.position = psPosition + new Vector3(0.3f, 0.15f, 0);
                    isTurn[i] = false;
                    break;
            }

            psPosition = Blocks[i].transform.position;

            if (i != 0)
            {
                int ran = Random.Range(0, 5);

                if(ran < 2 && i < Blocks.Length - 1)
                {
                    state = state == State.Left ? State.Right : State.Left;
                }
            }
        }
    }

    public void SpawnBlock(int cnt)
    {
        int ran = Random.Range(0, 5);

        if(ran < 2)
        {
            state = state == State.Left ? State.Right : State.Left;
        }

        switch (state)
        {
            case State.Left:
                Blocks[cnt].transform.position = psPosition + new Vector3(-0.3f, 0.15f, 0);
                isTurn[cnt] = true;
                break;

            case State.Right:
                Blocks[cnt].transform.position = psPosition + new Vector3(0.3f, 0.15f, 0);
                isTurn[cnt] = false;
                break;
        }

        psPosition = Blocks[cnt].transform.position;
    }
}
