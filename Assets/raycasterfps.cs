using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycasterfps : MonoBehaviour
{
    public GameObject revealSphere;
    public Transform revealSpheresParent;

    public float backrayStepScale = 1f;
    public float sphereScale = 1.1f;

    public float minimumSphereDiameter = 0.1f;
    public float maximumSphereDiameter = 1f;

    bool activated = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            CastForNeurons();
        }

        CastForCues();
        
    }

    void CastForCues()
    {
        var layermask = LayerMask.GetMask("Cues");
        Ray rayC = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.SphereCast(rayC, 0.1f, out hit, maxDistance: Mathf.Infinity, layerMask: layermask))
        {
            var cue = hit.transform.GetComponent<cue>();
            if (activated)
            {
                cue.Activate();
            }
            if (cue.CueNumber == 0)
            {
                activated = true;
                cue.Activate();
            }
            
        }
    }

    void CastForNeurons()
    {
        var layermask = LayerMask.GetMask("Neuron");
        Ray rayC = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.SphereCast(rayC, 0.1f, out hit, maxDistance: Mathf.Infinity, layerMask: layermask))
        {
            Debug.Log(hit.collider.gameObject.name);
            var hit1Position = hit.point;
            Debug.Log(hit1Position);
            Ray ray2 = new Ray(hit.point, -rayC.direction);
            RaycastHit backwardsHit = new RaycastHit();

            for (int i = 0; i < 20; i++)
            {
                ray2 = new Ray(ray2.origin + rayC.direction * backrayStepScale, -rayC.direction);
                bool hitFound = Physics.Raycast(ray2, out backwardsHit, Mathf.Infinity, layerMask: layermask);
                if (hitFound)
                {
                    Debug.Log(backwardsHit.collider.gameObject.name);
                    Debug.Log(backwardsHit.point);
                    SpawnSphere(hit.point, backwardsHit.point);
                    break;
                }
            }
        }
    }

    void SpawnSphere(Vector3 hit1Position, Vector3 hit2Position)
    {
        var diameter = GetDiameter(hit1Position, hit2Position);
        var centerPosition = (hit1Position + hit2Position) / 2f;

        var newSphere = Instantiate(revealSphere, revealSpheresParent);

        Debug.Log(string.Format("Diameter {0}", diameter));

        newSphere.transform.position = centerPosition;
        newSphere.transform.localScale = diameter * Vector3.one * sphereScale;
    }

    float GetDiameter(Vector3 hit1Position, Vector3 hit2Position)
    {
        var diameter = (hit1Position - hit2Position).magnitude;
        if (diameter < minimumSphereDiameter)
        {
            return minimumSphereDiameter;
        }
        if (diameter > maximumSphereDiameter)
        {
            return maximumSphereDiameter;
        }
        return diameter;
    }
}
