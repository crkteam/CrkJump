using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScore : MonoBehaviour
{
    [SerializeField] private GameController GameController;
    private int Score=1;
    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.Find("Main Camera").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag.Equals("Player")&&Score==1&& GameController.GetPlaySwitch())
        {
            GameController.SetScore(Score);
            Score = 0;
        }
    }
}
