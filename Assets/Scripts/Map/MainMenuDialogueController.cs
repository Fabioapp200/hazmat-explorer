using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuDialogueController : MonoBehaviour
{
    public GameObject player;

    public GameObject firstScenePlatform;

    public  bool firstPlatformToggle;

    void Start()
    {
        firstScenePlatform.SetActive(false);
    }

    private void Update()
    {
        if (firstPlatformToggle)
        {
            firstScenePlatform.SetActive(true);
        }
        else
        {
            firstScenePlatform.SetActive(false);
        }
    }


}
