using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCharacter : MonoBehaviour
{
    [SerializeField]
    Sprite left, right;
    
    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Image>().sprite = left;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {   
            jump_left();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            jump_right();
        }

        gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    void jump_right()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(500, 1500);
        // 這裡播放動畫
        gameObject.GetComponent<Animator>().SetTrigger("JumpR");

//        gameObject.GetComponent<Image>().overrideSprite = right;
    }
    
    void jump_left()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-500, 1500);
        // 這裡播放動畫
        gameObject.GetComponent<Animator>().SetTrigger("JumpL");
        
//        gameObject.GetComponent<Image>().overrideSprite = left;

    }
}