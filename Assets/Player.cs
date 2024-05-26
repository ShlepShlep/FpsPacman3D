using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public FirstPersonMovement speedComponent;
    public Jump jumpComponent;
    public Invisibility invisComponent;
    public GameObject equipText;
    public GameObject collectText;
    public TextMeshProUGUI letterCountText;
    public Camera camera;
    public LayerMask potionLayer;
    public LayerMask letterLayer;
    public int count = 0;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        speedComponent = GetComponent<FirstPersonMovement>();
        print("start");
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

        }
        


    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Teleporter"))
        {
            SceneManager.LoadScene(sceneName);
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
