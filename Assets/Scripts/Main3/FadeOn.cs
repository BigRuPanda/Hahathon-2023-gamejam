using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOn : MonoBehaviour
{
    public GameObject fade;
    
    public void fadeOn()
    {
        fade.gameObject.SetActive(true);
    }
}