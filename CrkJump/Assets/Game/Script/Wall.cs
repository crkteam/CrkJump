using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

	public int speed;

	[SerializeField] private MusicController musicController;
	public GameObject ColliderFall;
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
			Debug.Log("test");
			musicController.wallPlay();
			other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed,0);
			ColliderFall.GetComponent<ParticleSystem>().Play();
			ColliderFall.transform.position=new Vector3(ColliderFall.transform.position.x,other.transform.position.y,0);
			Invoke("StopParticle",.5f);
//			other.gameObject.GetComponent<MainCharacter>().SetOrientation(3);
		}
	}

	private void StopParticle()
	{
		ColliderFall.GetComponent<ParticleSystem>().Stop();
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player")
		{
			Debug.Log("test");
			musicController.wallPlay();
			other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed,0);
			ColliderFall.transform.position=new Vector3(ColliderFall.transform.position.x,other.transform.position.y,0);
			ColliderFall.GetComponent<ParticleSystem>().Play();
			Invoke("StopParticle",.2f);
//			other.gameObject.GetComponent<MainCharacter>().SetOrientation(3);
		}
	}
}
