using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour {

	[SerializeField]public GameObject pertanyaanPanel;
	[SerializeField]public Animator pertanyaanPanelAnim;

	//++
	[SerializeField]private PertanyaanController pertanyaanController; 
	[SerializeField]private PertanyaanLevel2 pertanyaanLevel2;
	[SerializeField]private PertanyaanLevel3 pertanyaanLevel3;
	[SerializeField]private PertanyaanLevel4 pertanyaanLevel4;
	[SerializeField]private PertanyaanLevel5 pertanyaanLevel5;

	//
	[SerializeField]private PlayerController playerController;

	[SerializeField]private PlayerGameOver playerGameOver;

	void OnTriggerEnter2D(Collider2D other){

		if(other.tag == "Player"){

			StartCoroutine(MenampilkanPertanyaanPanel());	
			StartCoroutine(MenampilkanPertanyaanPanel2());
			StartCoroutine(MenampilkanPertanyaanPanel3());
			StartCoroutine(MenampilkanPertanyaanPanel4());
			StartCoroutine(MenampilkanPertanyaanPanel5());
			Debug.Log("MenampilkanPertanyaanPanel");		
		}
	}

	IEnumerator MenampilkanPertanyaanPanel(){

		pertanyaanPanel.SetActive(true);
		pertanyaanController.PasangSoalDiPertanyaanPanel();
		yield return new WaitForSeconds(.5f);
		playerGameOver.pauseButton.SetActive (false);
		pertanyaanPanelAnim.Play("fadeIn");
		yield return new WaitForSeconds(1.5f);
		playerController.gameDiMulai = false;
	}

	IEnumerator MenampilkanPertanyaanPanel2(){

		pertanyaanPanel.SetActive(true);
		pertanyaanLevel2.PasangSoalDiPertanyaanPanel();
		yield return new WaitForSeconds(.5f);
		playerGameOver.pauseButton.SetActive (false);
		pertanyaanPanelAnim.Play("fadeIn");
		yield return new WaitForSeconds(1.5f);
		playerController.gameDiMulai = false;
	}

	IEnumerator MenampilkanPertanyaanPanel3(){

		pertanyaanPanel.SetActive(true);
		pertanyaanLevel3.PasangSoalDiPertanyaanPanel();
		yield return new WaitForSeconds(.5f);
		playerGameOver.pauseButton.SetActive (false);
		pertanyaanPanelAnim.Play("fadeIn");
		yield return new WaitForSeconds(1.5f);
		playerController.gameDiMulai = false;
	}

	IEnumerator MenampilkanPertanyaanPanel4(){

		pertanyaanPanel.SetActive(true);
		pertanyaanLevel4.PasangSoalDiPertanyaanPanel();
		yield return new WaitForSeconds(.5f);
		playerGameOver.pauseButton.SetActive (false);
		pertanyaanPanelAnim.Play("fadeIn");
		yield return new WaitForSeconds(1.5f);
		playerController.gameDiMulai = false;
	}

	IEnumerator MenampilkanPertanyaanPanel5(){

		pertanyaanPanel.SetActive(true);
		pertanyaanLevel5.PasangSoalDiPertanyaanPanel();
		yield return new WaitForSeconds(.5f);
		playerGameOver.pauseButton.SetActive (false);
		pertanyaanPanelAnim.Play("fadeIn");
		yield return new WaitForSeconds(1.5f);
		playerController.gameDiMulai = false;
	}
	
}
