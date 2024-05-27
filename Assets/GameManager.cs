using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject collectText;
    public TextMeshProUGUI letterCountText;
    public Camera camera;
    public LayerMask letterLayer;
    public int count = 0;
    private static GameManager instance;
    /*
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(collectText);
            DontDestroyOnLoad(letterCountText);
            DontDestroyOnLoad(camera.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        var cam = camera.transform;
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
            DontDestroyOnLoad(this.gameObject);
        }
    }
    */
}

