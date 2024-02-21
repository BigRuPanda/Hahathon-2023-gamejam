using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LedderText : MonoBehaviour
{
    public Text text;
    public GameObject hero;
    public float distance;

    private void Update()
    {
        Vector2 objectPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 playerPos = new Vector2(hero.transform.position.x, hero.transform.position.y);

        float distance1 = Vector2.Distance(objectPos, playerPos);

        if (distance1 <= distance)
        {
            text.enabled = false;
        }

        else if (distance1 > distance)
        {
            text.enabled = true;
        }
    }
}