using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HancurkanPlatforms : MonoBehaviour {

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other){
		
		if(other.tag == "Platform"){
			Destroy(other.gameObject);
			print("Hancur");
		}

		if(other.tag == "Enemy"){
			Destroy(other.gameObject);
		}

		// if(other.tag == "Awan"){
		// 	Destroy(other.gameObject);
		// }

	}
}
