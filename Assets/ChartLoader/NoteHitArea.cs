using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NoteHitArea : MonoBehaviour
{
    private List<GameObject> noteList;
    private GameObject greenButton;
    private GameObject redButton;
    private GameObject yellowButton;
    private GameObject blueButton;
    private GameObject orangeButton;

    void Start()
    {
        noteList = new List<GameObject>();
        
        greenButton = transform.Find("Green").gameObject;
        redButton = transform.Find("Red").gameObject;
        yellowButton = transform.Find("Yellow").gameObject;
        blueButton = transform.Find("Blue").gameObject;
        orangeButton = transform.Find("Orange").gameObject;
    }


    void Update()
    {
        ActivateAndDeactivateButton(greenButton, "GreenButton");
        ActivateAndDeactivateButton(redButton, "RedButton");
        ActivateAndDeactivateButton(yellowButton, "YellowButton");
        ActivateAndDeactivateButton(blueButton, "BlueButton");
        ActivateAndDeactivateButton(orangeButton, "OrangeButton");

        if (Input.GetButtonDown("StrumUp") || Input.GetButtonDown("StrumDown"))
        {
            StrumLogic();
        }
    }

    private void OnTriggerExit(Collider note)
    {
        if (note.tag == "Note")
        {
            noteList.Remove(note.gameObject);

            Destroy(note.gameObject, 0.5f);
            GameManager.NoteMiss();
        }
    }

    private void OnTriggerEnter(Collider note)
    {
        if (note.tag == "Note")
        {
            noteList.Add(note.gameObject);
        }
    }

    private void StrumLogic()
    {
        CheckButtonAndFindNote("Green", "GreenButton");
        CheckButtonAndFindNote("Red", "RedButton");
        CheckButtonAndFindNote("Yellow", "YellowButton");
        CheckButtonAndFindNote("Blue", "BlueButton");
        CheckButtonAndFindNote("Orange", "OrangeButton");
    }

    private void FindNote(string colour)
    {
        foreach (GameObject note in noteList)
        {
            if (note.name.Contains(colour))
            {
                note.gameObject.SetActive(false);
                noteList.Remove(note);
                GameManager.NoteHit();
                Debug.Log("Loop Done");
                return;
            }
        }
        Debug.Log("Loop Done");
        GameManager.ResetCombo();
        return;
    }

    private void CheckButtonAndFindNote(string colour, string inputButton)
    {
        if (Input.GetButton(inputButton))
        {
            FindNote(colour);
        }
    }
    private void ActivateAndDeactivateButton(GameObject button, string inputButton)
    {
        if (Input.GetButton(inputButton))
        {
            button.SetActive(true);
        }
        else
        {
            button.SetActive(false);
        }
    }
}
