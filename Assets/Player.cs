using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public FirstPersonMovement speedComponent;
    // Start is called before the first frame update
    void Start()
    {
        speedComponent = GetComponent<FirstPersonMovement>();
    }

    public void Speed()
    {
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
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
}
