using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    [SerializeField] private GameObject DeadMenu, Text,ResurrectText,DeadScoreText;
    [SerializeField] private GameController GC;
    private int hika, pee, kaka, saka, pikagolden;
    [Tooltip("Input NotResuurect.Close or Resurrect Command")] [SerializeField]
    private string Command;

    private MusicController musicController;
    // Start is called before the first frame update

    // Start is called before the first frame update
    void Start()
    {
        Text.GetComponent<MeshRenderer>().sortingLayerName = "UI";
        Text.GetComponent<MeshRenderer>().sortingOrder = 4;
        ResurrectText.GetComponent<MeshRenderer>().sortingLayerName = "UI";
        ResurrectText.GetComponent<MeshRenderer>().sortingOrder = 4;
        DeadScoreText.GetComponent<MeshRenderer>().sortingLayerName = "UI";
        DeadScoreText.GetComponent<MeshRenderer>().sortingOrder = 4;
        hika = PlayerPrefs.GetInt("Hika");
        pee = PlayerPrefs.GetInt("Pee");
        kaka = PlayerPrefs.GetInt("Kaka");
        saka = PlayerPrefs.GetInt("Saka");
        pikagolden = PlayerPrefs.GetInt("Pika-Golden");
        musicController = GameObject.Find("MusicController").GetComponent<MusicController>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetCommand(string command)
    {
        this.Command = command;
    }
    private void OnMouseDown()
    {
        if(Command!="NotResuurect")
        Switch();
    }

  
    public void SetScore()
    {
        int HighScore = PlayerPrefs.GetInt("HighScore");
        if (HighScore<GC.GetScore())
            PlayerPrefs.SetInt("HighScore",GC.GetScore());
        int CareerScore = PlayerPrefs.GetInt("CareerScore");
        CareerScore += GC.GetScore();
        PlayerPrefs.SetInt("CareerScore",CareerScore);
    }

    private void Switch()
    {
        DeadMenu.SetActive(false);
        switch (Command)
        {
            case "Close":
                musicController.clickPlay();
                SetScore();
                Characterunlock();
                SceneManager.LoadScene("SpriteScene");
                break;
            case "Resurrect":
                GC.Resurrect();
                break;
            case "NotResuurect":
                SceneManager.LoadScene("SpriteScene");
                break;
        }
    }
    private void Characterunlock()
    {
        int HighScore = PlayerPrefs.GetInt("HighScore");
        int CareerScore = PlayerPrefs.GetInt("CareerScore");
        if (HighScore >= 100&& hika==0)
        {
            PlayerPrefs.SetInt("Hika", 1);
        }
         if (HighScore >= 250&& pee==0)
        {
            PlayerPrefs.SetInt("Pee", 1);
        }
         if (CareerScore >= 5000 &&kaka==0)
        {
            PlayerPrefs.SetInt("Kaka", 1);
        }
         if (CareerScore >= 10000 && HighScore >= 350&& saka==0)
        {
            PlayerPrefs.SetInt("Saka", 1);
        }
         if (CareerScore >= 100000&& pikagolden==0)
        {
            PlayerPrefs.SetInt("Pika-Golden", 1);
        }
    }
}