using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObstacle : MonoBehaviour
{
    public GameObject lasthit;
    public Vector3 colllision = Vector3.zero;
    public LayerMask Layer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var ray = new Ray(this.transform.position, Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 20, Layer))
        {
            lasthit = hit.transform.gameObject;
            print(hit.collider.name);
            colllision = hit.point;

        }
    }
    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(colllision,0.2f);
    }
}
