using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindTimer : MonoBehaviour
{
    public float timeToSpawn = 3f;
    public GameObject time;
    public GameObject wind;
    public Text text;
    public WindCount windcount;

    private float timer = 0f;
    private bool flag = false;
    private bool flag2 = true;
    private bool flag3 = false;

    private void Start()
    {
        windcount = GameObject.Find("Windows").GetComponent<WindCount>();
        text = GameObject.Find("Text").GetComponent<Text>();
    }

    private void Update()
    {
        if (flag)
        {
            timer += Time.deltaTime;

            if (timer >= timeToSpawn)
            {
                func();
            }
        }
        else
        {
            timer = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            time.gameObject.SetActive(true);
            flag = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            flag = false;
            timer = 0f;
            time.gameObject.SetActive(false);
        }
    }

    public void func()
    {
        {
            if (Board.board_cnt > 0)
            {
                if (flag2 == true)
                {
                    flag2 = false;
                    flag3 = true;
                    windcount.num += 1;
                    Board.board_cnt -= 1;
                }
            }

            if (flag3 == true)
            {
                timer = 0f;
                wind.gameObject.SetActive(false);
                wind.gameObject.SetActive(true);
            }
        }
    }
}