using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CareerMenu : MonoBehaviour
{
    [SerializeField]private GameObject[] Text;
    private int HighScore, CareerScore;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var text in Text)
        {
            text.GetComponent<MeshRenderer>().sortingOrder = 2;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        HighScore = PlayerPrefs.GetInt("HighScore");
        CareerScore = PlayerPrefs.GetInt("CareerScore");
        Text[0].GetComponent<TextMesh>().text =HighScore.ToString();
        Text[1].GetComponent<TextMesh>().text =CareerScore.ToString();

    }
}
