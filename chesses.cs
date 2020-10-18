using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chesses : MonoBehaviour
{

    private int empty;
    private int turn;
    private int[,] chess = new int[3, 3];

    void Start()
    {
        reset();
    }

    void reset()
    {
        empty = 9;
        turn = 1;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                chess[i, j] = 0;
            }
        }
    }

    private void OnGUI()
    {
        int result = is_win();

        GUI.skin.button.fontSize = 50;
        GUI.skin.label.fontSize = 20;

        if (GUI.Button(new Rect(150, 200, 200, 80), "Reset"))
        {
            reset();
        }

        if (result == 1)
        {
            GUI.Label(new Rect(500, 20, 100, 50), "X wins");
        }
        else if (result == 2)
        {
            GUI.Label(new Rect(500, 20, 100, 50), "O wins");
        }
        else if (result == 3)
        {
            GUI.Label(new Rect(470, 20, 200, 50), "It's a draw");
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (chess[i, j] == 1)
                {
                    GUI.Button(new Rect(i * 100 + 400, j * 100 + 80, 100, 100), "X");
                }
                if (chess[i, j] == 2)
                {
                    GUI.Button(new Rect(i * 100 + 400, j * 100 + 80, 100, 100), "O");
                }
                if (GUI.Button(new Rect(i * 100 + 400, j * 100 + 80, 100, 100), ""))
                {
                    if (result == 0)
                    {
                        if (turn == 1) chess[i, j] = 1;
                        if (turn == 2) chess[i, j] = 2;
                        empty--;
                        if (empty % 2 == 1)
                        {
                            turn = 1;
                        }
                        else
                        {
                            turn = 2;
                        }
                    }
                }
            }
        }
    }

    int is_win()
    {
        int win = chess[0, 0];
        if (win != 0)
        {
            if (win == chess[0, 1] && win == chess[0, 2])
            {
                return win;
            }
            if (win == chess[1, 0] && win == chess[2, 0])
            {
                return win;
            }
        }

        win = chess[2, 2];
        if (win != 0)
        {
            if (win == chess[2, 0] && win == chess[2, 1])
            {
                return win;
            }
            if (win == chess[0, 2] && win == chess[1, 2])
            {
                return win;
            }
        }

        win = chess[1, 1];
        if (win != 0)
        {
            if (win == chess[0, 0] && win == chess[2, 2])
            {
                return win;
            }
            if (win == chess[0, 2] && win == chess[2, 0])
            {
                return win;
            }
            if (win == chess[0, 1] && win == chess[2, 1])
            {
                return win;
            }
            if (win == chess[1, 0] && win == chess[1, 2])
            {
                return win;
            }
        }

        if (empty == 0)
        {
            return 3;
        }
        else
        {
            return 0;
        }
    }
}

