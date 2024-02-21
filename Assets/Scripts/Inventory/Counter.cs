using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text counterText;
    public static int counter_cnt;

    void Update()
    {
        counterText.text = counter_cnt.ToString();
    }
}