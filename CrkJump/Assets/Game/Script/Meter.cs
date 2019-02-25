using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meter : MonoBehaviour
{
    private bool meter_switch = true;
    private bool condition = true;

    [SerializeField] private MainCharacter _mainCharacter;
    public GameObject pointer;
    
    private float value = 0;

    void Start()
    {
        InvokeRepeating("meter_main",0,0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            meter_stop();
        }
    }

    void meter_main()
    {
//        Debug.Log(value);
        if (meter_switch)
        {
            
            if (value >= 100)
                condition = false;
            if (value <= 0)
                condition = true;


            if (condition)
                point_addvalue(1);
            else
                point_addvalue(-1);
        }
    }

    void point_addvalue(float value)
    {
        this.value += value;
        pointer.transform.position += new Vector3(value /25,0,0);
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