using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PertanyaanLevel3 : MonoBehaviour {

	
	[SerializeField]private Text soalText, hasilJawaban;

	[SerializeField]private GameObject hasilPertanyaanPanel, levelSelanjutnyaButton;
	[SerializeField]private Animator hasilPertanyaanPanelAnim;

	public LoadSceneMode loadMode = LoadSceneMode.Single;

	public int soal1 = 1, soalSelanjutnya = 5, soalSebenarnya, sebenarbenarnya;

	//public bool jawabanBenar, jawabanSalah;

	public Button btnBenar, btnSalah;

	//++
	[SerializeField]private FinishController finishController;


	void Start(){

			soalSebenarnya = Random.Range(soal1, soalSelanjutnya);
			print("Soal Sebenarnya = " +soalSebenarnya);
			sebenarbenarnya = Random.Range(soalSebenarnya, soalSelanjutnya);
			print("Soal Sebenarbenarnya = " +sebenarbenarnya);
	}

	public void PasangSoalDiPertanyaanPanel(){

		switch(sebenarbenarnya){

			case 1:	
				soalText.text = "Gunung Bromo memiliki ketinggian 2.392 meter di atas permukaan laut ?";
				btnBenar.onClick.AddListener(() => JawabanBenar());
				btnSalah.onClick.AddListener(() => JawabanSalah());
				break;
			case 2:
				soalText.text = "Upacara Kasodo digelar setiap tahun pada bulan purnama di bulan Desember atau January ?";
				btnBenar.onClick.AddListener(() => JawabanBenar());
				btnSalah.onClick.AddListener(() => JawabanSalah());
				break;
			case 3:
				soalText.text = "Gunung Bromo termasuk dalam kawasan Taman Nasional Bromo Tengger Semeru ?";
				btnBenar.onClick.AddListener(() => JawabanBenar());
				btnSalah.onClick.AddListener(() => JawabanSalah());
				break;
			case 4:
				soalText.text = "Letusan terbesar terjadi pada tahun 1964 dan kembali meletus di tahun 2010 ?";
				btnBenar.onClick.AddListener(() => JawabanSalah());
				btnSalah.onClick.AddListener(() => JawabanBenar());
				break;
			case 5:
				soalText.text = "Bromo menjadi menarik karena statusnya sebagai gunung berapi yang tidak aktif ?";
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
