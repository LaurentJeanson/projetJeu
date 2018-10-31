using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Ennemis : MonoBehaviour {

    public GameObject laCible;
    NavMeshAgent navAgent;

	// Use this for initialization
	void Start () {
        navAgent = GetComponent<NavMeshAgent>();
		
	}
	
	// Update is called once per frame
	void Update () {
        navAgent.SetDestination(laCible.transform.position);
		
	}
}
