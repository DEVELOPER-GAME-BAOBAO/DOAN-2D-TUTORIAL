using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;

    private bool levelCompleted = false;

    private void Start()
    {
        finishSound= GetComponent<AudioSource>();
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.name == "Player(Square)" && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompletelLevel", 2f);
            CompletelLevel();

		}
	}
    //level 
    private void CompletelLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
