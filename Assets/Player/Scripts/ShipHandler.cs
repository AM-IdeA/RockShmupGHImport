using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHandler : MonoBehaviour
{
    Vector3 posInput;
    Vector3 rotInput;
    public Rigidbody shipRb;

    bool accelerating = true;
    bool boosting;
    bool braking = false;
    float speed = 200;

    EnergyGaugeFuncs energyGaugeFuncs;

    public void Start()
    {
        energyGaugeFuncs = GetComponent<EnergyGaugeFuncs>();
        shipRb = GetComponent<Rigidbody>();
        shipRb.AddForce(0, 0, 100);
    }

    /*private int Rigidbody()
    {
        throw new NotImplementedException();
    }*/

    public void MoveInput(Vector3 move, Vector3 rotate, bool accelerate, bool boost, bool brake)
    {
        posInput = move;
        rotInput = rotate;
        accelerating = accelerate;
        boosting = boost;
        braking = brake;

        Movement();
    }

    void Movement()
    {
        /*if (accelerating)
        {
            speed = 150;
            shipRb.drag = 10;
        }*/

        if (boosting)
        {
            BoostMode();

        }

        /*if (braking)
        {
            speed = 0;
            shipRb.drag = 0;

        }*/

        else
        {
            speed = 150;
            shipRb.drag = 10;
            //shipRb.AddForce(0, 0, 0);
            //speed = 0;
            //shipRb.drag = 0;
        }

        shipRb.AddRelativeForce(posInput * speed);
        shipRb.AddRelativeTorque(rotInput);
    }

    void BoostMode()
    {
        if (energyGaugeFuncs.boostPower > 0)
            {
            speed = 300;
            shipRb.drag = 5;
            energyGaugeFuncs.boostPower--;
            //boostCollider.enabled = true;

            }
    }

    //usar raycast para spawnear a los enemigos??
}
