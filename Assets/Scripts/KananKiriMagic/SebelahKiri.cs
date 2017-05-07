using UnityEngine;
using System.Collections;

public class SebelahKiri : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		
		if(other.tag == "Player"){
			other.gameObject.transform.position = new Vector3(3.1f, other.gameObject.transform.position.y, -5f);
		}

		if(other.tag == "Awan"){

		other.gameObject.transform.position = new Vector3(3.2f, other.gameObject.transform.position.y, 0f);

		}
	}
}
