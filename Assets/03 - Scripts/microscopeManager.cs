using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class microscopeManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            Debug.Log("hola");
            other.transform.root.GetComponent<changeScene>().loadScene = true;
        }
    }

}
