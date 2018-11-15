using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scripte créé par Laurent Jeanson

public class GestionEventHopital : MonoBehaviour {
	// GameObject des caméras
	public GameObject CameraEvent;
	public GameObject CameraPerso;
	// GameObject des UI
	public GameObject Text;
	public GameObject Panel;
	// GameObject des objets
	public GameObject Personnage;
	public GameObject GestionEventHopitalObjet;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter(Collider other)
	{
		// Lorsque le gameobject vide est touché par le joueur, une cinématique commence
		// La caméra ayant une animation commence alors que le joueur et sa caméra sont désactivé.
		if (other.gameObject.tag == "Player")
		{
			CameraEvent.SetActive (true);
			Personnage.SetActive (false);
			CameraPerso.SetActive (false);
			Text.SetActive (true);
			Panel.SetActive (true);
			StartCoroutine(CineEventHopital ());
		}
	}
	// Après 7 secondes,la caméra de la cinématique se désactive et le personne + sa caméra s'activent
	IEnumerator CineEventHopital(){
		print (Time.time);
		yield return new WaitForSeconds (7);
		print (Time.time);
		CameraEvent.SetActive (false);
		Personnage.SetActive (true);
		CameraPerso.SetActive (true);
		Text.SetActive (false);
		Panel.SetActive (false);
		// Détruire l'objet non nécéssaire pour la continuité du jeu
		Destroy (GestionEventHopitalObjet);
	}
}
