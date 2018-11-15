using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScenePorte : MonoBehaviour {
	[SerializeField]private int scene; //Scène à charger
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
		if (other.gameObject.tag == "Player")
		{
			SceneManager.LoadScene(scene);
		}
	}
}
