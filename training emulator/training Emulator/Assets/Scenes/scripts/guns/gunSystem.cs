using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunSystem : MonoBehaviour
{
    //Gun stats
    int headDamage, bodyDamage, legDamage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    //bools 
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    //Graphics
    public GameObject muzzleFlash, bulletHoleGraphic;
    //------public CamShake camShake;
    public float camShakeMagnitude, camShakeDuration;
    //------public TextMeshProUGUI text;

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    private void Update()
    {
        myInput();
        print(headDamage + " " + bodyDamage + " " + legDamage);

    }
    private void myInput()
    {
        if (allowButtonHold)
        {
            shooting = Input.GetKey(KeyCode.Mouse0);
        }
        else
        {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) 
        { 
            reload(); 
        }

        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            shoot();
        }
    }
    private void shoot()
    {
        readyToShoot = false;

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        //RayCast
        if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);

            headDamage = gunDamage.instance.headDamage;
            bodyDamage = gunDamage.instance.bodyDamage;
            legDamage = gunDamage.instance.legDamage;

            //print(headDamage + " " + bodyDamage + " " + legDamage);

            if (rayHit.collider.CompareTag("enemyHead"))
            {
                print("h1");
                damageTaking.instance.enemyHealth -= headDamage;
            }
            if (rayHit.collider.CompareTag("enemyBody"))
            {
                print("h2");
                damageTaking.instance.enemyHealth -= bodyDamage;
            }
            if (rayHit.collider.CompareTag("enemyLeg"))
            {
                print("h3");
                damageTaking.instance.enemyHealth -= legDamage;
            }
        }


        //Graphics
        Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot--;
        print("bullets " + bulletsShot);

        Invoke("resetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
            Invoke("shoot", timeBetweenShots);
    }
    private void resetShot()
    {
        readyToShoot = true;
    }
    private void reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    private void reloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
