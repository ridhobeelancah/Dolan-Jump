using UnityEngine;
using System.Collections;

public class PlatformYgMenghilang : MonoBehaviour {

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other){
		
		if(other.tag == "Player"){
			StartCoroutine(MenungguWaktuUntuMenghilang());
		}
	}

	IEnumerator MenungguWaktuUntuMenghilang(){
		yield return new WaitForSeconds(.4f);
		Destroy(this.gameObject);
	}
}
