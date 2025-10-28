using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
	public TextMeshProUGUI tmp;
	
	void Awake()
	{
		Time.timeScale = 1;
		tmp.text = "High Score : "+ PlayerPrefs.GetInt("highScore").ToString();
	}
	public void play()
	{
		SceneManager.LoadScene(1);
	}
	
}
