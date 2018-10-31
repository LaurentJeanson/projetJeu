using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour {
    public GameObject ClickSon;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            ClickSon.SetActive(true);
        }
        else
        {
            ClickSon.SetActive(false);
        }
	}
}
