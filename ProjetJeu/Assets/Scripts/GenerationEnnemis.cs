//////////////////////////////////////////
////Philippe Thibeault////////////////////
//////////////////////////////////////////
////Dernière modification : 2018-11-14////
//////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationEnnemis : MonoBehaviour
{
    //Game objects pour stocker les ennemis
    public GameObject EnnemiBleu;
    public GameObject EnnemiJaune;
    public GameObject EnnemiMauve;
    public GameObject EnnemiOrange;
    public GameObject EnnemiRouge;
    public GameObject EnnemiVert;

    //Game objects pour stocker les points d'apparition des ennemis
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public GameObject spawn5;
    public GameObject spawn6;

    //Nombres pour déterminer le nombre d'ennemis total ainsi que la vitesse à laquelle ils sont créés
    public int nbEnnemisTotal;
    public int spawnRate = 1;

    //Nombre d'ennemis créé
    private int nbEnnemis = 0;

    public static int iNoVague = 0;
    public int iNbEnnemisMorts;


    // Use this for initialization
    void Start()
    {
        iNoVague++;
        //Instantier des ennemis
        InvokeRepeating("CreationEnnemiSpawn", 1, spawnRate);
    }

    //Créer des ennemis
    void CreationEnnemiSpawn()
    {
        //Si le nombre maximal d'ennemis n'est pas atteint
        if (nbEnnemis < nbEnnemisTotal)
        {
            //Créer un ennemi
            var ennemi = EnnemiBleu;
            //Calculer des chiffres aléatoires et une taille aléatoire
            int i = Random.Range(1, 7);
            int j = Random.Range(1, 7);
            int scale = Random.Range(1, 3);

            //Selon le premier chiffre aléatoire, on créé un ennemi d'une certaine couleur
            switch (i)
            {
                case 1:
                default:
                    ennemi = EnnemiBleu;
                    break;
                case 2:
                    ennemi = EnnemiJaune;
                    break;
                case 3:
                    ennemi = EnnemiMauve;
                    break;
                case 4:
                    ennemi = EnnemiOrange;
                    break;
                case 5:
                    ennemi = EnnemiRouge;
                    break;
                case 6:
                    ennemi = EnnemiVert;
                    break;
            }

            var clone = Instantiate(ennemi);

            //Selon le deuxième chiffre aléatoire, on créé l'ennemi à un certain endroit
            switch (j)
            {
                case 1:
                default:
                    clone.transform.position = spawn1.transform.position;
                    break;
                case 2:
                    clone.transform.position = spawn2.transform.position;
                    break;
                case 3:
                    clone.transform.position = spawn3.transform.position;
                    break;
                case 4:
                    clone.transform.position = spawn4.transform.position;
                    break;
                case 5:
                    clone.transform.position = spawn5.transform.position;
                    break;
                case 6:
                    clone.transform.position = spawn6.transform.position;
                    break;
            }
            //Selon le troisième chiffre aléatoire, on définit une certaine taille et on active l'ennemi
            clone.transform.localScale = new Vector3(scale, scale, scale);
            clone.SetActive(true);

            //Augmenter le nombre d'ennemis créé
            nbEnnemis++;
        }
        //Sinon on en créé plus
        else
        {
            CancelInvoke("CreationEnnemiSpawn");
        }
    }

    public void ProchaineVague(int nbEnnemisACreer)
    {
        nbEnnemis = 0;
        nbEnnemisTotal = nbEnnemisACreer;
        InvokeRepeating("CreationEnnemiSpawn", 1, spawnRate);
    }
}