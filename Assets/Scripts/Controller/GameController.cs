using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public LoadSceneMode loadMode = LoadSceneMode.Single;

	[SerializeField]private GameObject pausePanel, btnPause, gameSaved;

	[SerializeField]private Animator gameOverAnimator, pausePanelAnimator, gameSavedAnim;

	//++
	// [SerializeField]private PlayerController playerController;

	public void MainLagi(){

		StartCoroutine(MulaiLagi());

	}

	public void MainMenu(){

		StartCoroutine(KembaliKeMainMenu());

	}

	IEnumerator MulaiLagi(){

		// float fadeTime = GameObject.Find("GameController").GetComponent<Fading>().BeginFade(1);
		// yield return new WaitForSeconds(fadeTime);
		gameOverAnimator.Play("out");
		yield return new WaitForSeconds(.7f);
		SceneManager.LoadScene(Application.loadedLevel, loadMode);
	}

	IEnumerator KembaliKeMainMenu(){

		// float fadeTime = GameObject.Find("GameController").GetComponent<Fading>().BeginFade(1);
		// yield return new WaitForSeconds(fadeTime);
		gameOverAnimator.Play("out");
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene("MainMenu", loadMode);
	}


	public void PauseButton(){
		StartCoroutine(PauseGame());
	}

	IEnumerator PauseGame(){
		pausePanel.SetActive(true);
		btnPause.SetActive(false);
		pausePanelAnimator.Play("in");
		yield return new WaitForSeconds(1f);
		Time.timeScale = 0f;
	}

	public void ResumeButton(){
		StartCoroutine(ResumeGame());

	}
	
	IEnumerator ResumeGame(){
		Time.timeScale = 1f;
		pausePanelAnimator.Play("out");
		yield return new WaitForSeconds(1f);
		pausePanel.SetActive(false);
		btnPause.SetActive(true);
		gameSavedAnim.Play("saveOut");
		yield return new WaitForSeconds(1f);
		gameSaved.SetActive(false);
		
	}



	public void SaveGame(){
		//
		gameSaved.SetActive(true);
		PlayerPrefs.SetInt("simpanSceneSaatIni", Application.loadedLevel);
	}

	public void LoadAtauConinueGame(){
		
		Application.LoadLevel(PlayerPrefs.GetInt("simpanSceneSaatIni"));
	}

}
