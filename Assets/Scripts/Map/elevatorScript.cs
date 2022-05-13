using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class elevatorScript : MonoBehaviour
{
    public TextMeshProUGUI dialogueBox;
    Vector2 firstPosition, secondPosition, currentPosition;
    public float finalPosition, speed;
    public bool isOnElevator, movingUp, movingDown;
    public string currentText;

    void Start()
    {
        firstPosition = new Vector2(transform.position.x, transform.position.y);
        secondPosition = new Vector2(transform.position.x, finalPosition);
    }
    void Update()
    {
        currentPosition = new Vector2(transform.position.x, transform.position.y);
        bool elevatorInput = Input.GetKeyDown(KeyCode.E);

        if (elevatorInput && isOnElevator)
        {
            if (currentPosition.y >= firstPosition.y)
            {
                movingUp = false;
                movingDown = true;
            }
            if (currentPosition.y <= secondPosition.y)
            {
                movingUp = true;
                movingDown = false;
            }
        }
        if (movingDown)
        {
            goDown();
        }
        if (movingUp)
        {
            goUp();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isOnElevator = true;
            other.transform.SetParent(transform);

        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.SetParent(transform);

            if (currentPosition.y >= firstPosition.y)
            {
                currentText = "Press E to go down";
                dialogueBox.text = currentText;
            }
            if (currentPosition.y <= secondPosition.y)
            {
                currentText = "Press E to go up";
                dialogueBox.text = currentText;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            currentText = "";
            dialogueBox.text = currentText;
            isOnElevator = false;
            other.transform.parent = null;
        }
    }
    public void goUp()
    {
        currentText = "";
        dialogueBox.text = currentText;
        if (currentPosition != firstPosition)
        {
            transform.Translate(-Vector2.down * speed * Time.deltaTime);
            if (currentPosition.y >= firstPosition.y)
            {
                movingUp = false;
            }
        }
    }

    public void goDown()
    {
        currentText = "";
        dialogueBox.text = currentText;
        if (currentPosition != secondPosition)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            if (currentPosition.y <= secondPosition.y)
            {
                movingDown = false;
            }
        }
    }
}
