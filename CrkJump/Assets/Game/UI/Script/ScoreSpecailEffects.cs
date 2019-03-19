using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSpecailEffects : MonoBehaviour
{
    [SerializeField] private GameObject ScoreUI;
    // Start is called before the first frame update
    void Start()
    {
        ScoreUI=GameObject.Find("ScorePoint");
        Destroy(gameObject,2f);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = ScoreUI.transform.position;
        gameObject.transform.localScale+=new Vector3(.1f,.1f,.1f);
        gameObject.GetComponent<TextMesh>().color-=new Color(0f,0f,0f,0.05f);
    }

}
