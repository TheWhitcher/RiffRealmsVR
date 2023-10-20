using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPortals : MonoBehaviour
{

    private float maxTravel = 0.2f;
    private float minTravel = 0.2f;

    private float positionX;
    private float positionY;
    private float positionZ;
    private float distancePerFrame;
    private int direction;
    private float initialPositionY;

    private bool isDirectionUp = true;
    private float currentTime = 0f;
    private float changeCoolDown = 1f;

    // Start is called before the first frame update
    void Start()
    {
        positionX = transform.position.x;
        positionZ = transform.position.z;
        positionY = transform.position.y;
        initialPositionY = positionY;
        currentTime = Time.time;
        
        direction = Random.Range(1, 3);
        distancePerFrame = Random.Range(0.0001f, 0.0005f);
        if (direction == 1)
        {
            isDirectionUp = true;
        }
        else
        {
            isDirectionUp = false;
        }
    }

   
    // Update is called once per frame
    void Update()
    {
        if(isDirectionUp)
        {
            positionY = transform.position.y;
            transform.position = new Vector3(positionX, positionY + distancePerFrame, positionZ);
        }
        else
        {
            positionY = transform.position.y;
            transform.position = new Vector3(positionX, positionY - distancePerFrame, positionZ);
        }

        if ((transform.position.y >= initialPositionY + maxTravel || transform.position.y <= initialPositionY - minTravel) && Time.time >= changeCoolDown + currentTime)
        {
            currentTime = Time.time;

            isDirectionUp = !isDirectionUp;
        }
    }
}
