using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipScript : MonoBehaviour
{
    public float health;
    public float[] maxHealth;

    public float[] moveSpeed;
    Rigidbody enemyShipRB;
    Transform target;
    Collider enemyShipCollider;
    Vector3 moveDirection;
    public float[] bulletDelay;
    public float[] orbitDistance;

    public GameObject laserPrefab;
    public GameObject shipExplosionParticles;
    public Transform shipMuzzle;

    public int enemyType;

    private void Awake()
    {
        enemyType = Random.Range(0, 2);

        enemyShipRB = GetComponent<Rigidbody>();
        enemyShipCollider = GetComponent<Collider>();
    }


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth[enemyType];
        target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            //Vector3 angle = Mathf.Atan2(direction.x, direction.y)*Mathf.Rad2Deg;
            //enemyShipRB.rotation = angle;
           moveDirection = direction;
            gameObject.transform.forward = target.position - transform.position;
        }

        if (health <= 0)
        {
            StartCoroutine(ShipDestroyed());
        }
    }

    private void FixedUpdate()
    {
        if (target)
        {
            var distance = Vector3.Distance(transform.position, target.position);
            if (distance > orbitDistance[enemyType])
            {
                enemyShipRB.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z) * moveSpeed[enemyType];
            }
            else
            {
                enemyShipRB.velocity = new Vector3(0, 0, 0);
            }
        }
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(5f);
        while (target)
        {
            yield return new WaitForSeconds(bulletDelay[enemyType]);
            Instantiate(laserPrefab, shipMuzzle.position, shipMuzzle.rotation);
        }
    }

    IEnumerator ShipDestroyed()
    {
        Destroy(enemyShipCollider);
        Destroy(enemyShipRB);
        Destroy(shipMuzzle);
        //Instantiate(shipExplosionParticles);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

}
