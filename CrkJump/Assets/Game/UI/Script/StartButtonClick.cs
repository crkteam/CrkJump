using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonClick : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu, MeterMenu, StartButton;
    [SerializeField] private CharacterController CharacterController;
    [SerializeField] private GameController GC;
    [SerializeField] private GameObject[] ButtonGroup;
    [SerializeField] private DoorSwitch DS;
    [SerializeField] private float MoveValue, TimeValue;

    private bool startb = false;

    // Music
    [SerializeField] private MusicController musicController;

    private void Start()
    {
        Invoke("SetStartb", 1.3f);
    }

    private void SetStartb()
    {
        startb = true;
    }

    private void OnMouseDown()
    {
        if (startb)
        {
            startb = false;
            musicController.gameStart();
            musicController.taikoPlay();
            CharacterController.LoadCharacter();
            StartCoroutine(DS.DoorCloseandOpen(1f));
            StartCoroutine(GC.GameWait(.3f));
            StartCoroutine(MoveUI(.3f));
            CloseButtonGroup();
        }
    }


    private void CloseButtonGroup()
    {
        foreach (var button in ButtonGroup)
        {
            button.SetActive(false);
        }
    }

    private IEnumerator MoveUI(float WaitTime)
    {
        yield return new WaitForSeconds(.3f);
        MainMenu.transform.localPosition = new Vector3(0f, 11.5f, 0f);
        MeterMenu.transform.localPosition = new Vector3(0f, 2f, 0f);
        StartButton.SetActive(false);
    }
}