using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkickyPlatform : MonoBehaviour
{
	/*private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == "Player(Square)")
		{
			collision.gameObject.transform.SetParent(transform);
		}
	}
	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.name == "Player(Square)")
		{
			collision.gameObject.transform.SetParent(null);
		}
	}*/
	// Tương tác vật lý không va chạm với nhau 
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Player(Square)")
		{
			collision.gameObject.transform.SetParent(transform);
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Player(Square)")
		{
			collision.gameObject.transform.SetParent(null);
		}
	}
}
