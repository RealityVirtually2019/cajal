using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutCamera : MonoBehaviour {

    public GameObject blackCube;
    public float fadeTime = 2;
    private float timer;

	// Use this for initialization
	void Start () {
        blackCube.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 0);
        timer = fadeTime;
    }
	
	// Update is called once per frame
	void Update () {
        timer = timer - Time.deltaTime;
        Color c = new Color(0, 0, 0, 1- timer / fadeTime);
        blackCube.GetComponent<MeshRenderer>().material.color = c;

        if (timer < 0)
        {
            blackCube.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 1);
            Destroy(this);
        }
    }
}
