using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraControlScript : MonoBehaviour
{
    Vector3 cameraPos, playerPos;
    Vector3 boundaries;
    public GameObject followCamera, player;
    public float cameraSpeed;
    
    //mapBoundaries
    public float bottomBoundarie, topBoundarie;

    public float leftBoundarie, rightBoundarie;

    public float undergroundBoundarie;

    public GameObject cameraPositon1Marker, cameraPositon2Marker;

    //menuCameraPositions

    Vector3 menuCameraPosition1, menuCameraPosition2, menuCameraPosition3;

    //Scene Name

    string sceneName;

    //Canvas

    public GameObject canvasPlay, canvasOptions, canvasQuit, canvasTitle, firsScreenPlatform;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        
        if (sceneName == "Menu")
        {
            MenuCamera();
        }
    }
    void Update()
    {
        Vector3 boundaries = followCamera.transform.position;

        boundaries.x = Mathf.Clamp(boundaries.x, leftBoundarie, rightBoundarie);

        boundaries.y = Mathf.Clamp(boundaries.y, bottomBoundarie, topBoundarie);
        //Scene detection


        playerPos = player.transform.position;


        if (sceneName == "MainHub")
        {
            StandardCamera();
        }
        if (sceneName == "Level_1")
        {
            Level1Camera();
        }
        if (sceneName == "Menu")
        {
            MenuCamera();
        }
        if(sceneName == "TestScene")
        {
            Level1Camera();
        }
    }
    void MenuCamera()
    {
        GameObject canvasPadrao = GameObject.FindWithTag("Canvas");
        UIMenu uIMenu = canvasPadrao.GetComponent<UIMenu>();
        menuCameraPosition1 = new Vector3(0, 11, -10);
        menuCameraPosition2 = new Vector3(64, 11, -10);
        menuCameraPosition3 = new Vector3(128, 11, -10);

        if (player.transform.position.x < 32)
        {
            followCamera.transform.position = menuCameraPosition1;
            canvasPlay.SetActive(uIMenu.PlayButtonOn);
            canvasOptions.SetActive(uIMenu.MenuButtonOn);
            canvasQuit.SetActive(uIMenu.QuitGameButtonOn);
            canvasTitle.SetActive(uIMenu.PlayButtonOn);
        }
        if (player.transform.position.x > 32 && player.transform.position.x < 96)
        {
            followCamera.transform.position = menuCameraPosition2;
            canvasPlay.SetActive(false);
            canvasOptions.SetActive(uIMenu.MenuButtonOn);
            canvasQuit.SetActive(false);
            canvasTitle.SetActive(false);
        }
        if (player.transform.position.x > 96)
        {
            followCamera.transform.position = menuCameraPosition3;
            canvasPlay.SetActive(false);
            canvasOptions.SetActive(uIMenu.MenuButtonOn);
            canvasQuit.SetActive(false);
            canvasTitle.SetActive(false);
            firsScreenPlatform.SetActive(true);
            
        }
    }
    void StandardCamera()
    {
        //if player is out of the ground, camera follows
        if (playerPos.y > bottomBoundarie)
        {
            followCamera.transform.position = new Vector3(player.transform.position.x, Mathf.Lerp(followCamera.transform.position.y, playerPos.y, cameraSpeed), -10);
        }

        //if the player is on the lowest part of the level, camera levels with ground
        if (playerPos.y < bottomBoundarie)
        {
            followCamera.transform.position = new Vector3(player.transform.position.x, Mathf.Lerp(followCamera.transform.position.y, bottomBoundarie, cameraSpeed), -10);
        }

        //if player is on the highest part of the level camera levels with ceiling
        if (playerPos.y > topBoundarie)
        {
            followCamera.transform.position = new Vector3(player.transform.position.x, Mathf.Lerp(followCamera.transform.position.y, topBoundarie, cameraSpeed), -10);
        }

        //locks camera on the walls when the player gets near the sides
        if (player.transform.position.x < leftBoundarie)
        {
            followCamera.transform.position = new Vector3(leftBoundarie, followCamera.transform.position.y, -10);
        }
        if (player.transform.position.x > rightBoundarie)
        {
            followCamera.transform.position = new Vector3(rightBoundarie, followCamera.transform.position.y, -10);
        }
    }
    void Level1Camera()
    {
        //if player is out of the ground, camera follows
        if (playerPos.y > bottomBoundarie)
        {
            followCamera.transform.position = new Vector3(player.transform.position.x, Mathf.Lerp(followCamera.transform.position.y, playerPos.y, cameraSpeed), -10);
        }

        //if the player is on the lowest part of the level, camera levels with ground
        if (playerPos.y < bottomBoundarie && playerPos.y > undergroundBoundarie)
        {
            followCamera.transform.position = new Vector3(player.transform.position.x, Mathf.Lerp(followCamera.transform.position.y, bottomBoundarie, cameraSpeed), -10);
        }

        if (playerPos.y < bottomBoundarie && playerPos.y < undergroundBoundarie)
        {
            followCamera.transform.position = new Vector3(player.transform.position.x, Mathf.Lerp(followCamera.transform.position.y, playerPos.y, cameraSpeed), -10);
        }

        //if player is on the highest part of the level camera levels with ceiling
        if (playerPos.y > topBoundarie)
        {
            followCamera.transform.position = new Vector3(player.transform.position.x, Mathf.Lerp(followCamera.transform.position.y, topBoundarie, cameraSpeed), -10);
        }

        //locks camera on the walls when the player gets near the sides
        if (player.transform.position.x < leftBoundarie)
        {
            followCamera.transform.position = new Vector3(leftBoundarie, followCamera.transform.position.y, -10);
        }
        if (player.transform.position.x > rightBoundarie)
        {
            followCamera.transform.position = new Vector3(rightBoundarie, followCamera.transform.position.y, -10);
        }
    }
}
