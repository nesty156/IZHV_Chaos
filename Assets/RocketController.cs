using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{

    public float Speed = 10f;
    public float RotateSpeed = 3f;
    public float timeHoming = 3f;
    public float flyUp = 0.5f;
    public GameObject collisionExplosion;
    private Transform FollowPosition;
    private Rigidbody rb;
    public AudioClip explosionClip;
    public float audioVolume = 2f;

    private float createdTime;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        FollowPosition = GameObject.FindGameObjectWithTag("Player").transform;
        createdTime = Time.time;
        transform.LookAt(FollowPosition);
        transform.rotation*=Quaternion.Euler(0, 0, -20);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time < timeHoming + createdTime)
        {
            Vector3 direction;
            if (Time.time < flyUp + createdTime)
            {
                direction = (Vector3) FollowPosition.position - rb.position;
                direction = new Vector3(direction.x,0f,direction.z);
                direction.Normalize();
            }
            else
            {
                direction = (Vector3) FollowPosition.position - rb.position;

                direction.Normalize();
            }

            var rotateAmount = Vector3.Cross(direction, transform.forward);

            rb.angularVelocity = -rotateAmount * RotateSpeed;
        }
        rb.velocity = transform.forward * Speed;
    }

    private void OnCollisionEnter()
    {
        explode();
    }

    void explode()
    {
        if (collisionExplosion  != null) {
            GameObject explosion = (GameObject)Instantiate(
                collisionExplosion, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(explosionClip, transform.position, audioVolume);
            Destroy(gameObject);
            var explosionPosition = transform.position;
            var explosionRadius = 1f;
            Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);
            foreach (var col in colliders)
            {
                if (col.GetComponent<Collider>().tag == "Platform")
                {
                    Destroy(col.GetComponent<Collider>().gameObject);
                }
            }
            Destroy(explosion, 1f);
        }


    }
}
