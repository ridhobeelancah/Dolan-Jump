using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PertanyaanLevel2 : MonoBehaviour {

	
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
				soalText.text = "Kampung Wisata Jodipan di Kota Malang, Jawa Timur bukanlah Kampung wisata warna-warni ?";
				btnBenar.onClick.AddListener(() => JawabanSalah());
				btnSalah.onClick.AddListener(() => JawabanBenar());
				break;
			case 2:
				soalText.text = "Kampung Wisata Jodipan terletak di sebelah selatan Stasiun Kota Baru, atau di RW 2 ?";
				btnBenar.onClick.AddListener(() => JawabanBenar());
				btnSalah.onClick.AddListener(() => JawabanSalah());
				break;
			case 3:
				soalText.text = "Keindahan Kampung Jodipan ini tercetus dari ide para Mahasiswa Universitas Muhammadiyah Malang ?";
				btnBenar.onClick.AddListener(() => JawabanBenar());
				btnSalah.onClick.AddListener(() => JawabanSalah());
				break;
			case 4:
				soalText.text = "Kampung warna-warni, yang dulu merupakan 'permukiman kumuh' sekarang menjadi lokasi yang banyak dikunjungi wisatawan ?";
				btnBenar.onClick.AddListener(() => JawabanBenar());
				btnSalah.onClick.AddListener(() => JawabanSalah());
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
