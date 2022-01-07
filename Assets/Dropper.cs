using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    private int durability = 3;
    private float destroyIn = 1.0f;
    public Material Mat1;
    public Material Mat2;
    public Material Mat3;
    public Material Mat4;
    void Start()
    {
        this.gameObject.GetComponent<MeshRenderer> ().material = Mat1;
    }
    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.name.Equals("tank"))
        {
            durability--;
            switch(durability) 
            {
                case 2:
                    this.gameObject.GetComponent<MeshRenderer> ().material = Mat2;
                    break;
                case 1:
                    this.gameObject.GetComponent<MeshRenderer> ().material = Mat3;
                    break;
                case 0:
                    this.gameObject.GetComponent<MeshRenderer> ().material = Mat4;
                    break;
            }
            if (durability <= 0)
            {
                Destroy(this.gameObject,destroyIn);
                Debug.Log("Destroyed:" + this.name);
            }
        }
    }
}
