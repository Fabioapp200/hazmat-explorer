using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class portalTeleportScript : MonoBehaviour
{


    public TextMeshProUGUI dialogueBox;
    public GameObject Canvas;
    private void Start() {
        
        dialogueBox.text = "";
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Orange_Portal_1" && !UIMenu.gameisPaused)
        {
            dialogueBox.text = "Press E to enter the level.";

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log(other.tag);
            }
        }
        if (other.tag == "Cyan_Portal_1" && !UIMenu.gameisPaused)
        {
            dialogueBox.text = "Press E to enter the level.";
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Carregar próxima cena
                Debug.Log(other.tag);
            }
        }
        if (other.tag == "Green_Portal_1" && !UIMenu.gameisPaused)
        {
            dialogueBox.text = "Press E to enter the level.";
            if (Input.GetKeyDown(KeyCode.E))
            {
                UIMenu uIMenu = Canvas.GetComponent<UIMenu>();
                if(uIMenu.canLoad)
                {
                    uIMenu.LoadScene("Level_1");
                }
                Debug.Log(other.tag);
            }
        }        
        if (other.tag == "Green_Portal_Back" && !UIMenu.gameisPaused)
        {
            dialogueBox.text = "Press E to go back to the HUB.";
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("Thanks");
                Debug.Log(other.tag);
            }
        }
        if (other.tag == "Green_Portal_Menu_1" && !UIMenu.gameisPaused)
        {
            dialogueBox.text = "Press E to go to the HUB.";
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("MainHub");
                Debug.Log(other.tag);
            }
        }
        else
        {
            Scene currentScene = SceneManager.GetActiveScene();

            string sceneName = currentScene.name;

            if(sceneName == "Menu")
            {
                dialogueBox.text = "";
            }
        }
        if (other.tag == "Purple_Portal_1" && !UIMenu.gameisPaused)
        {
            dialogueBox.text = "Press E to enter the level.";
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Carregar próxima cena
                Debug.Log(other.tag);
            }
        }
        if (other.tag == "Red_Portal_1" && !UIMenu.gameisPaused)
        {
            dialogueBox.text = "Press E to enter the level.";
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Carregar próxima cena
                Debug.Log(other.tag);
            }
        }
        if (other.tag == "Silver_Portal_1" && !UIMenu.gameisPaused)
        {
            dialogueBox.text = "Press E to enter the level.";
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Carregar próxima cena
                Debug.Log(other.tag);
            }
        }
        if (other.tag == "Yellow_Portal_1" && !UIMenu.gameisPaused)
        {
            dialogueBox.text = "Press E to enter the level.";
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Carregar próxima cena
                Debug.Log(other.tag);
            }
        }
        if (other.tag == "LightBlue_Portal_1" && !UIMenu.gameisPaused)
        {
            dialogueBox.text = "Press E to enter the level.";
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Carregar próxima cena
                Debug.Log(other.tag);
            }
        }


    }
    private void OnTriggerExit2D(Collider2D other)
    {
        
            dialogueBox.text = "";
    }
}
