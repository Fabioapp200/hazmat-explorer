using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformTranslationScript : MonoBehaviour
{
    public bool isGoingRight, isGoingLeft;

    [Range(0.0f, 10.0f)]

    public float speed;
    
    //Ranges

    public float rangeRight;
    
    public float rangeLeft;

    public GameObject platform;


    Vector2 initialPlatformTransform;

    void Start()
    {
        initialPlatformTransform = new Vector2(platform.transform.position.x, platform.transform.position.y);
    }


    void Update()
    {
        if (platform.transform.position.x <= rangeLeft)
        {
            isGoingRight = true;
            isGoingLeft = false;
        }
        if (platform.transform.position.x >= rangeRight)
        {
            isGoingRight = false;
            isGoingLeft = true;
        }
        if (isGoingRight)
        {
            platform.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (isGoingLeft)
        {
            platform.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
