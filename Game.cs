using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
	public Transform markUp;
	public Transform markDown;
	
	public GameObject enemy;
	Vector3 enemyPos;
	
	float rnd;
	
	float t = 2f;
	
	void Start()
	{
		enemyPos.x = markUp.position.x;
	}
	
	void Update()
	{
		t -= Time.deltaTime;
		if(t <= 0)
		{
			enemyPos.y = Random.Range( markUp.position.y, markDown.position.y);
			Instantiate(enemy,enemyPos,Quaternion.identity);
			t = 2f;
		}
	}
}
