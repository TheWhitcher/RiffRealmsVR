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
    private bool isStrumming = false;

    private Dictionary<string, Color> buttonColors = new Dictionary<string, Color>();

    void Start()
    {
        noteList = new List<GameObject>();
        
        greenButton = transform.Find("Green").gameObject;
        redButton = transform.Find("Red").gameObject;
        yellowButton = transform.Find("Yellow").gameObject;
        blueButton = transform.Find("Blue").gameObject;
        orangeButton = transform.Find("Orange").gameObject;

        // Original Colours
        buttonColors.Add("GreenButton", greenButton.transform.Find("button").GetComponent<Renderer>().material.color);
        buttonColors.Add("RedButton", redButton.transform.Find("button").GetComponent<Renderer>().material.color);
        buttonColors.Add("YellowButton", yellowButton.transform.Find("button").GetComponent<Renderer>().material.color);
        buttonColors.Add("BlueButton", blueButton.transform.Find("button").GetComponent<Renderer>().material.color);
        buttonColors.Add("OrangeButton", orangeButton.transform.Find("button").GetComponent<Renderer>().material.color);

        // Modified Colours
        buttonColors.Add("GreenButtonPressed", greenButton.transform.Find("button").GetComponent<Renderer>().material.color * 2f);
        buttonColors.Add("RedButtonPressed", redButton.transform.Find("button").GetComponent<Renderer>().material.color * 5f);
        buttonColors.Add("YellowButtonPressed", yellowButton.transform.Find("button").GetComponent<Renderer>().material.color * 2f);
        buttonColors.Add("BlueButtonPressed", blueButton.transform.Find("button").GetComponent<Renderer>().material.color * 5f);
        buttonColors.Add("OrangeButtonPressed", orangeButton.transform.Find("button").GetComponent<Renderer>().material.color * 1.5f);
    }


    void Update()
    {
        ActivateAndDeactivateButton(greenButton, "GreenButton");
        ActivateAndDeactivateButton(redButton, "RedButton");
        ActivateAndDeactivateButton(yellowButton, "YellowButton");
        ActivateAndDeactivateButton(blueButton, "BlueButton");
        ActivateAndDeactivateButton(orangeButton, "OrangeButton");

        CheckStrum();
    }

    private void OnTriggerExit(Collider note)
    {
        if (noteList.Contains(note.gameObject) && note.tag == "Note")
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
                buttonColor.material.color = buttonColors[inputButton + "Pressed"];
            }
            else if (Input.GetButtonUp(inputButton))
            {
                buttonColor.material.color = buttonColors[inputButton];

            }
        }
    }

    private void CheckStrum()
    {
        if (Input.GetAxis("Strum") != 0 && !isStrumming || Input.GetButtonDown("KeyboardStrum") && !isStrumming)
        {
            isStrumming = true;
            StrumLogic();
        }
        else if (Input.GetAxis("Strum") == 0 || Input.GetButtonUp("KeyboardStrum"))
        {
            isStrumming = false;
        }
    }
}
