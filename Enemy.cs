using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	Vector3 movment;
	float timeDestroy = 4;
	
	void Start()
	{
		movment = transform.position;
	}
    void Update()
	{
		movment.x -= 2 * Time.deltaTime;
		
		transform.position = movment;
		
		timeDestroy -= Time.deltaTime;
		if(timeDestroy <= 0)
		{
			Destroy(gameObject);
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			PlayerPrefs.SetInt("nowScore", PlayerPrefs.GetInt("nowScore")+1);
		}
	}
}
