using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Jump : MonoBehaviour
{

    [SerializeField] private Meter meter;
    [SerializeField] private GameController GC;
    private void OnMouseDown()
    {
        if (GC.GetButtonSwitch())
        {
            if (!GC.GetPlaySwitch())
                GC.SetPlaySwitch();
            meter.meter_stop();
           
        }
    }
    
    
}
 