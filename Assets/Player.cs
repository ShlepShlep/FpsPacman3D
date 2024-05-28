using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.XR;


public class Player : MonoBehaviour
{
    public FirstPersonMovement speedComponent;
    public Jump jumpComponent;
    public Invisibility invisComponent;
    public GameObject equipText;
    public GameObject collectText;
    public GameObject equipGunText;
    public TextMeshProUGUI letterCountText;
    public Camera camera;
    public LayerMask potionLayer;
    public LayerMask letterLayer;
    public LayerMask gunLayer;
    public int count = 0;
    public string sceneName;

    Health health;
    public Weapon weapon;
    public Transform hand;
    void Start()
    {
        speedComponent = GetComponent<FirstPersonMovement>();
        print("start");
        health = GetComponent<Health>();
    }
    void Update()
    {
        var cam = camera.transform;
        var collided = Physics.Raycast(cam.position, cam.forward, out var hit, 2f, potionLayer);
        equipText.SetActive(collided);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (collided && hit.transform.gameObject.name == "melynas")
            {
                Speed();
                Destroy(hit.transform.gameObject);

            }
            if (collided && hit.transform.gameObject.name == "raudonas")
            {
                Jump();
                Destroy(hit.transform.gameObject);

            }
            if (collided && hit.transform.gameObject.name == "zalias")
            {
                SpeedSlow();
                Destroy(hit.transform.gameObject);

            }
            if (collided && hit.transform.gameObject.name == "ruzavas")
            {
                Invisibility();
                Destroy(hit.transform.gameObject);
            }





        }

        var collided0 = Physics.Raycast(cam.position, cam.forward, out var hit0, 2f, letterLayer);
        collectText.SetActive(collided0);
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (collided0 && hit0.transform.gameObject.name == "letter")
            {
                count++;
                letterCountText.text = "Letters Collected: " + count.ToString();
                Destroy(hit0.transform.gameObject);
            }
            DontDestroyOnLoad(equipText);

        }

        var collidedGun = Physics.Raycast(cam.position, cam.forward, out var hitGun, 2f, gunLayer);
        equipGunText.SetActive(collidedGun && weapon==null);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (collidedGun && hitGun.transform.gameObject.name.Contains("Gun"))
            {
                weapon = hitGun.transform.GetComponent<Weapon>();
                weapon.cam = camera;
                Grab(weapon);
            }
            else
            {
                Drop();
            }

        }
    }

    void Grab(Weapon newWeapon)
    {
        weapon = newWeapon;
        weapon.GetComponent<Rigidbody>().isKinematic = true;
        weapon.transform.position = hand.position;
        weapon.transform.rotation = hand.rotation;
        weapon.transform.parent = hand;
    }

    void Drop()
    {
        if (weapon == null) return;

        weapon.GetComponent<Rigidbody>().isKinematic = false;
        weapon.GetComponent<Rigidbody>().velocity = transform.forward * 5f;

        weapon.transform.parent = null;
        weapon = null;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Teleporter"))
        {
            SceneManager.LoadScene(sceneName);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            health.Damage(10);
        }

    }

    public void Speed()
    {
        StartCoroutine(SpeedCoroutine());
    }

    IEnumerator SpeedCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        speedComponent.speed = 15;
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(10);
        speedComponent.speed = 5;
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    public void SpeedSlow()
    {
        StartCoroutine(SpeedSlowCoroutine());
    }

    IEnumerator SpeedSlowCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        speedComponent.speed = 2;
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(10);
        speedComponent.speed = 5;
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    public void Jump()
    {
        StartCoroutine(JumpCoroutine());
    }

    IEnumerator JumpCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        jumpComponent.jumpStrength = 5;
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(10);
        jumpComponent.jumpStrength = 2;
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    public void Invisibility()
    {
        StartCoroutine(InvisibleCoroutine());
    }

    IEnumerator InvisibleCoroutine()
    {
        /*
        int invisibleLayer = LayerMask.NameToLayer("Invisibility");

        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        // Store the original culling mask
        int originalCullingMask = camera.cullingMask;

        // Create a bitmask that excludes the "Invisibility" layer
        int invertedInvisibleLayerMask = ~(1 << invisibleLayer);

        // Update the camera's culling mask to exclude the "Invisibility" layer
        camera.cullingMask &= invertedInvisibleLayerMask;

        // Wait for 4 seconds
        yield return new WaitForSeconds(4);

        // Restore the original culling mask
        camera.cullingMask = originalCullingMask;

        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        */
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        invisComponent.ren.enabled = false;
        yield return new WaitForSeconds(10);
        invisComponent.ren.enabled = true;
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        
    }
}
