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

    public GameObject ChampiBleu;
    public GameObject ChampiRouge;
    public GameObject ChampiVert;

    //Game objects pour stocker les points d'apparition des ennemis
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public GameObject spawn5;
    public GameObject spawn6;

    //Nombres pour déterminer le nombre d'ennemis total ainsi que la vitesse à laquelle ils sont créés
    public int nbEnnemisMax;
    public int spawnRate = 1;

    //Nombre d'ennemis créé
    private int nbEnnemisRange = 0;
    private int nbEnnemisProche = 0;
    private int nbEnnemisRangeTotal = 0;
    private int nbEnnemisProcheTotal = 0;
    public int nbEnnemisTotal;

    private int randEnnemi;

    public static int iNoVague = 0;
    public int iNbEnnemisMorts;


    // Use this for initialization
    void Start()
    {
        iNoVague++;
        SetVieEnnemiProche(2);
        SetVieEnnemiRange(1);
        //Instantier des ennemis
        InvokeRepeating("CreationEnnemiSpawn", 1, spawnRate);
    }

    //Créer des ennemis
    void CreationEnnemiSpawn()
    {
        var ennemi = "";
        nbEnnemisRangeTotal = nbEnnemisMax * 2 / 5;
        nbEnnemisProcheTotal = nbEnnemisMax - nbEnnemisRangeTotal;

        if (nbEnnemisRange < nbEnnemisRangeTotal && nbEnnemisProche < nbEnnemisProcheTotal)
        {
            randEnnemi = Random.Range(1, 3);

            switch (randEnnemi)
            {
                case 1:
                default:
                    ennemi = "ennemiRange";
                    break;
                case 2:
                    ennemi = "ennemiProche";
                    break;
            }
        }
        else if (nbEnnemisRange >= nbEnnemisRangeTotal && nbEnnemisProche < nbEnnemisProcheTotal)
        {
            ennemi = "ennemiProche";
        }
        else if (nbEnnemisRange < nbEnnemisRangeTotal && nbEnnemisProche >= nbEnnemisProcheTotal)
        {
            ennemi = "ennemiRange";
        }

        //Si le nombre maximal d'ennemis n'est pas atteint
        if (nbEnnemisTotal < nbEnnemisMax)
        {
            var ennemiCree = EnnemiOrange;

            int i = Random.Range(1, 6);
            int j = Random.Range(1, 7);
            int k = Random.Range(1, 4);

            if (ennemi == "ennemiProche")
            {
                //Selon le premier chiffre aléatoire, on créé un ennemi d'une certaine couleur
                switch (i)
                {
                    case 1:
                    default:
                        ennemiCree = EnnemiBleu;
                        break;
                    case 2:
                        ennemiCree = EnnemiJaune;
                        break;
                    case 3:
                        ennemiCree = EnnemiMauve;
                        break;
                    case 4:
                        ennemiCree = EnnemiOrange;
                        break;
                    case 5:
                        ennemiCree = EnnemiRouge;
                        break;
                }
                nbEnnemisProche++;
            }
            else if (ennemi == "ennemiRange")
            {

                //Selon le premier chiffre aléatoire, on créé un ennemi d'une certaine couleur
                switch (k)
                {
                    case 1:
                    default:
                        ennemiCree = ChampiBleu;
                        break;
                    case 2:
                        ennemiCree = ChampiRouge;
                        break;
                    case 3:
                        ennemiCree = ChampiVert;
                        break;
                }
                nbEnnemisRange++;
            }
            
            var clone = Instantiate(ennemiCree);

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
            clone.SetActive(true);

            //Augmenter le nombre d'ennemis créé
            nbEnnemisTotal++;
        }
        //Sinon on en créé plus
        else
        {
            CancelInvoke("CreationEnnemiSpawn");
        }
    }

    public void ProchaineVague(int nbEnnemisACreer, int vieEnnemisProche, int vieEnnemisRange)
    {
        nbEnnemisTotal = 0;
        nbEnnemisMax = nbEnnemisACreer;
        SetVieEnnemiProche(vieEnnemisProche);
        SetVieEnnemiRange(vieEnnemisRange);
        InvokeRepeating("CreationEnnemiSpawn", 1, spawnRate);
    }

    public static void SetVieEnnemiProche(int vie)
    {
        Ennemis.vieEnnemi = vie;
    }

    public static void SetVieEnnemiRange(int vie)
    {
        EnnemiRange.vieEnnemi = vie;
    }
}