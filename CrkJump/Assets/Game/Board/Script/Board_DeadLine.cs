using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board_DeadLine : MonoBehaviour
{

	[SerializeField] private GameObject t;

	[SerializeField] private GameObject group;

	// Use this for initialization
	void Start () {
//		create();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Sensor")
		{
			Debug.Log("test");
			Destroy(other.gameObject.transform.parent.gameObject);
			create();
		}
	}

	void create()
	{
		GameObject g = Instantiate(t);
		g.transform.localPosition = new Vector3(0,41.5f,0);
		g.transform.parent = group.transform;
	}
}
