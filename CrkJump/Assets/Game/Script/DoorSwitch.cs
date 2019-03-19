using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    public float Value, Seceond, Max;
    [SerializeField] private Transform LeftDoorPosition, RightDoorPosion;
    [SerializeField] private GameObject LeftDoor, RightDoor;

    [SerializeField] private GameController GC;
    // Start is called before the first frame update
    void Start()
    {
        LeftDoorPosition = LeftDoor.transform;
        RightDoorPosion = RightDoor.transform;
        StartCoroutine(DoorOpen(.5f));
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator DoorOpen(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        float temp = 0;
        while (temp <= Max)
        {
            temp += Value;
            LeftDoor.transform.localPosition -= new Vector3(Value, 0f, 0f);
            RightDoor.transform.localPosition += new Vector3(Value, 0f, 0f);
            yield return new WaitForSeconds(Seceond);
        }
    }

    public IEnumerator DoorClose(float WaitTime)
    {
        float temp = 0;
        while (temp <= Max)
        {
            temp += Value;
            LeftDoor.transform.localPosition += new Vector3(Value, 0f, 0f);
            RightDoor.transform.localPosition -= new Vector3(Value, 0f, 0f);
            yield return new WaitForSeconds(Seceond);
        }

        LeftDoor.transform.localPosition = LeftDoorPosition.localPosition;
        RightDoor.transform.localPosition = RightDoorPosion.localPosition;
    }

    public IEnumerator DoorCloseandOpen(float WaitTime)
    {
        StartCoroutine(DoorClose(0));
        StartCoroutine(DoorOpen(WaitTime));
yield break;
    }

    
}