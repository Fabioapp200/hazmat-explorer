using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointAndRespawn : MonoBehaviour
{
    public Vector3 currentCheckpoint;
    Vector3 levelSpawner;
    
    private void Start() {
        levelSpawner = GameObject.FindGameObjectWithTag("levelSpawner").transform.position;
        currentCheckpoint = levelSpawner;
    }
    private void Update() {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "respawn1")
        {
            currentCheckpoint = other.gameObject.transform.position;
        }
    }

}
