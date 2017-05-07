using UnityEngine;
using System.Collections;

public class PlatformYgBergerak : MonoBehaviour {

	public int sebelahKanan;	//1
	public bool switchUp;		//2
	public float kecepatan, batasX, kecepatanMin, kecepatanMax;		//3
	public GameObject platform;	//4

	void Start(){

		sebelahKanan = Random.Range(0,2);	//5
		if(sebelahKanan == 1){				//5
			switchUp = true;				//5
		}else{		
			switchUp = false;				//5
		}
		kecepatan = Random.Range(kecepatanMin, kecepatanMax);	//5
	}

	void Update () {
		
		FungsiBerpindah();	//7
	}

	void FungsiBerpindah(){		//6
		
		if(platform.transform.position.x >= batasX && switchUp == true){

			switchUp = false;
			sebelahKanan = 0;
		}else if(platform.transform.position.x <= -batasX & switchUp == false){

			switchUp = true;
			sebelahKanan = 1;
		}else{

			if(sebelahKanan == 0){

				platform.transform.Translate(new Vector3(-kecepatan, 0f, 0f) * Time.deltaTime);
			}else if(sebelahKanan == 1){
				platform.transform.Translate(new Vector3(kecepatan, 0f, 0f) * Time.deltaTime);
			}
		}

		//kecepatan = Random.Range(kecepatanMin, kecepatanMax);
	}

} //PlatformYgBergerak
