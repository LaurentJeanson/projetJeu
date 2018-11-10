using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionEventCine : MonoBehaviour {
	public GameObject CameraEvent1;
	public GameObject CameraEvent2;
	public GameObject CameraEvent3;
	public GameObject CameraPerso;
	public GameObject Personnage;
	public GameObject FauxPersonnage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(CineEvent ());
	}
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
		yield return new WaitForSeconds (4);
		print (Time.time);
		CameraEvent3.SetActive (false);
		FauxPersonnage.SetActive (false);
		Personnage.SetActive (true);
		CameraPerso.SetActive (true);
		Destroy (CameraEvent3);
	}
}
