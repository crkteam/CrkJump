using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinButton : MonoBehaviour
{
    [SerializeField] private CharacterController CharacterController;
    [SerializeField] private GameObject Ink;
    [SerializeField] private Vector3 Position;
    [SerializeField] private String CharacterName;
    public int Type = 0;
    [SerializeField]private MusicController musicController;
    [Tooltip("Input command SetTemp/SaveData")]
    public string Command;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = new Vector3(0.3926872f, 0.3926872f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        int value = PlayerPrefs.GetInt(CharacterName);
      if (value == 2)
            Switch();
    }

    private void InkSwitch()
    {
        GameObject Beforeink = GameObject.Find("Ink(Clone)");
        Destroy(Beforeink);
    }

    private void PlayerSwitch()
    {
        GameObject ink = Instantiate(Ink);
        ink.transform.parent = gameObject.transform.parent;
        ink.transform.localPosition = gameObject.transform.localPosition;
        ink.transform.localPosition-=new Vector3(0.06462f,0f,0f);
        ink.transform.localScale=new Vector3(0.1780944f,0.1780944f,0.1780944f);
    }


    private void Switch()
    {
        switch (Command)
        {
            case "SetTemp":
                InkSwitch();
                PlayerSwitch();
                musicController.WritePlay();
                CharacterController.SetTemp(Type);
                break;
            case "SaveData":
                InkSwitch();
                CharacterController.SaveCharacterType();
                break;
        }
    }
}