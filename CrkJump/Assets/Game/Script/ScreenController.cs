using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    [SerializeField] private GameObject LeftBound, RightBound,Meter,camera,music_name;
    // Start is called before the first frame update
    void Start()
    {
        if ((Screen.height / Screen.width) < 2) // 16:9
        {
            camera.GetComponent<Camera>().orthographicSize = 5.65f;
            LeftBound.transform.localPosition=new Vector3(-3.55f,0f,0f);
            RightBound.transform.localPosition=new Vector3(3.58f,0f,0f);
            Meter.transform.localScale=new Vector3(0.5837058f,0.5326316f,0f);
            Meter.transform.localPosition=new Vector3(0f,-4.69f,0f);
            music_name.transform.localPosition = new Vector3(1.2f,5.7f,0);
        }
        else
        {
            #if UNITY_ANDROID
                music_name.transform.localPosition = new Vector3(1.2f,6f,0);
            #endif
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
