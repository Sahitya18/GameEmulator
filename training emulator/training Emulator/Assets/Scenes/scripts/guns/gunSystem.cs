using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunSystem : MonoBehaviour
{
    public static gunSystem instance;
    //Gun stats
    public int headDamage, bodyDamage, legDamage;
    float distanceBetweenPlayerAndEnemy;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;
    [SerializeField]
    GameObject enemyBody;
    [SerializeField]
    Transform muzzle;
    //GameObject enemyBody; 

    //bools 
    bool shooting, readyToShoot, reloading;
    public bool gunburst = false;
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
        instance = this;
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    private void Update()
    {
        myInput();
        //print(headDamage + " " + bodyDamage + " " + legDamage);

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

    GameObject currentWeapon;
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

            currentWeapon = gunScroll.instance.currentGun;

            // enemyBody = enemyspawn.instance.spawnedObject;
            headDamage = weaponDetails.instance.headDamage;
            bodyDamage = weaponDetails.instance.bodyDamage;
            legDamage = weaponDetails.instance.legDamage;
            distanceBetweenPlayerAndEnemy = Vector3.Distance(muzzle.transform.position, enemyBody.transform.position);

            print("distance "+distanceBetweenPlayerAndEnemy);

            //print(headDamage + " " + bodyDamage + " " + legDamage);

            if (rayHit.collider.CompareTag("enemyHead"))
            {
               // print("h1");
                damageTaking.instance.enemyHealth -= headDamage;
            }
            if (rayHit.collider.CompareTag("enemyBody"))
            {
                //print("h2");
                damageTaking.instance.enemyHealth -= bodyDamage;
            }
            if (rayHit.collider.CompareTag("enemyLeg"))
            {
                //print("h3");
                damageTaking.instance.enemyHealth -= legDamage;
            }
        }


        //Graphics
        Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot--;
       // print("bullets " + bulletsShot);

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
        Invoke("reloadFinished", reloadTime);
    }
    private void reloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
