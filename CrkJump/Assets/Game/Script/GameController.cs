using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

	[SerializeField] private GameObject game;
	
	// Use this for initialization
	void Start () {
		InvokeRepeating("falldown",0,0.01f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void falldown()
	{
		game.transform.position -= new Vector3(0,.015f,0);
	}
}
