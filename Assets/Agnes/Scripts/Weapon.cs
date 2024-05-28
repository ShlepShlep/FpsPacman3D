using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//using EZCameraShake;
using TMPro;

public class Weapon : MonoBehaviour
{

    //gun stats
    public int damage;
    public int bullets;
    public int bulletsPerShot;
    public int bulletsLeft;
    public int bulletsShot;

    public float fireRate;
    public float spread;
    public float range;
    public float reloadSpeed;
    public float shotsInterval;

    public bool allowButtonHold;

    //bools
    bool isShooting;
    bool isReadyToShoot;
    bool isReloading;

    public Camera cam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask enemyLayer;

    public GameObject muzzleFlash;
    public GameObject bulletHoleGraphic;
    public TextMeshProUGUI text;

    private void Start()
    {
        bulletsLeft = bullets;
        isReadyToShoot = true;
    }
    private void Update()
    {
        PlayerInput();

        text.SetText(bulletsLeft + "/" + bullets);
    }

    private void PlayerInput()
    {
        if(allowButtonHold)
        {
            isShooting = Input.GetKey(KeyCode.Mouse0);
        }
        else
        {
            isShooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        if(Input.GetKeyDown(KeyCode.R) && bulletsLeft < bullets && !isReloading)
        {
            Reload();
        }

        if(isReadyToShoot && isShooting & !isReloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerShot;
            Shoot();
        }
    }
    private void Shoot()
    {
        isReadyToShoot = false;

        //spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //suskaiciuot direction su spread
        Vector3 direction = cam.transform.forward + new Vector3(x,y,0);

        if(Physics.Raycast(cam.transform.position, direction, out rayHit, range, enemyLayer))
        {
            Debug.Log(rayHit.collider.name);

            if (rayHit.collider.CompareTag("Enemy"))
            {
                //rayHit.collider.GetComponent<ShootingAi>().TakeDamage(damage);
            }
        }

        //CameraShaker.Instance.ShakeOnce(3f, 2f, .1f, 1f);
        Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.identity);
        Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot--;
        Invoke("ResetShot", shotsInterval);

        if(bulletsShot> 0 && bulletsLeft > 0)
        {
            Invoke("Shoot", fireRate);
        }
    }

    private void ResetShot() 
    {
        isReadyToShoot = true;
    }

    private void Reload()
    {
        isReloading = true;
        Invoke("ReloadFinished", reloadSpeed);
    }
    private void ReloadFinished()
    {
        bulletsLeft = bullets;
        isReloading = false;
    }

}
