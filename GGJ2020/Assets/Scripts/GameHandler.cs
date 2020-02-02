using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class GameHandler : MonoBehaviour
{
    [SerializeField] private OxygenBar oxygenBar;

    private void Start()
    {
        float tank = 1f;
        FunctionPeriodic.Create(() =>
        {
            if (tank > .01f)
            {
                tank -= 0.01f;
                oxygenBar.SetSize(tank);

                if (tank < .3f)
                {
                    if ((int)(tank * 100f) % 2 == 0)
                    {
                        oxygenBar.SetColor(Color.white);
                    }

                    else
                    {
                        oxygenBar.SetColor(Color.blue);
                    } }
                }
            }, 0.3f);
    }



}
