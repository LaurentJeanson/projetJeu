using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionEventHopital : MonoBehaviour {
	public GameObject CameraEvent;
	public GameObject CameraPerso;
	public GameObject Text;
	public GameObject Panel;
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
	IEnumerator CineEventHopital(){
		print (Time.time);
		yield return new WaitForSeconds (7);
		print (Time.time);
		CameraEvent.SetActive (false);
		Personnage.SetActive (true);
		CameraPerso.SetActive (true);
		Text.SetActive (false);
		Panel.SetActive (false);
		Destroy (GestionEventHopitalObjet);
	}
}
