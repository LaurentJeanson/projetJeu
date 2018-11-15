//////////////////////////////////////////
////Philippe Thibeault////////////////////
//////////////////////////////////////////
////Dernière modification : 2018-11-14////
//////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeplacementPerso : MonoBehaviour
{
    //Rigidbody et Animator du personnage
    private Rigidbody rb;
    private Animator anim;

    //Déterminer si le personnage court
    private bool court = false;

    //Vitesse du personnage
    public float vitesseDeplacement;

    //Variable publique pour déterminer si le personnage est mort
    public static bool estMort = false;

    void Start()
    {
        //Initialization
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //Si le personnage n'est pas mort
        if (!estMort)
        {
            //Aller chercher les touches du clavier du joueur selon la direction
            float deplacementHorizontal = Input.GetAxis("Horizontal");
            float deplacementVertical = Input.GetAxis("Vertical");

            //D/terminer les vitesses du personnage
            float vitesseHorizontal = -deplacementVertical * vitesseDeplacement;
            float vitesseVertical = deplacementHorizontal * vitesseDeplacement;

            //Si le joueur appuie sur shift
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //On augmente la vitesse et on dit qu'il court
                rb.velocity = new Vector3(vitesseHorizontal, 0, vitesseVertical).normalized * 20;
                court = true;
            }
            //Sinon
            else
            {
                //On laisse la vitesse normale et on dit qu'il ne court pas
                rb.velocity = new Vector3(vitesseHorizontal, 0, vitesseVertical).normalized * 10;
                court = false;
            }

            //Si le personnage bouge mais ne court pas
            if (rb.velocity.magnitude > 0 && !court)
            {
                //Animation de marche
                anim.SetBool("Marche", true);
                anim.SetBool("Court", false);
            }
            //S'il court
            else if (rb.velocity.magnitude > 0 && court)
            {
                //Animation de course
                anim.SetBool("Marche", false);
                anim.SetBool("Court", true);
            }
            //Sinon, animation 'idle'
            else
            {
                anim.SetBool("Marche", false);
                anim.SetBool("Court", false);
            }

            //Tracer un RayCast pour déterminer l'endroit de la souris dans le jeu
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit infoCollisionPerso;

            if (Physics.Raycast(camRay.origin, camRay.direction, out infoCollisionPerso, 5000, LayerMask.GetMask("Plancher")))
            {
                //Le personnage regarde l'edroit que la souris pointe
                Vector3 pointARegarder = infoCollisionPerso.point;
                transform.LookAt(pointARegarder);
                transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
            }

            RaycastHit hit;

            //Tracer un RayCast vers le bas en partant du personnage pour détecter s'il décolle du sol et, si oui, le faire descendre
            /***À AMÉLIORER***/
            if (Physics.Raycast(gameObject.transform.position, Vector3.down, out hit))
            {
                if (hit.distance > 1)
                {
                    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - hit.distance, gameObject.transform.position.z), 12 * Time.deltaTime);
                }
            }
        }
        //Sinon, perte du jeu
        else
        {
            DefaiteJeu();
        }
    }

    //Charger scène de défaite
    void DefaiteJeu()
    {
        SceneManager.LoadScene(7);
    }
}
