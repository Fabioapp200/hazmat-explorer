using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public void LoadLevel(string sceneName)
    {

    }

    IEnumerable LoadScene(string sceneName)
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync(sceneName);

        while(!loading.isDone)
        {
            Debug.Log(loading.progress);
            yield return null;
        }

    }


}
