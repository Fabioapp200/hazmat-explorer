using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformVerticalTranslationScript : MonoBehaviour
{
    public bool isGoingUp = true, isGoingDown;
    
    public float speed;

    public float topRange;

    public float bottomRange;

    public GameObject platform;


    Vector2 initialPlatformTransform;


    void Start()
    {
        initialPlatformTransform = new Vector2(platform.transform.position.x, platform.transform.position.y);
    }


    void Update()
    {
        if (platform.transform.position.y <= bottomRange)
        {
            isGoingUp = true;
            isGoingDown = false;
        }
        if (platform.transform.position.y >= topRange)
        {
            isGoingUp = false;
            isGoingDown = true;
        }
        if (isGoingUp)
        {
            platform.transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (isGoingDown)
        {
            platform.transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }

}
