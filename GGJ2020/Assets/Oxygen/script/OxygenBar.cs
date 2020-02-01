using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenBar : MonoBehaviour {
   
    //private Transform bar;
    GameObject bar;
    GameObject BarSprite;

    private void Start()
    {
       bar =  GameObject.Find("Bar");
       BarSprite = GameObject.Find("BarSprite");
       //bar.transform.localScale = new Vector3(0, 0,0);
       //bar = transform.Find("bar");
       //bar.localScale = new Vector3(0.5f, 1, 1);
    }

    public void SetSize(float sizeNormalized)
    {
        bar.transform.localScale = new Vector3(sizeNormalized, 1f,0);
    }
    public void SetColor(Color color)
    {
        BarSprite.GetComponent<SpriteRenderer>().color=color;
    }


}
