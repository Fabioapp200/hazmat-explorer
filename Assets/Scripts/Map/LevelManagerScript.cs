using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour
{
    
    public GameObject player;

    public GameObject currentLevelSpawner;

    void Start()
    {
         Scene currentScene = SceneManager.GetActiveScene ();
 
         string sceneName = currentScene.name;
 
         if (sceneName == "Level_1") 
         {
             player.transform.position = currentLevelSpawner.transform.position;
         }
         else if (sceneName == "Example 2")
         {
             // Do something...
         } 
    }

    
    void Update()
    {
        
    }
}
