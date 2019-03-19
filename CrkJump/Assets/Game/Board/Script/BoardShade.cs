using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardShade : MonoBehaviour
{
    [SerializeField] private float Value;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,.5f);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale+=new Vector3(Value,Value*2f,0);
        gameObject.GetComponent<SpriteRenderer>().color-=new Color(0,0,0,0.1f);
    }
}
