using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

	[SerializeField] private GameObject game;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		game.transform.position -= new Vector3(0,.05f,0);
	}
}
