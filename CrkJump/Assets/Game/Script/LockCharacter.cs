using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCharacter : MonoBehaviour
{
    [SerializeField] private String CharacterName;
    [Multiline(3)] [SerializeField] private string LockText;
    [SerializeField] private Vector3 newPosition;
    [SerializeField] private GameObject Locker;
    [SerializeField] private Sprite Email;
    [SerializeField] private GameObject Text;
    // Start is called before the first frame update
    void Start()
    {
        int Lock = PlayerPrefs.GetInt(CharacterName);
        if (Lock == 1) //click to unlock
        {
            Locker.GetComponent<SpriteRenderer>().sprite = Email;
            gameObject.transform.localScale=new Vector3(0,0,0);
        }
        else if (Lock == 2) // unlock
        {
            gameObject.transform.localScale=new Vector3(0.3926872f,0.3926872f,0);
            Destroy(Locker);
        }
        else //lock
        {
            Text.transform.localPosition = newPosition;
            Text.GetComponent<TextMesh>().text = (LockText).ToString();
            Text.GetComponent<TextMesh>().fontSize = 32;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}