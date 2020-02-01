using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour
{
    public float oxygenDepletion = 0.005f;
    [SerializeField] private OxygenBar oxygenBar;
    private void Start()
    {
        //oxygenBar.SetSize(.4f);
        Debug.Log("this has happend");
        float tank = 1f;
        FunctionPeriodic.Create(() =>
        {
            if (tank >= oxygenDepletion)
            {
                tank -= oxygenDepletion;
                oxygenBar.SetSize(tank);
                if (tank < .3f)
                {
                    if (((int)(tank * 100) * 100) % 3 == 0)
                    {
                        oxygenBar.SetColor(Color.blue);
                    }
                    else {
                        oxygenBar.SetColor(Color.white); }
                }
            }
        }, 0.2f);
        //oxygenBar.SetColor(Color.white);
    }


}
