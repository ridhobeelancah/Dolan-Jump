using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagement : MonoBehaviour {

	public LoadSceneMode loadMode = LoadSceneMode.Single;

	[SerializeField]private GameObject creditsPanel, howToPanel, playerIdle;
	[SerializeField]private Animator creditsPanelAnim, howToPanelAnim;

	public void PlayGame(){

		SceneManager.LoadScene( "level1", loadMode);

	}

	public void PlayCreditsIn(){

		StartCoroutine(CreditsIn());
	}

	IEnumerator CreditsIn(){
		yield return new WaitForSeconds(.5f);
		creditsPanel.SetActive(true);
		creditsPanelAnim.Play("fadeIn");
	}

	public void BackKeMenuDariCredits(){
		StartCoroutine(CreditsOut());
	}

	IEnumerator CreditsOut(){
		
		creditsPanelAnim.Play("Credits");
		yield return new WaitForSeconds(1f);
		creditsPanel.SetActive(false);
	}

	public void PlayHowToIn(){

		StartCoroutine(HowToIn());
	}

	IEnumerator HowToIn(){
		yield return new WaitForSeconds(.5f);
		howToPanel.SetActive(true);
		howToPanelAnim.Play("fadeIn");
		yield return new WaitForSeconds(.4f);
		playerIdle.SetActive(false);
	}

	public void BackKeMenuDariHowTo(){
		StartCoroutine(HowToOut());
	}

	IEnumerator HowToOut(){
		howToPanelAnim.Play("fadeOut");
		playerIdle.SetActive(true);
		yield return new WaitForSeconds(1f);
		howToPanel.SetActive(false);
		
	}

	public void ExitGame(){
		Application.Quit();
	}


}
