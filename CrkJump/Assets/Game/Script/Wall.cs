using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

	public int speed;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name == "Player")
		{
			other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed,0);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player")
		{
			other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed,0);
		}
	}
}
