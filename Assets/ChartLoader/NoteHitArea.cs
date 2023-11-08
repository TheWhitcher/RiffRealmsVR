using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHitArea : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerExit(Collider note)
    {
        if (note.tag == "Note")
        {
            Debug.Log("Destroy " + note.name);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
    }
}
