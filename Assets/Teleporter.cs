using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public Player letterComponent;
    public GameObject teleporter;
    public int letterCount;
    public string sceneName;
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Teleporter"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    void Update()
    {
        if (letterComponent.count < letterCount)
        {
            teleporter.SetActive(false);
        }
        else
        {
            teleporter.SetActive(true);
        }
    }
}
