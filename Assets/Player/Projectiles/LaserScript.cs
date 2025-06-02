using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{

    public float speed = 100f;
    public Rigidbody rb;
    public Collider laserCollide;
    public GameObject player;
    EnergyGaugeFuncs playerEnergyGauge;
    EnemyShipScript collidedShipScript;
    public int[] scorePayouts;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LaserLifetime());
        player = GameObject.FindGameObjectWithTag("Player");
        rb.velocity = transform.up * speed;
        playerEnergyGauge = player.GetComponent<EnergyGaugeFuncs>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider laserCollide)
    {

        if (laserCollide.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Hit");
            collidedShipScript = laserCollide.gameObject.GetComponent<EnemyShipScript>();
            collidedShipScript.health--;
            Destroy(gameObject);
            playerEnergyGauge.energyLeft = playerEnergyGauge.energyLeft + 30;
            playerEnergyGauge.boostPower = playerEnergyGauge.boostPower + 20;
            /*if ((playerEnergyGauge.energyLeft + 30) > 1500)
            {
                playerEnergyGauge.energyLeft = 1500;
            }
            else
            {
                playerEnergyGauge.energyLeft = playerEnergyGauge.energyLeft + 30;
            }

            if (playerEnergyGauge.boostPower < playerEnergyGauge.boostPowerMax)
            {
                playerEnergyGauge.energyLeft = playerEnergyGauge.boostPowerMax;
            }
            else
            {
                playerEnergyGauge.boostPower = playerEnergyGauge.boostPower + 20;
            }*/
            if (collidedShipScript.health <= 0)
            {
                playerEnergyGauge.score = playerEnergyGauge.score + scorePayouts[collidedShipScript.enemyType];
                playerEnergyGauge.shipsDefeated = playerEnergyGauge.shipsDefeated + 1;
            }
        }

    }
    IEnumerator LaserLifetime()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
