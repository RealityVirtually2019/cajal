using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOnPickup : OVRGrabbable {



    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        Debug.Log("start Grabbing");
        GetComponent<AudioSource>().Play(0);
        base.GrabBegin(hand, grabPoint);
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        GetComponent<AudioSource>().Stop();
        base.GrabEnd(linearVelocity, angularVelocity);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
