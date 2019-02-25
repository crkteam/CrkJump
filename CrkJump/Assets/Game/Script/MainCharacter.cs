using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCharacter : MonoBehaviour
{
    [SerializeField]
    Sprite left, right;
    
    [SerializeField]
    Meter _meter;
    // Use this for initialization
    void Start()
    {
//        gameObject.GetComponent<Image>().sprite = left;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {   
            jump_left();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            jump_right();
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {   
            jump_big_left();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            jump_big_right();
        }

        gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;

        if (gameObject.GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = false;
        }
    }

    public void jump_right()
    {
        gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
        
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2, 6);
        // 這裡播放動畫
        gameObject.GetComponent<Animator>().SetTrigger("JumpR");
    }
    
    public void jump_left()
    {
        gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
        
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 6);
        // 這裡播放動畫
        gameObject.GetComponent<Animator>().SetTrigger("JumpL");
    }
    
    public void jump_big_left()
    {
        gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
        
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-4, 6);
        // 這裡播放動畫
        gameObject.GetComponent<Animator>().SetTrigger("JumpL");
    }
    
    public void jump_big_right()
    {
        gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
        
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(4, 6);
        // 這裡播放動畫
        gameObject.GetComponent<Animator>().SetTrigger("JumpR");
    }

    public void jump_up()
    {
        gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
        
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 6);
        
        gameObject.GetComponent<Animator>().SetTrigger("JumpL");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Board"))
        {
            _meter.meter_start();
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Board"))
        {
            _meter.meter_start();
        }
    }
}