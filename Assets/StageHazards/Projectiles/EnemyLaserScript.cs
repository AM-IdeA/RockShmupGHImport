using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserScript : MonoBehaviour
{

    public float speed = 200f;
    public Rigidbody rb;
    public Collider laserCollide;
    public EnergyGaugeFuncs playerEnergyGaugeFuncs;
    public GameObject impactPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LaserLifetime());
        rb.velocity = transform.up * speed;
    }


    private void OnTriggerEnter(Collider laserCollide)
    {

        if (laserCollide.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Hit");
            Instantiate(impactPrefab, laserCollide.transform.position, laserCollide.transform.rotation);
            playerEnergyGaugeFuncs = laserCollide.gameObject.GetComponent<EnergyGaugeFuncs>();
            playerEnergyGaugeFuncs.energyLeft = playerEnergyGaugeFuncs.energyLeft - 20;
            //Vector3 SpawnHere = (laserCollide.transform.position);
            //Destroy(laserCollide.gameObject);
            Destroy(gameObject);
        }

    }

    IEnumerator LaserLifetime()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
