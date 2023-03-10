using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    int playerhealth;
    int headDamage, bodyDamage, legDamage;
    void Start()
    {
        playerhealth = 100;  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.H))
            playerhealth -= headDamage;
        if (Input.GetKey(KeyCode.B))
            playerhealth -= bodyDamage;
        if (Input.GetKey(KeyCode.L))
            playerhealth -= legDamage;

        if (playerhealth <= 0) { 
            //-----------> game over ------>//
        }
    }
}
