using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetruireParticuleToucher : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("Detruire");
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    IEnumerator Detruire()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
