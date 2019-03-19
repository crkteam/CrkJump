using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private GameObject Character,CharacterShade;
    [SerializeField] private GameObject[] Trail;
    [SerializeField] private Sprite[] CharacterSpriteType;
    [SerializeField] private Sprite[] Shade;
    private int CharacterType = 0;

    private int TempType;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LoadCharacter()
    {
        
        CharacterType = PlayerPrefs.GetInt("CharacterType");
        Character.GetComponent<SpriteRenderer>().sprite = CharacterSpriteType[CharacterType];
        GameObject trail = Instantiate(Trail[CharacterType]);
        trail.transform.parent = Character.transform;
        trail.transform.position = Character.transform.position;
        if (CharacterType >=4)
        {
            CharacterShade.GetComponent<SpriteRenderer>().sprite = Shade[CharacterType - 4];
        }
    }

    public void SetTemp(int Type)
    {
        
        TempType = Type;
        
    }

    public void SaveCharacterType()
    {
        PlayerPrefs.SetInt("CharacterType", TempType);
    }
}