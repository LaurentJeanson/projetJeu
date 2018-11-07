using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationEnnemis : MonoBehaviour
{

    public GameObject EnnemiBleu;
    public GameObject EnnemiJaune;
    public GameObject EnnemiMauve;
    public GameObject EnnemiOrange;
    public GameObject EnnemiRouge;
    public GameObject EnnemiVert;

    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public GameObject spawn5;
    public GameObject spawn6;

    public int nbEnnemisTotal;
    public int spawnRate;

    private int nbEnnemis = 0;


    // Use this for initialization
    void Start()
    {
        InstantierEnnemis();
    }

    void InstantierEnnemis()
    {
        InvokeRepeating("CreationEnnemiSpawn", 1, spawnRate);
    }

    // Update is called once per frame
    void CreationEnnemiSpawn()
    {
        if (nbEnnemis < nbEnnemisTotal)
        {
            var ennemi = EnnemiBleu;
            int i = Random.Range(1, 7);
            int j = Random.Range(1, 7);
            int scale = Random.Range(1, 3);

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
            clone.transform.localScale = new Vector3(scale, scale, scale);
            clone.SetActive(true);

            nbEnnemis++;
        }
        else
        {
            CancelInvoke("CreationEnnemiSpawn");
        }
    }
}