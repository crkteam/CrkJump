using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private float Value, MaxSize, WaitSecond;
    [SerializeField] private int Type;

    public GameObject Menu;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnMouseDown()
    {
        switch (Type)
        {
            case 1:
                StartCoroutine(OpenMenuObjecgt());
                break;

            case 2:
                StartCoroutine(CloseMenuObjecgt());
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator OpenMenuObjecgt()
    {
        float temp = 0;
        while (true)
        {
            temp += Value;
            Menu.transform.localScale += new Vector3(Value, Value, 0);
            if (temp >= MaxSize)
            {
                Menu.transform.localScale = new Vector3(MaxSize, MaxSize, MaxSize);
                break;
            }

            yield return new WaitForSeconds(WaitSecond);
        }
    }

    private IEnumerator CloseMenuObjecgt()
    {
        float temp = MaxSize;
        while (true)
        {
            temp -= Value;
            Menu.transform.localScale -= new Vector3(Value, Value, 0);
            if (temp <= 0)
            {
                Menu.transform.localScale = new Vector3(0f, 0f, 0f);
                break;
            }

            yield return new WaitForSeconds(WaitSecond);
        }
    }
}