using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField] private GameController GC;

    public float MoveValueX;
    public float MaxValueX;
    public float MaxValueY; 
    public float MoveValueY;
    // Start is called before the first frame update
    void Start()
    {
      gameObject.transform.localPosition=new Vector3(0,-17.37f,0f);
    }

    public void StartBackground()
    {
        gameObject.transform.localPosition=new Vector3(Random.Range(-MaxValueX+0.2f,MaxValueX-0.2f),25.5f,0f);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (GC.GetPlaySwitch())
        {
            if (gameObject.transform.localPosition.x > MaxValueX|| gameObject.transform.localPosition.x<-MaxValueX)
            {
                MoveValueX *= -1;
            }

            if (gameObject.transform.localPosition.y <= MaxValueY) //-31.2
                MoveValueY = 0;
            gameObject.transform.localPosition-=new Vector3(MoveValueX,MoveValueY,0f);
        }
    }
}
