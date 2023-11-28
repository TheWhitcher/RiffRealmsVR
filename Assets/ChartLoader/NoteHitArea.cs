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

    private Dictionary<string, Color> originalButtonColors = new Dictionary<string, Color>();

    void Start()
    {
        noteList = new List<GameObject>();
        
        greenButton = transform.Find("Green").gameObject;
        redButton = transform.Find("Red").gameObject;
        yellowButton = transform.Find("Yellow").gameObject;
        blueButton = transform.Find("Blue").gameObject;
        orangeButton = transform.Find("Orange").gameObject;

        originalButtonColors.Add("GreenButton", greenButton.transform.Find("button").GetComponent<Renderer>().material.color);
        originalButtonColors.Add("RedButton", redButton.transform.Find("button").GetComponent<Renderer>().material.color);
        originalButtonColors.Add("YellowButton", yellowButton.transform.Find("button").GetComponent<Renderer>().material.color);
        originalButtonColors.Add("BlueButton", blueButton.transform.Find("button").GetComponent<Renderer>().material.color);
        originalButtonColors.Add("OrangeButton", orangeButton.transform.Find("button").GetComponent<Renderer>().material.color);
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
            Debug.Log("Strumming");
            StrumLogic();
        }
    }

    private void OnTriggerExit(Collider note)
    {
        if (note != null && note.tag == "Note")
        {
            noteList.Remove(note.gameObject);

            Destroy(note.gameObject, 0.5f);
            GameManager.NoteMiss();
        }
    }

    private void OnTriggerEnter(Collider note)
    {
        if (!noteList.Contains(note.gameObject) && note.tag == "Note")
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
            if (note != null && note.name.Contains(colour))
            {
                noteList.Remove(note);
                Destroy(note);
                GameManager.NoteHit();
                return;
            }
        }

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
        Renderer buttonColor = button.transform.Find("button").GetComponent<Renderer>();
            
        if (buttonColor != null)
        {
            if (Input.GetButtonDown(inputButton))
            {
                buttonColor.material.color = buttonColor.material.color * 5f;
            }
            else if (Input.GetButtonUp(inputButton))
            {
                buttonColor.material.color = originalButtonColors[inputButton];

            }
        }
    }
}
