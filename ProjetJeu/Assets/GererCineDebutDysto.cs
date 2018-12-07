using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GererCineDebutDysto : MonoBehaviour {
    public GameObject Camera1;
    public GameObject Personnage1;
    public GameObject Camera2;
    public GameObject Personnage2;
    public GameObject Camera3;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(CineEventDystoDebut());
    }
    IEnumerator CineEventDystoDebut()
    {
        print(Time.time);
        yield return new WaitForSeconds(15);
        print(Time.time);
        Camera1.SetActive(false);
        Personnage1.SetActive(false);
        Camera2.SetActive(true);
        Personnage2.SetActive(true);
        yield return new WaitForSeconds(4);
        print(Time.time);
        Camera2.SetActive(false);
        Camera3.SetActive(true);
        yield return new WaitForSeconds(4);
        print(Time.time);
        Camera3.SetActive(false);
        Personnage2.SetActive(false);
    }
}
