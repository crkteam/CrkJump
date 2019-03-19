using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MainCharacter : MonoBehaviour
{
    [SerializeField] Meter _meter;
    [SerializeField] private GameController GC;
    private EffectController EC; 
    public CreateFloorController FC;
    
    private bool FalldownStatus = false;
    private SpriteRenderer spriteR;
    private Transform LastPlayerPosition;
    private int JumpScore = 0;

    //Music
    [FormerlySerializedAs("musicController")] [SerializeField] private MusicController MusicController;
    
    void Start()
    {

        
        EC = gameObject.GetComponent<EffectController>();
        LastPlayerPosition = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        JumpStatusControll(); // 有大問題
    

        if (Input.GetKeyDown(KeyCode.A))
        {
            

            jump_left();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            jump_right();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            jump_super_up();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!GC.GetPlaySwitch())
                GC.SetPlaySwitch();
  
            jump_up();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            jump_big_left();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            jump_big_right();
        }
    }


  

    private void SetJumpScore(int Score)
    {
        JumpScore = Score;
    }

    public Transform GetLastPlayerPosition()
    {
        return LastPlayerPosition;
    }

    private void JumpStatusControll()
    {
        if (gameObject.GetComponent<Rigidbody2D>().velocity.y > 0 && FalldownStatus)
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        else
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            FalldownStatus = true;
        }
    }

    public void jump_right()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2, 6);
        EC.PLayRightSwordAnimation();
        SetJumpScore(1);
        MusicController.jumpPlay();

    }

    public void jump_left()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 6);
        SetJumpScore(1);
        EC.PlayLeftSwordAnimation();
        MusicController.jumpPlay();
    }

    public void jump_big_left()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-4, 6);
        EC.PlayLeftDoubleSwordAnimation();
        SetJumpScore(1);
        MusicController.jumpPlay();
    }

    public void jump_big_right()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(4, 6);
        EC.PlayRightDoubleSwordAnimation();
        SetJumpScore(1);
        MusicController.jumpPlay();
    }

    public void jump_up()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 6);
        EC.PlayUpAnimation();
        SetJumpScore(1);
        MusicController.jumpPlay();
    }


    public void jump_super_up()
    {
     //   int Type=PlayerPrefs.GetInt("CharacterType");
       // MusicController.SuperJumpSkill(Type);
        MusicController.superJumpPlay();
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 17.4f);
        EC.PlaySuperUpAnimation();
        FC.SuperJumpFloorControll();
        GC.SetRate(10);
        SetJumpScore(10);
    }




    private void OnCollisionEnter2D(Collision2D other)
    {
        if (FalldownStatus && other.gameObject.tag.Equals("Board"))
        {
            LastPlayerPosition = other.transform;
            _meter.meter_start();
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f, 0f);
            FalldownStatus = false;
            EC.PlayJumpAnimatiion();
        }
    }
}