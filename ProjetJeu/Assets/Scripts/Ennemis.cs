using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Ennemis : MonoBehaviour {

    public GameObject laCible;
    NavMeshAgent navAgent;
    Animator ennemiAnim;

	// Use this for initialization
	void Start () {
        navAgent = GetComponent<NavMeshAgent>();
        ennemiAnim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
        navAgent.SetDestination(laCible.transform.position);
        print(navAgent.velocity.magnitude);
        ennemiAnim.SetFloat("vitesse", navAgent.velocity.magnitude);
		
	}
}
