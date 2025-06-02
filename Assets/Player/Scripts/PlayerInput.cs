using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    ShipHandler shipHandle;
    EnergyGaugeFuncs energyGaugeFuncs;
    //ShootFuncs shootFunctions;
    Vector3 moveInput;
    Vector3 rotInput;
    public bool accelerate = true;
    public bool boost = false;
    public bool brake = false;


    public GameObject laserPrefab;
    public Transform shipMuzzle;


    // Start is called before the first frame update
    void Start()
    {
        energyGaugeFuncs = GetComponent<EnergyGaugeFuncs>();
        shipHandle = GetComponent<ShipHandler>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        boost = false;
    }


    // Update is called once per frame
    void Update()
    {
        //Toma el input
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        float u = Input.GetAxisRaw("Zecil");

        float rh = Input.GetAxisRaw("Mouse X");
        float rv = Input.GetAxisRaw("Mouse Y");
        float ru = Input.GetAxisRaw("Mouse Z");

        moveInput = new Vector3(h, u, v);
        rotInput = new Vector3((-rv), (rh), (ru));

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            accelerate = !accelerate;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            brake = !brake;
        }

        if (Input.GetKey(KeyCode.V))
        {
            boost = true;
        }
        else
        {
            boost = false;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if (energyGaugeFuncs.isInGameOver)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

        }


    }

    void FixedUpdate()
    {
        //Manda el input
        shipHandle.MoveInput(moveInput, rotInput, accelerate, boost, brake);
        energyGaugeFuncs.playerInput(boost);

    }


    void Shoot()
    {
        Instantiate(laserPrefab, shipMuzzle.position, shipMuzzle.rotation);
    }

}
