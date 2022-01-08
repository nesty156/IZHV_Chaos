using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public static TurretController Instance;
    
    public float Speed = 20f;
    public Transform FollowPosition;
    public GameObject misslePrefab;
    public float spawnTime = 5f;

    public float Hitpoints;
    public float MaxHitpoints = 50;
    public HealtbarBehaviour Healthbar;

    private GameObject pivot;
    private GameObject spawner;
    private GameObject stand;
    private float m_spawnTimeStamp = 5f;

    private void Awake()
    {
        Instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        pivot = transform.Find("PivotCanon").gameObject;
        spawner = pivot.transform.Find("Spawner").gameObject;
        Hitpoints = MaxHitpoints;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
    }

    // Update is called once per frame
    void Update()
    {
        pivot.transform.LookAt(FollowPosition);
        pivot.transform.rotation *= Quaternion.Euler(0, 90, -20);
        if (Time.time > m_spawnTimeStamp)
        {
            var spawnPosition = spawner.transform.position;
            var spawnRotation = spawner.transform.rotation;
            GameObject missle = GameObject.Instantiate(misslePrefab, spawnPosition, spawnRotation) as GameObject;
            m_spawnTimeStamp = Time.time + spawnTime;
        }

    }

    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
        Debug.Log(Hitpoints);
        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.UpdateGameState(GameManager.GameState.Victory);
        }
    }

}
