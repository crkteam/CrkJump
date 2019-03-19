using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private float Value, MaxSize, WaitSecond;
    [SerializeField] private GameObject[] ButtonGroup;
    [SerializeField] private GameObject OpenButton;

    [Tooltip("Input Open/Close to controll Menu.")]
    public string Command;

    public GameObject Menu;

    //Music
    private MusicController musicController;
    // Start is called before the first frame update
    void Start()
    {
        musicController = GameObject.Find("MusicController").GetComponent<MusicController>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {    
        gameObject.GetComponent<SpriteRenderer>().color=new Color(1f,1f,1f,1f);
        musicController.clickPlay();
        SwitchControll(Command);
    }

    private void SwitchControll(string command)
    {
        switch (command)
        {
            case "Open":

                StartCoroutine(OpenMenuObjecgt());

                break;
            case "Close":

                StartCoroutine(CloseMenuObjecgt());

                break;
        }
    }

    private IEnumerator OpenMenuObjecgt()
    {
        
        float temp = 0;
        while (true)
        {
            temp += Value;
            Menu.transform.localScale += new Vector3(Value, Value, 0);
            if (temp >= MaxSize)
            {
                ControllGroupButton(false);
                ControllButton(true);
          //      ControllButtonColor();
                Menu.transform.localScale = new Vector3(MaxSize, MaxSize, MaxSize);
                gameObject.SetActive(!gameObject.activeSelf);
                break;
            }

            yield return new WaitForSeconds(WaitSecond);
        }
    }

    private void ControllGroupButton(bool Switch)
    {
        foreach (var button in ButtonGroup)
        {
            button.SetActive(Switch);
        
        }
    }
    private void ControllButtonColor()
    {
       
            OpenButton.GetComponent<SpriteRenderer>().color=new Color(1f,1f,1f,1f);
        
            
    }
    private void ControllGroupButtonColor()
    {
        foreach (var button in ButtonGroup)
        {
            button.GetComponent<SpriteRenderer>().color=new Color(1f,1f,1f,1f);
        }
            
    }
    private void ControllButton(bool Switch)
    {
        OpenButton.SetActive(Switch);
    }

    private IEnumerator CloseMenuObjecgt()
    {
        float temp = MaxSize;
        while (true)
        {
            temp -= Value;
            Menu.transform.localScale -= new Vector3(Value, Value, 0);
            if (temp <= 0)
            {
                ControllGroupButton(true);
             //   ControllGroupButtonColor();
                gameObject.SetActive(!gameObject.activeSelf);
                Menu.transform.localScale = new Vector3(0f, 0f, 0f);
                break;
            }

            yield return new WaitForSeconds(WaitSecond);
        }
    }
}