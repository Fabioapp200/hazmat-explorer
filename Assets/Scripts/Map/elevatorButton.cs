using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorButton : MonoBehaviour
{
    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject elevator = GameObject.Find("Elevator1");
            elevatorScript elevatorScript = elevator.GetComponent<elevatorScript>();
            elevatorScript.isOnElevator = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
        GameObject elevator = GameObject.Find("Elevator1");
        elevatorScript elevatorScript = elevator.GetComponent<elevatorScript>();
        elevatorScript.currentText = "Press E to go up";
        elevatorScript.dialogueBox.text = elevatorScript.currentText;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            GameObject elevator = GameObject.Find("Elevator1");
            elevatorScript elevatorScript = elevator.GetComponent<elevatorScript>();
            elevatorScript.isOnElevator = false;
            elevatorScript.currentText = "";
            elevatorScript.dialogueBox.text = elevatorScript.currentText;
        }
    }
}
