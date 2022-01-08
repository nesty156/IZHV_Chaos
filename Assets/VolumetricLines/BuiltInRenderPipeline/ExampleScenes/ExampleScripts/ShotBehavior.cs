using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {

	public Vector3 m_target;
	public GameObject collisionExplosion;
	public float speed;
	public AudioClip explosionClip;
	public float audioVolume = 2f;


	// Update is called once per frame
	void Update()
	{
		// transform.position += transform.forward * Time.deltaTime * 300f;// The step size is equal to speed times frame time.
		float step = speed * Time.deltaTime;

		if (m_target != null)
		{
			if (transform.position == m_target)
			{
				explode();
				return;
			}
			transform.position = Vector3.MoveTowards(transform.position, m_target, step);
		}

	}

	public void setTarget(Vector3 target)
	{
		m_target = target;
	}

	void explode()
	{
		if (collisionExplosion  != null) {
			GameObject explosion = (GameObject)Instantiate(
				collisionExplosion, transform.position, transform.rotation);
			AudioSource.PlayClipAtPoint(explosionClip, transform.position, audioVolume);
			Destroy(gameObject);
			var explosionPosition = transform.position;
			var explosionRadius = 0.6f;
			Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);
			foreach (var col in colliders)
			{
				if (col.name == "stand")
				{
					TurretController.Instance.TakeHit(1f);
				}
				if (col.GetComponent<Collider>().tag == "Platform")
				{
					Destroy(col.GetComponent<Collider>().gameObject);
				}
			}
			Destroy(explosion, 1f);
		}
		
	}

}
