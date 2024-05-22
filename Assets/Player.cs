using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public FirstPersonMovement speedComponent;
    public Jump jumpComponent;
    public UnityEvent onDrink;
    public GameObject equipText;
    public Camera camera;
    public LayerMask potionLayer;
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
        if (Input.GetKeyDown(KeyCode.I))
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
            //onDrink.Invoke();
            //Destroy(this.gameObject);
        }
        //if (potion == null) return;
    }
    public void Speed()
    {
        StartCoroutine(SpeedCoroutine());
    }

    IEnumerator SpeedCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        speedComponent.speed = 9;
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);
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
        yield return new WaitForSeconds(2);
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
        yield return new WaitForSeconds(4);
        jumpComponent.jumpStrength = 2;
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
