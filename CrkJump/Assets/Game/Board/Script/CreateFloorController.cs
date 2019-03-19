using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFloorController : MonoBehaviour
{
    [SerializeField] private GameObject Floor, Group;
    [SerializeField] private Transform Player;
    [SerializeField] private int MaxFloorNumber = 20;
    [SerializeField] private int MinFloorNumber = 11;
    [SerializeField] private float SpaceY;
    [SerializeField] private float InitPositionY = -3f;
    private List<Transform> FloorGroup;

    private float ScreenAdjust=0f;
    // Use this for initialization
    void Start()
    {
        if ((Screen.height / Screen.width) < 2)
        {
            ScreenAdjust = 0.2f;
        }
        FloorGroup = new List<Transform>();
     //   FloorInitialize();
    }

    // Update is called once per frame

    void Update()
    {
        MixFloorNumberControll();
    }


    private float GeneratePositionY()    //Y生成
    {
        if (FloorGroup.Count == 0)
        {
            
            return InitPositionY;
            
        }
        int TopFloor = FloorGroup.Count - 1;
        float newY = FloorGroup[TopFloor].position.y + SpaceY;
        return newY;
    }


    private float GeneratePositionX()    //X生成
    {
      
        float newX = Random.Range(-2f-ScreenAdjust, 2f+ScreenAdjust);
          if (FloorGroup.Count == 0)
                {
                    Player.transform.position = new Vector3(newX, -2.3f, 0f);
                }
        return newX;
    }

    private void MixFloorNumberControll()    //最低地板數量控制
    {
        int LowestCount = 0;
        foreach (var Floor in FloorGroup)
        {
            if (Floor.transform.position.y < Player.transform.position.y)
            {
                LowestCount++;
            }
        }

        if (LowestCount > MinFloorNumber)
        {
            GenerateFloor();
            FloorCountControll();
        }
    }

    private void FloorCountControll()    //地板數量控制
    {
        if (FloorGroup.Count > MaxFloorNumber)
        {
            Destroy(FloorGroup[0].gameObject);
            FloorGroup.RemoveAt(0);
        }
    }

    public void FloorInitialize()    //地板初始生成
    {
        for (int i = 1; i < MaxFloorNumber; i++)
        {
            GenerateFloor();
        }
    }

    public void SuperJumpFloorControll()    //大跳控制位置
    {
        int LowestCount = 0;
        foreach (var Floor in FloorGroup)
        {
            if (Floor.transform.position.y < Player.transform.position.y)
            {
                LowestCount++;
            }
        }

        FloorGroup[LowestCount + 9].gameObject.transform.position = new Vector3(
            Player.transform.position.x + Random.Range(-0.4f, 0.4f),
            FloorGroup[LowestCount + 9].gameObject.transform.position.y, 0);
        if (FloorGroup[LowestCount + 9].gameObject.GetComponent<FloorController>().GetMoveSwitch())
        {
            FloorGroup[LowestCount + 9].gameObject.GetComponent<FloorController>().SetMoveSwitch();
        }
    }

    private void GenerateFloor() //生成地板
    {
        GameObject newFloor = Instantiate(Floor);
        newFloor.transform.position = new Vector3(GeneratePositionX(), GeneratePositionY(), 0f);
        newFloor.transform.parent = Group.transform;
        FloorGroup.Add(newFloor.transform);
    }
}