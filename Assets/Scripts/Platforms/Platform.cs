using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {


	[SerializeField]private GameObject efekDebu;
	[SerializeField]private Animator efekDebuAnim;

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player"){
			
			efekDebu.SetActive(true);
			efekDebuAnim.Play("debu");
		}
	}

	/// <summary>
	/// Sent when another object leaves a trigger collider attached to
	/// this object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Player"){
			
			//efekDebu.SetActive(false);
			efekDebuAnim.Play("idle");
		}
	}

}
