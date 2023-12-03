using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMovement : MonoBehaviour
{

    [SerializeField] public float speed = 16f;

    Vector3 basePosition;

    //float x = 0;
    //float y = 0;
    //float z = 0;

    void Start()
    {
        basePosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //transform.position = basePosition + new Vector3(x,y,z);
        //z += speed;
    }

    void Update()
    {
        float scaleFactor = transform.parent.gameObject.transform.localScale.x;

        transform.Translate(Vector3.back * speed * scaleFactor * Time.deltaTime);
    }
}
