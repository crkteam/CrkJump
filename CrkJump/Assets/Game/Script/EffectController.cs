using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    [SerializeField] private GameObject player, BurstEffect, EffectControllObject, JumpEffect, SlashEffect,EffectContainter;
    [SerializeField] private GameObject[] CharacterAnimation, CharacerSuperBigAnimation;

    private IEnumerator JumpRotate(float rotate, int round)
    {
        float temp = 0;
        while (-360 * round < temp && temp < 360 * round)
        {
            player.transform.Rotate(0f, 0f, rotate);
            temp += rotate;
            yield return new WaitForSeconds(0.001f);
            if (round == 3&&temp==675f)
            {
                PlayCharacterSuperUpEndAniamtion();
            }
        }
    }

    public void PlayJumpAnimatiion()
    {
        GameObject JumpeffectLeft = Instantiate(JumpEffect);
        GameObject JumpeffectRight = Instantiate(JumpEffect);
        JumpeffectLeft.transform.Rotate(0f, -180f, 0f);
        JumpeffectLeft.transform.position = new Vector3(gameObject.transform.position.x + .25f,
            gameObject.transform.position.y - 0.4f, 0f);
        JumpeffectRight.transform.position = new Vector3(gameObject.transform.position.x - .25f,
            gameObject.transform.position.y - 0.4f, 0f);
        Destroy(JumpeffectLeft, 0.5f);
        Destroy(JumpeffectRight, 0.5f);
    }

    public void PlaySuperUpAnimation() //播放超級跳動畫
    {
        GameObject bursteffect = Instantiate(BurstEffect);
        bursteffect.transform.parent = GameObject.Find("Main Camera").transform;
        bursteffect.transform.localPosition = new Vector3(0f, 0f, 10f);
        Destroy(bursteffect, 2f);
        StartCoroutine(JumpRotate(15, 3));
        Invoke("CreateSlashEffect", .9f);
        PlayCharacterSuperUpAnimation();
        PlayJumpAnimatiion();
    }

    private void PlayCharacterSuperUpAnimation() //播放各個角色超級跳動畫 鄒
    {
        int Type = PlayerPrefs.GetInt("CharacterType");
        GameObject characteranimation = Instantiate(CharacterAnimation[Type]);
        characteranimation.transform.parent = EffectContainter.transform;
        characteranimation.transform.localPosition = new Vector3(0,0f, 0f);
        Destroy(characteranimation, 1.15f);
    }

    public void PlayCharacterSuperUpEndAniamtion() //播放各個角色超級跳動畫 marboy
    {
        int Type = PlayerPrefs.GetInt("CharacterType");
        GameObject characterendanimation = Instantiate(CharacerSuperBigAnimation[Type]);
        characterendanimation.transform.parent = player.transform;
        characterendanimation.transform.position = new Vector3(gameObject.transform.position.x,
        gameObject.transform.position.y, 0f);
        Destroy(characterendanimation, 3f);
    }

    public void CreateSlashEffect() //創造超級跳動畫
    {
        GameObject slasheffect = Instantiate(SlashEffect);
        slasheffect.transform.parent = GameObject.Find("Main Camera").transform;
        slasheffect.transform.localPosition = new Vector3(0f, 0f, 10f);
        slasheffect.GetComponent<ParticleSystem>().Play();
        Destroy(slasheffect, 0.5f);
    }

    public void PlayUpAnimation() //播放上跳動畫
    {
        EffectControllObject.GetComponent<Animator>().SetTrigger("Sword_Up");
        StartCoroutine(JumpRotate(-10, 1));
        PlayJumpAnimatiion();
    }

    public void PlayLeftSwordAnimation() //播放左跳動畫
    {
        EffectControllObject.GetComponent<Animator>().SetTrigger("Sword_R");
        StartCoroutine(JumpRotate(10, 1));
        PlayJumpAnimatiion();
    }

    public void PLayRightSwordAnimation() //播放右跳動畫
    {
        EffectControllObject.GetComponent<Animator>().SetTrigger("Sword_L");
        StartCoroutine(JumpRotate(-10, 1));
        PlayJumpAnimatiion();
    }

    public void PlayLeftDoubleSwordAnimation() //播放大左跳動畫
    {
        EffectControllObject.GetComponent<Animator>().SetTrigger("Sword_BigR");
        StartCoroutine(JumpRotate(-10, 1));
        PlayJumpAnimatiion();
    }

    public void PlayRightDoubleSwordAnimation() //播放大右跳動畫
    {
        EffectControllObject.GetComponent<Animator>().SetTrigger("Sword_BigL");
        StartCoroutine(JumpRotate(10, 1));
        PlayJumpAnimatiion();
    }
}