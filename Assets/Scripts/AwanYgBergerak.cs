using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwanYgBergerak : MonoBehaviour {

	[SerializeField]private float kecepatanAwan;
	public GameObject objekAwan;
	
	// Update is called once per frame
	void Update () {
		
		
		objekAwan.transform.Translate(new Vector3(-kecepatanAwan, 0f, 0f) * Time.deltaTime);
	}
}
