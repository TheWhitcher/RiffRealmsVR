using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fret_movement : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    Transform target;

    private int nextNode = 0;
    private float nextMovement = 0f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find(this.gameObject.name).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextMovement + speed)
        {
            nextMovement = Time.time;
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
