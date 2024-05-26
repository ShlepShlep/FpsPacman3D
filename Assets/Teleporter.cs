using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public Player letterComponent;
    public GameObject teleporter;
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Teleporter"))
        {
            SceneManager.LoadScene("FinalGame");
        }
    }

    void Update()
    {
        if (letterComponent.count < 1)
        {
            teleporter.SetActive(false);
        }
        else
        {
            teleporter.SetActive(true);
        }
    }
}
