using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject activeFrame;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hero"))
        {
            activeFrame.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Hero"))
        {
            activeFrame.SetActive(false);
        }

    }
}
