using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public float Speed = 20f;

    public Transform FollowPosition;

    private GameObject pivot;
    private GameObject spawner;
    
    private float m_spawnTimeStamp = 5f;

    public GameObject misslePrefab;
    
    public float spawnTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        pivot = transform.Find("PivotCanon").gameObject;
        spawner = pivot.transform.Find("Spawner").gameObject;
    }

    // Update is called once per frame
    void Update()
    {  
        
        pivot.transform.LookAt(FollowPosition);
        pivot.transform.rotation*=Quaternion.Euler(0, 90, -20);
        if (Time.time > m_spawnTimeStamp)
        {
            var spawnPosition = spawner.transform.position;
            var spawnRotation = spawner.transform.rotation;
            GameObject missle = GameObject.Instantiate(misslePrefab, spawnPosition, spawnRotation) as GameObject;
            m_spawnTimeStamp = Time.time + spawnTime;
        }
        
    }
}
