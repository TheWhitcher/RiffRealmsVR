using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHitArea : MonoBehaviour
{

    private List<GameObject> noteList;

    void Start()
    {
        noteList = new List<GameObject>();
    }


    void Update()
    {
        // Not mutually exclusive if statements to read input
        // and remove oldest corresponding note (by color) from list.
    }

    private void OnTriggerExit(Collider note)
    {
        if (note.tag == "Note")
        {
            noteList.Remove(note.gameObject);
            Debug.Log("Destroy " + note.name);

            Destroy(note.gameObject);
        }

    }

    private void OnTriggerEnter(Collider note)
    {
        Debug.Log("Hit");
        if (note.tag == "Note")
        {
            noteList.Add(note.gameObject);
        }
    }
}
