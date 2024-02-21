using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ledder : MonoBehaviour
{
    public Button button;
    public GameObject breaklestnicha;
    public GameObject truelestnicha;
    public AudioSource chinimsound;
    private Inventory inventory;
    
    private void Start()
    {
        inventory = GameObject.FindWithTag("Hero").GetComponent<Inventory>();
    }

    private void Update()
    {
        bool flag = true;

        for (int i = 1; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                flag = false;
                break;
            }
        }

        if (flag == true && Counter.counter_cnt >= 3)
        {
            button.gameObject.SetActive(true);
        }
    }

    public void ActivateObject()
    {
        chinimsound.Play();
        breaklestnicha.SetActive(false);
        truelestnicha.SetActive(true);
        button.interactable = false;
        Board.board_cnt = 3;
    }
}