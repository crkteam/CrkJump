using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meter : MonoBehaviour
{
    private bool meter_switch = true;
    private bool condition = true;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (meter_switch)
        {
            float value = gameObject.GetComponent<Slider>().value;

            if (value >= 100)
                condition = false;
            if (value <= 0)
                condition = true;

            if (condition)
                gameObject.GetComponent<Slider>().value += 1.5f;
            else
                gameObject.GetComponent<Slider>().value -= 1.5f;
        }
    }

    public void meter_stop()
    {
        meter_switch = false;
    }

    public void meter_start()
    {
        meter_switch = true;
    }
}