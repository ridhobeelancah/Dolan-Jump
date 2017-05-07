using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerController : MonoBehaviour {

	[SerializeField]private float kecepatanPlayer, kekuatanLompat = 1f;

	[SerializeField]public Animator playerAnim;

	public Rigidbody2D rigidPlayer;

	public GameObject playerGO;

	private SpriteRenderer spriteRendererPlayer;

	public bool dapatLompat;	//6

	public Image healtBar;	//7
	public int playerHealtSekarang, maxPlayerHealt;	//7

	//++
	[SerializeField]private PlayerGameOver playerGameOver;

	public bool gameDiMulai = false;

	public Transform posisiRahasia;

	public AudioClip soundLompat;

	void Awake(){

		rigidPlayer = GetComponent<Rigidbody2D>();	// 1
		spriteRendererPlayer = GetComponent<SpriteRenderer>();
		dapatLompat = true;
		playerHealtSekarang = maxPlayerHealt;	//7

		//Cuma Test
		//print(Screen.width);
	}

	void Update(){

		MulaiBermain();

		Ngeflip();
		PlayerHealt();	//8

		//
		FungsiRahasia();

	}

	void FixedUpdate () {	//5

			Movement();
			playerGameOver.PlayerDie();	//9

	}

	void MulaiBermain(){
		if(gameDiMulai == false){
			rigidPlayer.velocity = Vector2.zero;
			rigidPlayer.isKinematic = true;
		}else if(gameDiMulai == true){
			rigidPlayer.isKinematic = false;
		}
	}




	void OnTriggerEnter2D(Collider2D target){	// 3

		if(target.tag == "Platform"){

			// rigidPlayer.velocity = Vector2.zero;		// 4
			playerAnim.Play("landing");
			GetComponent<AudioSource>().PlayOneShot(soundLompat);
			rigidPlayer.velocity = new Vector2(rigidPlayer.velocity.x, 0f);
			rigidPlayer.AddForce(Vector2.up * kekuatanLompat );

		}

	}


	void OnTriggerExit2D(Collider2D other){

		if(other.tag == "Platform"){
			playerAnim.Play("jump");
		}

	}

	void OnCollisionEnter2D(Collision2D other){	//6

		if(other.gameObject.tag == "MinMin"){
			dapatLompat = false;
			print("Tertabrak");
			playerAnim.Play("terserang");
			playerHealtSekarang-=5;
		}

	}

	void OnCollisionExit2D(Collision2D other){	//6

		if(other.gameObject.tag == "MinMin"){
			dapatLompat = true;
			print("Tidak Tertabrak");
		}


	}


	void Movement(){

		#if UNITY_EDITOR
		rigidPlayer.AddForce(Vector2.right * Input.GetAxis("Horizontal") * kecepatanPlayer);	// 2
		float kecepatanMaxXX = Mathf.Clamp(rigidPlayer.velocity.x, -4f, 4f);
		rigidPlayer.velocity = new Vector2(kecepatanMaxXX, rigidPlayer.velocity.y);
		#endif

		rigidPlayer.AddForce(Vector2.right * DenganTouch() * kecepatanPlayer);	// 2
		float kecepatanMaxX = Mathf.Clamp(rigidPlayer.velocity.x, -4f, 4f);
		rigidPlayer.velocity = new Vector2(kecepatanMaxX, rigidPlayer.velocity.y);
	}

	void Ngeflip(){

		#if UNITY_EDITOR
		if(Input.GetAxisRaw("Horizontal") < 0){
			spriteRendererPlayer.flipX = true;
		}else if(Input.GetAxisRaw("Horizontal") > 0){
			spriteRendererPlayer.flipX = false;
		}
		#endif

		if(DenganTouch() < 0){
			spriteRendererPlayer.flipX = true;
		}else if(DenganTouch() > 0){
			spriteRendererPlayer.flipX = false;
		}
	}

	void PlayerHealt(){	//7

		healtBar.fillAmount = (float)playerHealtSekarang / maxPlayerHealt;
	}

	int DenganButton(){

		if(Input.GetMouseButtonDown(0)){

			if(Input.mousePosition.x < Screen.width / 2f){
				return -7;
			}else if(Input.mousePosition.x >= Screen.width /2f){
				return 7;
			}
		}
		return 0;
	}

	int DenganTouch(){

		if(Input.touchCount > 0){

			if(Input.GetTouch(0).position.x < Screen.width /2f){

				return -1;
			}else if(Input.GetTouch(0).position.x >= Screen.width /2f){
				return 1;
			}
		}
		return 0;

	}

	void FungsiRahasia(){

		if(Input.GetKeyDown(KeyCode.J) && Input.GetKeyDown(KeyCode.K)){

			playerGO.transform.position = new Vector3(posisiRahasia.position.x, posisiRahasia.position.y, 0f);
		}
	}



}	//PlayerController


/*
	Mathf.Clamp(float value,float min, float max);

 */
