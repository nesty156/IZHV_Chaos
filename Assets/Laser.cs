using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject targetPrefab;
    private GameObject target;
    private LineRenderer lr;
    
    public float shootRate;
    private float m_shootRateTimeStamp;

    public GameObject m_shotPrefab;
    
    RaycastHit hit;
    public float range = 30.0f;
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
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
                target.transform.position = new Vector3(hit.point.x,hit.point.y,hit.point.z);
            }
        }
        else
        {
            lr.SetPosition(1, transform.forward*100);
            target.transform.position = new Vector3(0,-10.0f,0);
        }
        
        if (Input.GetMouseButton(0))
        {
            if (Time.time > m_shootRateTimeStamp)
            {
                shootRay();
                m_shootRateTimeStamp = Time.time + shootRate;
            }
        }
        
    }
    
    void shootRay()
    {
        //Ray ray = new Ray (transform.position, transform.forward);
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            GameObject laser = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
            laser.GetComponent<ShotBehavior>().setTarget(hit.point);
            GameObject.Destroy(laser, 2f);
            
        }
        else
        {
            GameObject laser = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
            laser.GetComponent<ShotBehavior>().setTarget(transform.position + transform.forward * range);
            GameObject.Destroy(laser, 2f);
        }
    }
    
}
