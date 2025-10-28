using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public Rigidbody2D rb;
	public float speed;
	
	Vector2 movement;
	bool isJump = false;
	
	void Awake()
	{
		Time.timeScale = 1;
		PlayerPrefs.SetInt("nowScore", 0);
	}
	
	public void touched()
	{
		isJump = true;
	}
	
	void FixedUpdate()
	{
		movement.y = speed;
		if(isJump)
		{	
			rb.velocity = movement;
			isJump = false;
		}
	}
	
	void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if(collisionInfo.gameObject.tag == "Enemy")
		{
			Time.timeScale = 0;
			StartCoroutine(waitEnd());
		}
	}
	
	IEnumerator waitEnd()
	{
		yield return new WaitForSecondsRealtime(1f);
		SceneManager.LoadScene(0);
	}
}
