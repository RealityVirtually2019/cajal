using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycasttest : MonoBehaviour
{
    public Transform controller;
    public Transform target;

    public GameObject revealSphere;
    public Transform revealSpheresParent;

    public float backrayStepScale = 1f;
    public float sphereScale = 1.1f;

    public float minimumSphereDiameter = 0.1f;
    public float maximumSphereDiameter = 1f;

    bool mouseDown = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;
        //if (Input.GetMouseButton(0))
        //{
            var layermask = LayerMask.GetMask("Neuron");
            //Ray ray1 = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        Ray rayC = new Ray(controller.position, target.position - controller.position);

        GetComponent<LineRenderer>().SetPosition(0, controller.position);
        GetComponent<LineRenderer>().SetPosition(1,(target.position - controller.position).normalized*100);

        Debug.DrawRay(controller.position, target.position - controller.position, Color.green);

            RaycastHit hit;
            if (Physics.SphereCast(rayC, 0.1f, out hit, maxDistance: Mathf.Infinity, layerMask: layermask))
            {
                GetComponent<LineRenderer>().SetPosition(1, hit.point);

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


            //RaycastHit hitInfo;
            //if (Physics.Raycast(ray1, out hitInfo))
            //{
            //    var secondRayOrigin = hitInfo.point;
            //    Debug.Log(secondRayOrigin);
            //    Ray ray2 = new Ray(secondRayOrigin + (ray1.direction * 100f), -ray1.direction);
            //    if (Physics.Raycast(ray2, out hitInfo))
            //    {
            //        Debug.Log(hitInfo.point);

            //        var diameter = (secondRayOrigin - hitInfo.point).magnitude;
            //        var position = (secondRayOrigin + hitInfo.point) / 2f;
            //        Debug.Log(position);

            //        var newSphere = Instantiate(sphere);
            //        newSphere.transform.position = position;
            //        newSphere.transform.localScale = diameter * Vector3.one * 1.1f;
            //        Debug.Log(newSphere.transform);
            //    }
            //}
        //}
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
