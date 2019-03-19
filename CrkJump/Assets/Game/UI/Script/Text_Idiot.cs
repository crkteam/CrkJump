using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Idiot : MonoBehaviour
{
    [SerializeField] private String sortLayer;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().sortingLayerName = sortLayer;
    }
}
