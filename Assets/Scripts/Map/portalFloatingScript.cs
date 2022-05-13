using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalFloatingScript : MonoBehaviour
{
    public bool isGoingUp = true, isGoingDown;

    [Range(0.0f, 0.5f)]

    public float speed;

    [Range(0.0f, 0.5f)]
    public float range;



    Vector2 initialPortalTransform;


    void Start()
    {
        initialPortalTransform = new Vector2(transform.position.x, transform.position.y);
    }


    void Update()
    {
        if (transform.position.y <= initialPortalTransform.y - range)
        {
            isGoingUp = true;
            isGoingDown = false;
        }
        if (transform.position.y >= initialPortalTransform.y + range)
        {
            isGoingUp = false;
            isGoingDown = true;
        }
        if (isGoingUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (isGoingDown)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }


}
