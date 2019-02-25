using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Jump : MonoBehaviour
{

    [SerializeField] private Meter meter;
    
    private void OnMouseDown()
    {
        meter.meter_stop();
    }
    
    
}
