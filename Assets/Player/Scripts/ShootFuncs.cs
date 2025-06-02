using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFuncs : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform shipMuzzle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {
        Instantiate(laserPrefab, shipMuzzle.position, shipMuzzle.rotation);
    }



}
