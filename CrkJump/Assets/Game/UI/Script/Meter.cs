using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meter : MonoBehaviour
{
    private bool meter_switch = true;
    private bool condition = true;
    private GameController GC;
    [SerializeField] private GameObject BurstEffect, SwordEffect,InkCircle;
    [SerializeField] private GameObject[] Circle;
    [SerializeField] private MainCharacter _mainCharacter;
    public GameObject pointer;
    public float range;
    [Range(0, 100)] [SerializeField] private float value = 0;

    void Start()
    {
        GC = GameObject.Find("Main Camera").GetComponent<GameController>();
        InvokeRepeating("PointMove",0f,0.001f);
    }

    void PointMove()
    {
        if (meter_switch)
        {
            meter_main();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                meter_stop();
            }
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            _mainCharacter.jump_super_up();
         
        }
    }
    // Update is called once per frame


    void meter_main()
    {
        if (meter_switch)
        {
            if (value >= 99)    
                condition = false;
            if (value <= 0)
                condition = true;


            if (condition)
                point_addvalue(1f);
            else
                point_addvalue(-1f);
        }
    }

    void point_addvalue(float value)
    {
        this.value += value;
        pointer.transform.localPosition += new Vector3(value / 9.4f, 0, 0);
    }


    void meter_choose()
    {
        if (value > 85) //右
        {
            _mainCharacter.jump_big_right();
            WriteCircle(5);
        }
        else if (68.1 < value && value <= 85) //右上
        {
            _mainCharacter.jump_right();
            WriteCircle(4);
        }
        else if (51.4 < value && value <= 68.1)
        {
            WriteCircle(3);
            _mainCharacter.jump_up();
        }
        else if (48.8 < value && value <= 51.4)
        {
            _mainCharacter.jump_super_up();
          
        }
        else if (32.1 < value && value <= 48.8)
        {
            WriteCircle(2);
            _mainCharacter.jump_up();
        }
       
        else if (15.1 < value && value <= 32.1)
        {
            WriteCircle(1);
            _mainCharacter.jump_left();
        
        }
        else
        {
          WriteCircle(0);
            _mainCharacter.jump_big_left();
        }

    

    }

    void WriteCircle(int Type)
    {
       GameObject circle=Instantiate(InkCircle);
        circle.transform.parent = Circle[Type].transform;
        circle.transform.localPosition=new Vector3(0,0,0);
        circle.transform.localScale=new Vector3(0.2181462f,0.2390641f,0.2076786f);
        Destroy(circle,1f);

    }
    public void meter_stop()
    {
        if (meter_switch)
        {
            meter_choose();
            meter_switch = false;
        }
    }

    public void meter_start()
    {
        meter_switch = true;
    }
}