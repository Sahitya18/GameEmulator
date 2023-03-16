using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class guns
{
    int gunNumber;
    string gunName;

    guns(int gunNumber, string gunName)
    {
        this.gunNumber = gunNumber;
        this.gunName = gunName;
    }
}

public class gunDamage : MonoBehaviour
{
    // fixed // 
    bool Knife;

    //Sidearms//
    bool Classic, Shorty, Frenzy, Ghost, Sheriff;

    // SMGs // 
    bool Stinger, Spectre, Shotguns, Bucky, Judge;

    //  Rifles //
    bool Bulldog, Guardianm, Phantom, Vandal;

    //Sniper Rifles//
    bool Marshal, Operator;

    // Machine Guns //
    bool Ares, Odin;



    private void Awake()
    {
        gunDetails();

        // head damage //

        
    }

    void gunDetails()
    {
        // head, body, legs, long range//
        string[,] gunsData = new string[5,10];
        gunsData[0, 0] = "knife";
        gunsData[1, 0] = "150";
        gunsData[2, 0] = "75";
        gunsData[3, 0] = "75";

        gunsData[0, 1] = "Bulldog";
        gunsData[1, 1] = "150";
        gunsData[2, 1] = "75";
        gunsData[3, 1] = "75";

        gunsData[0, 2] = "Guardianm";
        gunsData[1, 2] = "150";
        gunsData[2, 2] = "75";
        gunsData[3, 2] = "75";

        gunsData[0, 3] = "Phantom";
        gunsData[1, 3] = "150";
        gunsData[2, 3] = "75";
        gunsData[3, 3] = "75";

        gunsData[0, 4] = "Vandal";
        gunsData[1, 4] = "150";
        gunsData[2, 4] = "40";
        gunsData[3, 4] = "25";
    }
}
