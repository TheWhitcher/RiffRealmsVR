using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMovement : MonoBehaviour
{

    [SerializeField] float speed = -0.1f;

    float x = 0;
    float y = 0;
    float z = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.position = new Vector3(x,y,z);

        z += speed;
    }
}
