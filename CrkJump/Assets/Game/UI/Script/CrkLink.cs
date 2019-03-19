using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrkLink : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        WWW Link = new WWW ("https://www.facebook.com/CrkTeam-1996298847156168/");
        Application.OpenURL (Link.url);
    }
}
