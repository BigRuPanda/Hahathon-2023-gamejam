using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            Counter.counter_cnt += 1;
        }
    }
}
