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
    [SerializeField] private Animator meter_Effect; 
    void Start()
    {
        GC = GameObject.Find("Main Camera").GetComponent<GameController>();
        InvokeRepeating("PointMove",0f,0.001f); // 0.001
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
        pointer.transform.localPosition += new Vector3(value / 9f, 0, 0);

        
    }


    void meter_choose()
    {
        if (value > 85) //右
        {
            meter_Effect.SetTrigger("Big_Right");
            _mainCharacter.jump_big_right();
        }
        else if (68.1 < value && value <= 85) //右上
        {
            meter_Effect.SetTrigger("Right");
            _mainCharacter.jump_right();
        }
        else if (51.4 < value && value <= 68.1)
        {
            meter_Effect.SetTrigger("Right_Up");
            _mainCharacter.jump_up();
        }
        else if (48.8 < value && value <= 51.4)
        {
            meter_Effect.SetTrigger("Super");
            _mainCharacter.jump_super_up();
          
        }
        else if (32.1 < value && value <= 48.8)
        {
            meter_Effect.SetTrigger("Left_Up");
            _mainCharacter.jump_up();
        }
       
        else if (15.1 < value && value <= 32.1)
        {
            meter_Effect.SetTrigger("Left");
            _mainCharacter.jump_left();
        
        }
        else
        {
            meter_Effect.SetTrigger("Big_Left");
            _mainCharacter.jump_big_left();
        }

    

    }
// 112 0.015 1.884 0.1445 
//    void WriteCircle(int Type)
//    {
//       GameObject circle=Instantiate(InkCircle);
//        circle.transform.parent = Circle[Type].transform;
//        circle.transform.localPosition=new Vector3(0,0,0);
//        circle.transform.localScale=new Vector3(0.2181462f,0.2390641f,0.2076786f);
//        Destroy(circle,1f);
//
//    }
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