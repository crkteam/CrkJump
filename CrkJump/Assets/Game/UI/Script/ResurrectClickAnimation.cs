using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResurrectClickAnimation : MonoBehaviour
{
    [SerializeField] private GameController GC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if (GC.GetResurrectTime())
        {
            gameObject.GetComponent<SpriteRenderer>().color=new Color(.5f,.5f,.5f,1f);
        }
    }

    private void OnMouseExit()
    {
        if(GC.GetResurrectTime())
        gameObject.GetComponent<SpriteRenderer>().color=new Color(1f,1f,1f,1f);
    }
}
