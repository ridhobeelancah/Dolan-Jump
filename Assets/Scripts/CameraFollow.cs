using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform playerGO;

	private Vector3 ikutiPosisiPlayer;	

	private float posisiY;

	void Awake(){
		ikutiPosisiPlayer = new Vector3(transform.position.x, 1f, transform.position.z);

	}

	void Start(){
		posisiY = playerGO.position.y;
		transform.position = ikutiPosisiPlayer + (Vector3.up * posisiY);
	}

	void Update(){
		posisiY = Mathf.Max(posisiY, playerGO.position.y);
		transform.position = ikutiPosisiPlayer + (Vector3.up * posisiY);
	}
}
