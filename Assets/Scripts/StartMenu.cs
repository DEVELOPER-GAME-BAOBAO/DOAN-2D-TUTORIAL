using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
	public void StartGame()
	{
		//STRAT Game
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
