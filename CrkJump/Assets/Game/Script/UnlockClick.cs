using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockClick : MonoBehaviour
{
    [SerializeField] private string CharacterName;

    [SerializeField] private GameObject AnimationObject,CharacterObject;
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
        int Value = PlayerPrefs.GetInt(CharacterName);
       
        if (Value == 1)
        {
            GameObject.Find("MusicController").GetComponent<MusicController>().unlockPlay();
            GameObject newOjbject = Instantiate(AnimationObject);
            newOjbject.transform.parent = gameObject.transform.parent.transform;
            newOjbject.transform.localPosition = gameObject.transform.localPosition;
            gameObject.transform.localScale=new Vector3(0,0,0);
            Destroy(gameObject,4);
            Destroy(newOjbject,3.6f);
            Invoke("OriginSize", 3.6f);
            PlayerPrefs.SetInt(CharacterName,2);    
        }
    }

    private void OriginSize()
    {
        CharacterObject.transform.localScale=new Vector3(0.3926872f,0.3926872f,0);
    }
}
