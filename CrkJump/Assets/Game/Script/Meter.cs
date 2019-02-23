using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meter : MonoBehaviour
{
    private bool meter_switch = true;
    private bool condition = true;

    [SerializeField] private MainCharacter _mainCharacter;

    private float value;

    // Update is called once per frame
    void Update()
    {
        if (meter_switch)
        {
            value = gameObject.GetComponent<Slider>().value;

            if (value >= 100)
                condition = false;
            if (value <= 0)
                condition = true;

            if (condition)
                gameObject.GetComponent<Slider>().value += 5f;
            else
                gameObject.GetComponent<Slider>().value -= 5f;
        }
    }

    public void meter_stop()
    {
        meter_choose();
        meter_switch = false;
    }

    void meter_choose()
    {
        if (value > 72)
            _mainCharacter.jump_right();
        else if (value > 26)
        {
            if (value > 47 && value < 52)
                _mainCharacter.jump_up();
            else
                _mainCharacter.jump_up();
        }
        else
            _mainCharacter.jump_left();
    }

    public void meter_start()
    {
        meter_switch = true;
    }
}