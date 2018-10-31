using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemis : MonoBehaviour {
    public GameObject laCible; // Cible de l'ennemis
    NavMeshAgent navAgent;

    // Use this for initialization
    void Start () {
        navAgent = GetComponent<NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update () {
        navAgent.SetDestination(laCible.transform.position); //Permet le déplacement de l'ennemi vers la cible (personnage)
	}
}
