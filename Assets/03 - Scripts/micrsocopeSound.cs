using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class micrsocopeSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (GameObject.Find("MUSIC"))
        {
            Destroy(GameObject.Find("MUSIC"));
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
