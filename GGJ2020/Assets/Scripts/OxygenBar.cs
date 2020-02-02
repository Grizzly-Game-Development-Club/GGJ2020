using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenBar : MonoBehaviour
{
    GameObject bar;
    void Start()
    {
         bar = GameObject.Find("Bar");
    }
    public void SetSize(float sizeNormalized)
    {
        bar.transform.localScale = new Vector3(sizeNormalized, 1f, 0f);
    }
    public void SetColor(Color color)
    {
        GameObject.Find("barsprite").GetComponent<SpriteRenderer>().color = color;
    }

}
