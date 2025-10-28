using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
	public TextMeshProUGUI tmp;
    void Update()
    {
	    tmp.text = PlayerPrefs.GetInt("nowScore").ToString();
	    if(PlayerPrefs.GetInt("highScore") < PlayerPrefs.GetInt("nowScore"))
	    {
	    	PlayerPrefs.SetInt("highScore", PlayerPrefs.GetInt("nowScore"));
	    }
    }
}
