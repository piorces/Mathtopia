using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Level 1" || currentScene.name == "LoadingLevel")
        {
            gameObject.GetComponent<Camera>().orthographicSize = 5;
            transform.position = new Vector3(Mathf.Clamp(player.position.x, -17, 15), Math.Clamp(player.position.y, -13, 8), -10);

        }
        else if (currentScene.name == "Room")
        {
            gameObject.GetComponent<Camera>().orthographicSize = 3;
            transform.position = new Vector3(0, -1, -10);

        }
        else if (currentScene.name == "Level 2")
        {
            gameObject.GetComponent<Camera>().orthographicSize = 10;
            transform.position = new Vector3(Mathf.Clamp(player.position.x, -16, 14), Math.Clamp(player.position.y, 0, 9), -10);

        }
        

    }
}
