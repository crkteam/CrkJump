using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MusicController : MonoBehaviour
{
    [SerializeField] AudioSource lobby, game, death, jump, superJump, taiko, click,Skill,Write,drop,wall,surpass,taiko2;
    [SerializeField] private AudioClip []JumpSkill;
    [SerializeField] AudioClip music_type1, music_type2, music_type3;
    [SerializeField] private String name_type1, name_type2, name_type3;
    [SerializeField] private TextMesh music_name;
    
    public void openMusic()
    {
        Invoke("openMusicPlay", 1);
    }

    private void openMusicPlay()
    {
        lobby.Play();
    }

    public void SuperJumpSkill(int Type)
    {
        AudioClip buffer = JumpSkill[Type];
        Skill.clip =buffer;
        Skill.Play();
    }
    
    public void gameStart()
    {
        lobby.Stop();
        String buffer_name;
        float value = Random.value;
        AudioClip buffer = null;
        
        if (value <= 0.4)
        {
            buffer = music_type1;
            buffer_name = name_type1;
        }
        else if (value <= 0.7)
        {
            buffer = music_type2;
            buffer_name = name_type2;
        }
        else
        {
            buffer = music_type3;
            buffer_name = name_type3;
        }

        music_name.text = buffer_name;
        game.clip = buffer;
        game.Play();
    }

    public void deathPlay()
    {
        death.Play();
        game.volume = 0.2f;
    }

    public void jumpPlay()
    {
        jump.Play();
    }

    public void superJumpPlay()
    {
        superJump.Play();
    }

    public void revivalPlay()
    {
        game.volume = 1;
    }

    public void taikoPlay()
    {
        taiko.Play();
    }

    public void clickPlay()
    {
        click.Play();
    }

    public void WritePlay()
    {
        Write.Play();
    }

    public void Drop()
    {
        drop.Play();
    }

    public void wallPlay()
    {
        wall.Play();
    }

    public void wallVolumeUp()
    {
        wall.volume = 1;
    }

    public void wallVolumeDown()
    {
        wall.volume = 0;
    }

    public void surpassPlay()
    {
        surpass.Play();
    }

    public void taiko2Play()
    {
        taiko2.Play();
    }
}
