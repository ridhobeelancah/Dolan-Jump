// using UnityEngine;
// using System.Collections;

// public class PlatformSpawner : MonoBehaviour {

// 		///
// 	[SerializeField]private CameraFollow cameraFollow;	// 
// 	//++
// 	[SerializeField]private GameObject plaformPrefab;

// 	[SerializeField]private GameObject playerPrefab;

// 	public float platformYpalingAtas = 0;	//2

// 	void Start(){
// 		SpawnPlatform();
// 	}

// 	private void SpawnPlatform(){	//1
		
// 		float posY = -6f, posX = 0f;

// 		GameObject getPlayer = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);

// 		cameraFollow.playerGO = getPlayer.transform;

// 		for(int i = 0; i < 6; i++){
// 			posX = Random.Range(-2f,2f);
	

// 			Instantiate(plaformPrefab, new Vector3(posX, posY, 0f), Quaternion.identity);


// 			if(i <= 0){
// 				// Instantiate(playerPrefab, new Vector3(posX, posY + 1f, 0f), Quaternion.identity);
// 				getPlayer.transform.position = new Vector3(posX, posY + 1f, 0f);
// 			}

// 			Platform platformScript = plaformPrefab.GetComponent<Platform>();	// 2.2
// 			platformScript.platformSpawnerScript = this;	//2.3
// 			platformScript.cameraTransform = cameraFollow.gameObject.transform;	//2.4
// 			platformYpalingAtas = posY;	// 2.1

// 			posY += 2.2f;

// 		}
// 	}

// } //Class
