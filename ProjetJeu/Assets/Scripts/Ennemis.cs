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
using UnityEngine.SceneManagement;

public class Ennemis : MonoBehaviour
{

    //Cible à suivre
    public GameObject laCible;

    public GameObject GenerateurEnnemis;

    public static int vieEnnemi;
    public int vie;

    //NavMesh et Animator de l'ennemi
    NavMeshAgent navAgent;
    Animator ennemiAnim;

    //Valeurs publiques pour déterminer si l'ennemi touche le personnage, ses dégâts et sa vitesse d'attaque
    public static bool touchePerso = false;
    public static float degatEnnemi = 0.1f;
    public static float vitesseAttaque = 2;

	void Start ()
    {
        print(vie);
        //Initialization
        navAgent = GetComponent<NavMeshAgent>();
        ennemiAnim = GetComponent<Animator>();
        vie = InitializeVie();
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
        vie--;

        if (vie <= 0)
        {
            Destroy(gameObject);
            GenerateurEnnemis.GetComponent<GenerationEnnemis>().iNbEnnemisMorts++;
        }

        if (GenerateurEnnemis.GetComponent<GenerationEnnemis>().iNbEnnemisMorts >= GenerateurEnnemis.GetComponent<GenerationEnnemis>().nbEnnemisTotal)
        {
            GenerationEnnemis.iNoVague++;

            StartCoroutine("AllerProchaineVague");
        }
    }

    void AllerProchaineVague()
    {
        switch (GenerationEnnemis.iNoVague)
        {
            case 2:
                print("Vague No : " + GenerationEnnemis.iNoVague);
                GenerateurEnnemis.GetComponent<GenerationEnnemis>().ProchaineVague(15, 3, 2);
                break;
            case 3:
                print("Vague No : " + GenerationEnnemis.iNoVague);
                GenerateurEnnemis.GetComponent<GenerationEnnemis>().ProchaineVague(20, 3, 2);
                break;
            case 4:
                print("Vague No : " + GenerationEnnemis.iNoVague);
                GenerateurEnnemis.GetComponent<GenerationEnnemis>().ProchaineVague(25, 3, 2);
                break;
            case 5:
                print("Vague No : " + GenerationEnnemis.iNoVague);
                GenerateurEnnemis.GetComponent<GenerationEnnemis>().ProchaineVague(30, 3, 2);
                break;
            case 6:
                print("Vague No : " + GenerationEnnemis.iNoVague);
                GenerateurEnnemis.GetComponent<GenerationEnnemis>().ProchaineVague(35, 3, 2);
                break;
            case 7:
                print("Vague No : " + GenerationEnnemis.iNoVague);
                GenerateurEnnemis.GetComponent<GenerationEnnemis>().ProchaineVague(40, 3, 2);
                break;
            case 8:
                print("Vague No : " + GenerationEnnemis.iNoVague);
                GenerateurEnnemis.GetComponent<GenerationEnnemis>().ProchaineVague(45, 3, 2);
                break;
            case 9:
                print("Vague No : " + GenerationEnnemis.iNoVague);
                GenerateurEnnemis.GetComponent<GenerationEnnemis>().ProchaineVague(50, 3, 2);
                break;
            case 10:
                print("Vague No : " + GenerationEnnemis.iNoVague);
                GenerateurEnnemis.GetComponent<GenerationEnnemis>().ProchaineVague(55, 3, 2);
                break;
            default:
                SceneManager.LoadScene(9);
                break;
        }
    }

    public static int InitializeVie()
    {
        int vie = vieEnnemi;
        return vie;
    }
}
