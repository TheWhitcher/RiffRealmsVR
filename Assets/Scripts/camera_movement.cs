using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class camera_movement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current rotation of the camera
        Vector3 currentRotation = transform.rotation.eulerAngles;

        // Update the rotation around the Y-axis
        currentRotation.y += rotationSpeed * Time.deltaTime;

        // Apply the new rotation to the camera
        transform.rotation = Quaternion.Euler(currentRotation);
    }
}
