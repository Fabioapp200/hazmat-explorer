using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class thanks_scene : MonoBehaviour
{
    public string sceneToLoad;
    Scene scene;
    private void Start()
    {
        StartCoroutine(skipThanks());
    }
    private void Update()
    {

    }
    IEnumerator skipThanks()
    {
        yield return new WaitForSeconds(2);
        yield return new WaitUntil(() => Input.anyKeyDown);
        SceneManager.LoadScene(sceneToLoad);
    }
}
