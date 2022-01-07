using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject targetPrefab;
    private GameObject target;
    private LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        target = Instantiate(targetPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0,transform.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
                target.transform.position = new Vector3(hit.point.x,hit.point.y + 0.3f ,hit.point.z);
            }
        }
        else
        {
            lr.SetPosition(1,transform.position);
            target.transform.position = new Vector3(0,-10.0f,0);
        }
        
    }
}
