using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskripsiController : MonoBehaviour {

	[SerializeField]private GameObject deskripsiPanel;
	[SerializeField]private Animator deskripsiPanelAnim;

	[SerializeField]private PlayerController playerController;

	

	public void MulaiAtauLanjut(){

		StartCoroutine(LanjutKeGame());
	}

	
	IEnumerator LanjutKeGame(){

		deskripsiPanelAnim.Play("fadeOut");
		playerController.gameDiMulai = true;
		yield return new WaitForSeconds(.5f);
		deskripsiPanel.SetActive(false);

	}


}
