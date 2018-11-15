//////////////////////////////////////////
////Carolanne Legault/////////////////////
////Philippe Thibeault////////////////////
//////////////////////////////////////////
////Dernière modification : 2018-11-14////
//////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Ennemis : MonoBehaviour
{

    //Cible à suivre
    public GameObject laCible;

    //NavMesh et Animator de l'ennemi
    NavMeshAgent navAgent;
    Animator ennemiAnim;

    //Valeurs publiques pour déterminer si l'ennemi touche le personnage, ses dégâts et sa vitesse d'attaque
    public static bool touchePerso = false;
    public static float degatEnnemi = 0.1f;
    public static float vitesseAttaque = 2;

	void Start ()
    {
        //Initialization
        navAgent = GetComponent<NavMeshAgent>();
        ennemiAnim = GetComponent<Animator>();
	}

	void Update ()
    {
        //On dit à l'ennemi de se diriger vers le personnage à une certaine vitesse
        navAgent.SetDestination(laCible.transform.position);
        ennemiAnim.SetFloat("vitesse", navAgent.velocity.magnitude);

        //Animation de l'ennemi s'il touche le personnage
        /***NON FONCTIONNEL***/
        //ennemiAnim.SetBool("touchePerso", touchePerso);
	}

    //Si l'ennemi est touché par une balle de fusil, on le détruit
    /***À TRAVAILLER SI ON VEUT QUE L'ENEMI AILLE DE LA VIE***/
    public void Touche()
    {
        Destroy(gameObject);
    }
}
