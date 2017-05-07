using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {


	[SerializeField]private PlayerController playerController;



	/// <summary>
	/// Sent when an incoming collider makes contact with this object's
	/// collider (2D physics only).
	/// </summary>
	/// <param name="other">The Collision2D data associated with this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player"){
			playerController.playerHealtSekarang -= 10;
			StartCoroutine(Menyerang());
		}
	}

	IEnumerator Menyerang(){

		yield return new WaitForSeconds(.2f);
		playerController.playerAnim.Play("terserang");
	}

	

}
