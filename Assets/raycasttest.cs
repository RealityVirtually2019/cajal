using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycasttest : MonoBehaviour
{
    private Ray ray1;
    private Ray ray2;

    public GameObject sphere;

    public float backrayStepScale = 1f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var layermask = LayerMask.GetMask("Player");
            Ray ray1 = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray1, out hit, maxDistance: Mathf.Infinity, layerMask: layermask))
            {
                Debug.Log(hit.collider.gameObject.name);
                var hit1Position = hit.point;
                Debug.Log(hit1Position);
                Ray ray2 = new Ray(hit.point, -ray1.direction);
                RaycastHit backwardsHit = new RaycastHit();
                for (int i = 0; i < 20; i++)
                {
                    ray2 = new Ray(ray2.origin + ray1.direction * backrayStepScale, -ray1.direction);
                    bool hitFound = Physics.Raycast(ray2, out backwardsHit, Mathf.Infinity, layerMask: layermask);
                    if (hitFound)
                    {
                        break;
                    }
                }

                Debug.Log(backwardsHit.collider.gameObject.name);
                Debug.Log(backwardsHit.point);

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
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(ray1);
        Gizmos.DrawRay(ray2);
    }
}
