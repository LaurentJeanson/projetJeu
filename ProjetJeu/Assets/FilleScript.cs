using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilleScript : MonoBehaviour {
	public GameObject texte;
	public GameObject panel;
	public GameObject Perso;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter(Collider other)
	{
		// Si l'objet est en contact avec le joueur, les particules, le faux fusil et le texte du tutoriel se désactivent
		// Le vrai fusil s'active avec un autre texte de tutoriel
		if (other.gameObject.tag == "Player") {
			texte.SetActive (true);
			panel.SetActive (true);
			StartCoroutine(FilleTempsTexte());
		} 
	}
	IEnumerator FilleTempsTexte(){
		print (Time.time);
		yield return new WaitForSeconds (8);
		print (Time.time);
		texte.SetActive (false);
		panel.SetActive (false);
	}
}
