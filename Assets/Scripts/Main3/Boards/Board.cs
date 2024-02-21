using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public Text boardText;
    public static int board_cnt = 3;

    void Start()
    {
        board_cnt = 3;
    }

    void Update()
    {
        boardText.text = board_cnt.ToString();
    }
}
