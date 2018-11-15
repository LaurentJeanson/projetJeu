using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scripte créé par Laurent Jeanson

public class GestionEventCine : MonoBehaviour {

	// GameObject des caméras
	public GameObject CameraEvent1;
	public GameObject CameraEvent2;
	public GameObject CameraEvent3;
	// GameObject des objets
	public GameObject CameraPerso;
	public GameObject Personnage;
	public GameObject FauxPersonnage;
	public GameObject GestionEventGameObject;
	// GameObject des UI
	public GameObject Text;
	public GameObject Panel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	// Commencer la fonction CineEvent lorsque la scène est chargée
	void Update () {
		StartCoroutine(CineEvent ());
	}
	// Activation et désactivation des caméras à la fin de leur animation respective.
	IEnumerator CineEvent(){
		print (Time.time);
		yield return new WaitForSeconds (3);
		print (Time.time);
		CameraEvent1.SetActive (false);
		CameraEvent2.SetActive (true);
		yield return new WaitForSeconds (3);
		print (Time.time);
		CameraEvent2.SetActive (false);
		CameraEvent3.SetActive (true);
		// Désactivation du texte après 6 secondes
		Text.SetActive (false);
		Panel.SetActive (false);
		yield return new WaitForSeconds (4);
		print (Time.time);
		CameraEvent3.SetActive (false);
		FauxPersonnage.SetActive (false);
		Personnage.SetActive (true);
		CameraPerso.SetActive (true);
		// Détruire les gameobjects non nécéssaire à la continuité du jeu
		Destroy (CameraEvent3);
		Destroy (GestionEventGameObject);
	}
}
