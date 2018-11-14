using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionArmeEvenrt : MonoBehaviour {
    public GameObject Texte;
    public GameObject Panel;
    public GameObject Texte2;
    public GameObject Panel2;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Texte.SetActive(false);
            Panel.SetActive(false);
            Texte2.SetActive(true);
            Panel2.SetActive(true);
            StartCoroutine(Cerveautexte());
        }
    }
    IEnumerator Cerveautexte()
    {
        print(Time.time);
        yield return new WaitForSeconds(10);
        print(Time.time);
        Texte2.SetActive(false);
        Panel2.SetActive(false);
    }
}
