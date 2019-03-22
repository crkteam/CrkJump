using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject Game, Camera, Player, Background, ScoreSpecial, DeathMenu, DeathScoreText, Jump;
    [SerializeField] private SpriteRenderer king;
    [SerializeField] private CreateFloorController CFC;
    [SerializeField] private bool ButtonSwitch;
    [SerializeField] private TextMesh ScoreUI;
    [SerializeField] private float DownSpeed = .5f;
    [SerializeField] private float GrowthCoefficient = 0.0001f;
    [SerializeField] private BackgroundMove BM;
    private DoorSwitch DS;
    private int Score = 0;
    private bool PlaySwitch = false, ResurrectTime = true;

    private int Rate = 1;
    private int highScore,highScroe_type = 0; // type 0:一般 1:超越歷史
    

    //Music
    [SerializeField] private MusicController musicController;

    void Start()
    {
        //   PlayerPrefs.SetInt("HighScore",0);
        // PlayerPrefs.SetInt("CareerScore",0);

        //0代表未解鎖 1代表可解鎖 2代表可使用
        //  Characterunlock();
        //    PlayerPrefs.SetInt("Pika", 2);
//      PlayerPrefs.SetInt("Hika", 0);
//     PlayerPrefs.SetInt("Pee", 0);
//       PlayerPrefs.SetInt("Kaka", 0);
//       PlayerPrefs.SetInt("Saka", 0);
//       PlayerPrefs.SetInt("Pika-Golden",0);

        if (PlayerPrefs.GetInt("init") == 0)
        {
            Init();
        }

        musicController.openMusic();
    }

    void Init()
    {
        PlayerPrefs.SetInt("CharacterType", 0);
        PlayerPrefs.SetInt("init", 1);
        PlayerPrefs.SetInt("Pika", 2);
        PlayerPrefs.SetInt("Hika", 0);
        PlayerPrefs.SetInt("Pee", 0);
        PlayerPrefs.SetInt("Kaka", 0);
        PlayerPrefs.SetInt("Saka", 0);
        PlayerPrefs.SetInt("Pika-Golden", 0);
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.SetInt("CareerScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            Resurrect();
    }

    public IEnumerator GameWait(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        StartGame();
    }

    public void StartGame()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        CFC.FloorInitialize();
        BM.StartBackground();
        SetButtonSwitch(true);
        SetScoreUI();
        SetJump(true);
    }

    public void SetJump(bool Switch)
    {
        Jump.SetActive(Switch);
    }

    public bool GetResurrectTime()
    {
        return ResurrectTime;
    }

    public void OpenDeathMenu()
    {
        DeathMenu.SetActive(true);
        ShowScore();
    }

    public void ShowScore()
    {
        if (highScroe_type == 0)
        {
            DeathScoreText.GetComponent<TextMesh>().text = GetScore().ToString();
        }
        else
        {
            DeathScoreText.GetComponent<TextMesh>().text = highScore.ToString();
            
        }


    }

    public void SetButtonSwitch(bool Switch)
    {
        ButtonSwitch = Switch;
    }

    public bool GetButtonSwitch()
    {
        return ButtonSwitch;
    }

    public void SetPlaySwitch()
    {
        PlaySwitch = !PlaySwitch;
    }

    public void SetRate(int rate)
    {
        Rate = rate;
    }

    private int GetRate()
    {
        return Rate;
    }

    public bool GetPlaySwitch()
    {
        return PlaySwitch;
    }

    private void CameraControll()
    {
        if (Player.transform.position.y > Camera.transform.position.y)
        {
            Camera.transform.position = new Vector3(Camera.transform.position.x, Player.transform.position.y, -10f);
            Background.transform.position = new Vector3(Camera.transform.position.x, Player.transform.position.y, 0f);
        }
    }

    public void Resurrect() //復活
    {
        if (ResurrectTime)
        {
            SetJump(true);
            musicController.revivalPlay();
            SetButtonSwitch(true);
            DS = gameObject.GetComponent<DoorSwitch>();
            StartCoroutine(DS.DoorOpen(.5f));
            Transform ResurrectPosition = Player.GetComponent<MainCharacter>().GetLastPlayerPosition();
            Player.transform.position = new Vector3(ResurrectPosition.transform.position.x,
                ResurrectPosition.transform.position.y + 1f, 0f);
            Camera.transform.position = new Vector3(0, Player.transform.position.y + 1.5f, -10f);
            Background.transform.position =
                new Vector3(Camera.transform.position.x, Player.transform.position.y + 1.5f, 0f);
            SetPlaySwitch();
            ResurrectTime = false;
        }
    }

    public void SetScore(int Score)
    {
        this.Score += Score * GetRate();
        SetRate(1);
        SetScoreUI();
        SetDownSpeed();
        
        // Over HighScore FeedBack
        if (this.Score > highScore)
        {
            // addKing
            if (king.enabled == false)
            {
                king.enabled = true;
                highScroe_type = 1;
            }
        }

        GameObject scorespecial = Instantiate(ScoreSpecial);
        scorespecial.transform.parent = GameObject.Find("PointManager").transform;
        scorespecial.GetComponent<TextMesh>().text = ScoreUI.text;
    }

    public int GetScore()
    {
        return Score;
    }

    private void SetDownSpeed()
    {
        if (DownSpeed < 1.5)
            DownSpeed = DownSpeed + Score * GrowthCoefficient;
    }

    private void SetScoreUI() //更改分數UI
    {
        ScoreUI.GetComponent<TextMesh>().text = Score.ToString();
    }

    private void FixedUpdate() //穩定下降
    {
        if (PlaySwitch)
        {
            Game.transform.position -= new Vector3(0, Time.deltaTime * DownSpeed);
            CameraControll();
        }
    }
}