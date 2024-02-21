using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject slotButton;

    private void Start()
    {
        inventory = GameObject.FindWithTag("Hero").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hero"))
        {
            for (int i = 1; i < inventory.slots.Length; i++)
            {
                if (gameObject.CompareTag("Plank"))
                {
                    inventory.isFull[0] = true;
                    Instantiate(slotButton, inventory.slots[0].transform);
                    Destroy(gameObject);
                    break;
                }
                else if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(slotButton, inventory.slots[i].transform);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}