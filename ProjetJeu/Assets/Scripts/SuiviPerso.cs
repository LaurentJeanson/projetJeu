using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuiviPerso : MonoBehaviour {

    public GameObject Cible;
    public Vector3 Distance;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Cible.transform.position + Distance;
        transform.LookAt(Cible.transform.position);
    }
}
