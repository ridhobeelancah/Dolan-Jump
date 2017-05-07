using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PertanyaanController : MonoBehaviour {

	
	[SerializeField]private Text soalText, hasilJawaban;

	[SerializeField]private GameObject hasilPertanyaanPanel, levelSelanjutnyaButton;
	[SerializeField]private Animator hasilPertanyaanPanelAnim;

	public LoadSceneMode loadMode = LoadSceneMode.Single;

	public int soal1 = 1, soalSelanjutnya = 4, soalSebenarnya;

	//public bool jawabanBenar, jawabanSalah;

	public Button btnBenar, btnSalah;

	//++
	[SerializeField]private FinishController finishController;


	void Start(){
			soalSebenarnya = Random.Range(soal1, soalSelanjutnya);
			print("Soal Sebenarnya = " +soalSebenarnya);
	}

	public void PasangSoalDiPertanyaanPanel(){

		switch(soalSebenarnya){

			case 1:	
				soalText.text = "Benar atau salah bahwa Kota Malang memiliki dua Alun-alun ?";
				btnBenar.onClick.AddListener(() => JawabanBenar());
				btnSalah.onClick.AddListener(() => JawabanSalah());
				break;
			case 2:
				soalText.text = "Malang Town Square termasuk pusat perbelanjaan yang mengelilingi Alun-alun Kota Malang ?";
				btnBenar.onClick.AddListener(() => JawabanSalah());
				btnSalah.onClick.AddListener(() => JawabanBenar());
				break;
			case 3:
				soalText.text = "Terdapat 2 lokasi alun-alun dikota malang yakni di depan masjid jami’ dan satu lagi di didepan balai kota ?";
				btnBenar.onClick.AddListener(() => JawabanBenar());
				btnSalah.onClick.AddListener(() => JawabanSalah());
				break;
			case 4:
				soalText.text = "Alun-alun kota Malang bukan merupakan ikon kota Malang dan bukan juga sebagai tempat rekreasi ?";
				btnBenar.onClick.AddListener(() => JawabanSalah());
				btnSalah.onClick.AddListener(() => JawabanBenar());
				break;
			default:
				break;
		}

	}


	 void JawabanBenar(){
		//print("Jawaban Anda Benar...");
		//jawabanBenar = true;
		StartCoroutine(SelamatJawabanBenar());
	}

	 void JawabanSalah(){
		//print("Jawaban Anda Salah hahah...");
		//jawabanBenar = false;
		StartCoroutine(SelamatJawabanAndaSalah());
	}


	IEnumerator SelamatJawabanBenar(){

		finishController.pertanyaanPanelAnim.Play("fadeOut");
		yield return new WaitForSeconds(.8f);
		finishController.pertanyaanPanel.SetActive(false);
		hasilJawaban.text = "Jawaban Anda Benar";
		hasilPertanyaanPanel.SetActive(true);
		hasilPertanyaanPanelAnim.Play("fadeIn");
	}

	IEnumerator SelamatJawabanAndaSalah(){

		finishController.pertanyaanPanelAnim.Play("fadeOut");
		yield return new WaitForSeconds(.8f);
		finishController.pertanyaanPanel.SetActive(false);
		hasilJawaban.text = "Jawaban Anda Salah";
		hasilPertanyaanPanel.SetActive(true);
		levelSelanjutnyaButton.SetActive(false);
		hasilPertanyaanPanelAnim.Play("fadeIn");
	}


	public void PergiKeLevelSelanjutnya(){
		StartCoroutine(LevelSelanjutnya());
	}

	public void UlangiLagiLevelIni(){
		StartCoroutine(UlangiLevelIni());
	}

	IEnumerator LevelSelanjutnya(){

		yield return new WaitForSeconds(.7f);
		SceneManager.LoadScene(Application.loadedLevel + 1, loadMode);
	}


	IEnumerator UlangiLevelIni(){
		yield return new WaitForSeconds(.7f);
		SceneManager.LoadScene(Application.loadedLevel, loadMode);
	}



}
