using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaterialPicker : MonoBehaviour
{
    public Material[] enemyTypeColor;
    public EnemyShipScript enemyShipScript;
    public Material enemyMaterial;

    // Start is called before the first frame update
    void Start()
    {
        enemyMaterial = GetComponent<MeshRenderer>().material;
        enemyShipScript = GetComponentInParent<EnemyShipScript>();
        enemyMaterial = enemyTypeColor[enemyShipScript.enemyType];

    }

}
