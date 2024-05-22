using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Potions : MonoBehaviour
{
    /*
    public UnityEvent onDrink;
    public GameObject equipText;
    public Camera camera;
    public GameObject player;
    void Start()
    {
        
        print("start");
    }
    
    void Update()
    {
        var cam = camera.transform;
        var collided = Physics.Raycast(cam.position, cam.forward, out var hit, 2f);
        equipText.SetActive(collided && !player);
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (player == null && collided)
            {
                onDrink.Invoke();
                Destroy(this.gameObject);

            }
            //onDrink.Invoke();
            //Destroy(this.gameObject);
        }
        if (player == null) return;
    }
    /*
    void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            potionPic = true;
            onDrink.Invoke();
            Destroy(this.gameObject);
        }
    }
    */



}
