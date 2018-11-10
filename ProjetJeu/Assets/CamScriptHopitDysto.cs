using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScriptHopitDysto : MonoBehaviour {
	public GameObject CameraEvent;
	public GameObject CameraPerso;
	//public GameObject Perso;
	//public GameObject FauxPerso;
	public GameObject EventHopitalDysto;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(CineEventHopitalDysto ());
	}
	IEnumerator CineEventHopitalDysto(){
		print (Time.time);
		yield return new WaitForSeconds (20);
		print (Time.time);
		CameraEvent.SetActive (false);
		//FauxPerso.SetActive (false);
		//Perso.SetActive (true);
		CameraPerso.SetActive (true);
		Destroy (EventHopitalDysto);
	}
}
