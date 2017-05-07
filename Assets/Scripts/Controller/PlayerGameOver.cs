using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGameOver : MonoBehaviour {

	[SerializeField]private PlayerController playerController;

	[SerializeField]public GameObject gameOverPanel, pauseButton;

	[SerializeField]private Animator gameOverAnimator;




	void OnTriggerEnter2D(Collider2D target){
		
		if(target.tag == "Player"){
			print("Player Game Over");
			playerController.playerHealtSekarang = -1;
			StartCoroutine(ShowGameOverText());
		}
	}

	IEnumerator ShowGameOverText(){

		
		yield return new WaitForSeconds(.5f);
		gameOverPanel.SetActive(true);
		gameOverAnimator.Play("in");
		yield return new WaitForSeconds(.5f);
		pauseButton.SetActive (false);
		playerController.gameDiMulai = false;
	}


	public void PlayerDie(){

		if(playerController.playerHealtSekarang == 0){
			StartCoroutine(ShowGameOverText());
		}
	}
}
