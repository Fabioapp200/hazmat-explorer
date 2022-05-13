using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class UIMenu : MonoBehaviour
{
    string currentScene;
    public TextMeshProUGUI dialogueBox;
    [Header("UI Elements Booleans")]
    public bool MenuButtonOn;
    public bool QuitGameButtonOn;
    public bool PlayButtonOn;
    public bool HealthBarOn;
    [Header("Game Objects References")]
    public GameObject healthBar;
    public GameObject MenuPanel;
    public GameObject MenuButton;
    public GameObject QuitGameButton;
    public GameObject PlayButton;
    public GameObject resolutionDropdown;
    public GameObject fullscreenToggle;

    [Header("Loading Screen")]
    public GameObject loadingScreen;

    public Slider loadingSlider;

    public bool canLoad = true;

    [Header("AudioSource")]
    public AudioSource UISound;

    [Header("Misc Settings")]
    public static bool gameisPaused = false;
    GameObject player;
    Animator playerAnimator;
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    int currentRefreshRate;
    public TMP_Dropdown resDropdown;
    void Start()
    {
        dialogueBox.text = "";
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = player.GetComponent<Animator>();

        /* #region  Change Screen resolution in a dropdown Menu */
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();
        currentRefreshRate = resolutions[0].refreshRate;
        List<string> resOptions = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string resOption = resolutions[i].width + "x" + resolutions[i].height + "@" + resolutions[i].refreshRate + "hz";
            resOptions.Add(resOption);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
            if (resolutions[i].refreshRate == currentRefreshRate)
            {

            }

        }
        resOptions.Add("");
        resDropdown.AddOptions(resOptions);
        resDropdown.value = currentResolutionIndex;
        resDropdown.RefreshShownValue();
        /* #endregion */

        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            Screen.fullScreen = true;
        }
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            resolutionDropdown.SetActive(false);
            fullscreenToggle.SetActive(true);
            QuitGameButtonOn = false;
        }
        MenuButton.SetActive(MenuButtonOn);
        PlayButton.SetActive(PlayButtonOn);
        QuitGameButton.SetActive(QuitGameButtonOn);
        healthBar.SetActive(HealthBarOn);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayPauseGame();
            UISFX();
        }
    }
    public void UISFX()
    {
        UISound.Play();
    }
    public void PlayPauseGame()
    {
        //Entra quando o jogo está pausado
        if (!gameisPaused)
        {
            Time.timeScale = 0.0f;
            gameisPaused = true;
            if (!MenuPanel.activeSelf)
            {
                MenuPanel.SetActive(true);
            }
            playerAnimator.SetBool("gameIsPaused", gameisPaused);
        }
        //Entra quando o jogo não está pausado
        else
        {
            Time.timeScale = 1.0f;
            if (MenuPanel.activeSelf)
            {
                MenuPanel.SetActive(false);
            }
            gameisPaused = false;
            playerAnimator.SetBool("gameIsPaused", gameisPaused);
        }
    }
    public void LoadScene(string targetScene)
    {
        canLoad = false;
        StartCoroutine(LoadSceneAsync(targetScene));
        if (gameisPaused) { PlayPauseGame(); }
    }
    IEnumerator LoadSceneAsync(string targetScene)
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync(targetScene);

        loadingScreen.SetActive(true);

        while (!loading.isDone)
        {
            float progress = Mathf.Clamp01(loading.progress / .9f);
            loadingSlider.value = progress;
            yield return null;
        }
        if (loading.isDone)
        {
            canLoad = true;
        }
    }

    public void CreditsOn()
    {
        SceneManager.LoadScene("Credits");
    }
    public void ChangeResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void FullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("mainVolumeControl", volume);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
