using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scripte créé par Laurent Jeanson

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
		// Démarrer les fonctions comprennant du temps lorsque la scène est chargée
		StartCoroutine(CineIntro ());
		StartCoroutine(Direction ());
	}
	// Après 10 secondes, le faux personnage et la caméra de la cinématique se désactive et le personnage controlable + sa caméra s'active
	// Le premier texte se désactive et le deuxième s'active pour complété l'intro (Avec leur panel).
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
	// Après 16 secondes que la scène soit chargée, le deuxième texte se désactive et se détruit car il devient inutile (avec son panel)
	IEnumerator Direction(){
		print (Time.time);
		yield return new WaitForSeconds (16);
		print (Time.time);
		Destroy (PanelDirection);
		Destroy (TexteDirection);
		Destroy (GestionEvent);
	}
}
