using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Scripte créé par Laurent Jeanson

public class FailleEntreHopital : MonoBehaviour {
	[SerializeField]private int scene;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	// Si le joueur touche à la faille dans le mur, la scène de l'hôpital charge
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			SceneManager.LoadScene(scene);
		}
	}
}
