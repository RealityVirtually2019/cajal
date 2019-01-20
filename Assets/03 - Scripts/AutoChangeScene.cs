using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoChangeScene : MonoBehaviour {

    public float timeToChange = 5;

    private float timer;
	// Use this for initialization
	void Start () {
        timer = timeToChange;

    }
	
	// Update is called once per frame
	void Update () {
        timer = timer - Time.deltaTime;
        if (timer < 0)
        {
            GetComponent<changeScene>().loadScene= true;
        }
	}
}
