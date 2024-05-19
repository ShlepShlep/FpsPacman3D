using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Potions : MonoBehaviour
{
    public UnityEvent onDrink;
    

    void Start()
    {
        
        print("start");
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onDrink.Invoke();
            Destroy(this.gameObject);
        }
    }

    
}
