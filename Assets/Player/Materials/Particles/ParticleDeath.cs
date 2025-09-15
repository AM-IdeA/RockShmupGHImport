using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LaserLifetime());
    }
    IEnumerator LaserLifetime()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
