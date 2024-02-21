using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindCount : MonoBehaviour
{
    public int num;
    private float timer = 0f;
    public GameObject fade;
    public GameObject fadewin;

    private void Start(){
        num = 0;
    }

    private void Update(){
        if (timer > 35)
        {
            if (num < 6)
            {
                fadeOn();
            }
        }

        if (timer > 120)
        {
           fadeWin();
        }

        timer += Time.deltaTime;
    }

    public void fadeOn()
    {
        fade.gameObject.SetActive(true);
    }

    public void fadeWin()
    {
        fadewin.gameObject.SetActive(true);
    }
}