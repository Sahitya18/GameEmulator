using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class gunDamage : MonoBehaviour
{
    public static gunDamage instance;
    public int headDamage, bodyDamage, legDamage;

    GameObject currentWeapon;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        currentGunDetails();   
    }

    void currentGunDetails()
    {
        currentWeapon = gunScroll.instance.currentGun;
        gunDetails();
    }

    void gunDetails()
    {
        if(currentWeapon.name== "Vandal")
        {
            
            headDamage = 160;
            bodyDamage = 40;
            legDamage = 34;

            print("vandal"+" " + headDamage + " " + bodyDamage + " " + legDamage);
        }
        if (currentWeapon.name == "Bulldog")
        {
            headDamage = 115;
            bodyDamage = 35;
            legDamage = 29;
            print("bulldog" + " " + headDamage + " " + bodyDamage + " " + legDamage);
        }
        if (currentWeapon.name == "Marshal")
        {
            headDamage = 202;
            bodyDamage = 101;
            legDamage = 85;
            print("marshal" + " " + headDamage + " " + bodyDamage + " " + legDamage);
        }

        // for guardian allow button hold set false in gunsystem
    }
}
