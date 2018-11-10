using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionEventIntro : MonoBehaviour {
	public GameObject CameraIntro;
	public GameObject CameraPerso;
	public GameObject PersoIntro;
	public GameObject PersoJeu;
	public GameObject Texte;
	public GameObject Panel;
	public GameObject TexteDirection;
	public GameObject PanelDirection;
	public GameObject GestionEvent;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(CineIntro ());
		StartCoroutine(Direction ());
	}
	IEnumerator CineIntro(){
		print (Time.time);
		yield return new WaitForSeconds (10);
		print (Time.time);
		CameraIntro.SetActive (false);
		CameraPerso.SetActive (true);
		PersoIntro.SetActive (false);
		PersoJeu.SetActive (true);
		Texte.SetActive (false);
		Panel.SetActive (false);
		TexteDirection.SetActive (true);
		PanelDirection.SetActive (true);
	}
	IEnumerator Direction(){
		print (Time.time);
		yield return new WaitForSeconds (16);
		print (Time.time);
		Destroy (PanelDirection);
		Destroy (TexteDirection);
		Destroy (GestionEvent);
	}
}
