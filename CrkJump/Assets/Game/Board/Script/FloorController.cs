using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;
    [SerializeField] private GameController GC;
    [SerializeField] private GameObject player,FloorShade;
    private bool PlayerMove = false;
    private int Level;

    private bool MoveSwitch = false;

    [SerializeField] private MusicController MC;
    // Start is called before the first frame update
    void Start()
    {
        SetLevel();
        WhetherMove();
        MC = GameObject.Find("MusicController").GetComponent<MusicController>();
    }

    public void WhetherMove()
    {
        int random = Random.Range(0, 100);
        if (Level * 0.05>20)
        {
            if (random < 25)
            {
                SetMoveSwitch();
                SetSpeed();
            }
        }
        else
        {
              if (random < Level * 0.05f)
                    {
                        SetMoveSwitch();
                        SetSpeed();
                    }
        }
      
       
    }

    private void SetLevel()
    {
        player = GameObject.Find("Player");
        GC = GameObject.Find("Main Camera").GetComponent<GameController>();
        Level = GC.GetScore();
    }

    private void SetSpeed()
    {
        MoveSpeed = Level * Random.Range(0.00005f, 0.0003f) + Random.Range(0.01f, 0.03f);
        if (GetMoveSpeed() > 0.1)
            MoveSpeed = 0.1f;
        
    }

    public void SetMoveSwitch()
    {
        MoveSwitch = !MoveSwitch;
    }

    public float GetMoveSpeed()
    {
        return MoveSpeed;
    }
    public bool GetMoveSwitch()
    {
        return MoveSwitch;
    }

    private void MoveSpeedControll()
    {
        if (gameObject.transform.position.x > 2.1f)
        {
            MoveSpeed *= -1;
        }
        else if (gameObject.transform.position.x < -2.1)
        {
            MoveSpeed *= -1;
        }   
        gameObject.transform.position+=new Vector3(MoveSpeed,0f,0f);
    }

  

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GetMoveSwitch())
        {
            MoveSpeedControll();
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player")&& MoveSwitch)
            SetMoveSwitch();
        GameObject floorshade = Instantiate(FloorShade);
        floorshade.transform.parent = gameObject.transform;
        floorshade.transform.localPosition=new Vector3(0,0,0);
           GameObject fall=GameObject.Find("Gravel_effect");
        fall.transform.position = gameObject.transform.position;
        fall.GetComponent<ParticleSystem>().Play();
        Invoke("FallStop",0.5f);
        MC.Drop();
    }

    public void FallStop()
    {
        GameObject fall=GameObject.Find("Gravel_effect");
        fall.transform.position = gameObject.transform.position;
        fall.GetComponent<ParticleSystem>().Stop();
    }
}