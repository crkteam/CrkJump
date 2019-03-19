using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlineController : MonoBehaviour
{
    [SerializeField] private GameObject Player, ResurrectButton, ResurrectButtonText;
    private DoorSwitch DS;
    private GameController GC;
    private Vector3 DeadPosition;

    private Meter meter;
    
    //Music
    [SerializeField]private MusicController musicController;

    // Start is called before the first frame update
    void Start()
    {
        DS = GameObject.Find("Main Camera").GetComponent<DoorSwitch>();
        GC = GameObject.Find("Main Camera").GetComponent<GameController>();
        meter = GameObject.Find("Meter").GetComponent<Meter>();
        DeadPosition = new Vector3(-10f, 2f, 0);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.Equals(Player) && GC.GetPlaySwitch())


        {
            GC.SetJump(false);
            StartCoroutine(DS.DoorClose(0f));
            musicController.deathPlay();
            GC.OpenDeathMenu();
            if (!GC.GetResurrectTime())
            {
                ResurrectButtonText.GetComponent<TextMesh>().color = new Color(1f, 1f, 1f, .5f);
                ResurrectButton.GetComponent<DeathMenu>().SetCommand("NotResuurect");
                ResurrectButton.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
            }

            GC.SetButtonSwitch(false);
            Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Player.transform.localPosition = DeadPosition;
            // GC.SetPlaySwitch();
            meter.meter_start();
            Debug.Log("GameOver");
        }
    }
}