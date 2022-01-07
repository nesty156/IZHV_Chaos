using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public float Speed = 20f;

    public Transform FollowPosition;

    private GameObject pivot;
    // Start is called before the first frame update
    void Start()
    {
        pivot = transform.Find("PivotCanon").gameObject;
    }

    // Update is called once per frame
    void Update()
    {  
        
        pivot.transform.LookAt(FollowPosition);
        pivot.transform.rotation*=Quaternion.Euler(0, 90, 0);
    }
}
