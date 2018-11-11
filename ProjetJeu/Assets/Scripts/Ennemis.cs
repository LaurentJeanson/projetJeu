using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Ennemis : MonoBehaviour {

    public GameObject laCible;
    NavMeshAgent navAgent;
    Animator ennemiAnim;

    public static bool touchePerso = false;
    public static float degatEnnemi = 0.1f;
    public static float vitesseAttaque = 2;

	// Use this for initialization
	void Start () {
        navAgent = GetComponent<NavMeshAgent>();
        ennemiAnim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
        navAgent.SetDestination(laCible.transform.position);
        ennemiAnim.SetFloat("vitesse", navAgent.velocity.magnitude);

        ennemiAnim.SetBool("touchePerso", touchePerso);
	}
}
