using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashManagement : MonoBehaviour {

	public bool Activated;
	public float DelayTime;
	public string nextScene;

	IEnumerator ExecuteSplashScreen(){
		if(Activated){
			yield return new WaitForSeconds(DelayTime);
			Application.LoadLevel(nextScene);
		}
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(ExecuteSplashScreen());

	}

	public void KeMainMenu(){
		Application.LoadLevel("MainMenu");
	}
}
