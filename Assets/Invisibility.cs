using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour
{
    // Start is called before the first frame update
    public Renderer ren;
    public void Start()
    {
        ren = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
