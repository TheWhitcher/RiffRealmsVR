using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI comboText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI multiplierText;
    [SerializeField] const int POINTS = 100;

    private int[] multiplierGoal = { 10, 20, 30, 40 };

    private bool setupState = false;
    private bool playState = false;
    private bool pauseState = false;

    private static int[] multiplier = { 1, 2, 4, 8, 10 };
    private static int currentMultiplier = 1;
    private static int comboCounter = 0;
    private static int scoreCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        setupState = true;
        currentMultiplier = multiplier[0];
        comboCounter = 0;
        scoreCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (setupState)
        {
            // TODO make sure notes and song are loaded and in sync before playstate.
            setupState = false;
            playState = true;
        }
        else if (playState)
        {
            SetMultiplier();
            UpdateUI();
        }

        if (pauseState)
        {
            // TODO handle pause state.
        }

        if (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.H))
        {
            NoteHit();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            NoteMiss();
        }
    }

    public static void NoteHit()
    {
        comboCounter++;
        scoreCounter += POINTS * currentMultiplier;
    }

    public static void NoteMiss()
    {
        comboCounter = 0;
        currentMultiplier = multiplier[0];
    }

    private void SetMultiplier()
    {
        switch (comboCounter)
        {
            case 10:
                currentMultiplier = multiplier[1];
                break;

            case 20:
                currentMultiplier = multiplier[2];
                break;

            case 30:
                currentMultiplier = multiplier[3];
                break;

            case 40:
                currentMultiplier = multiplier[4];
                break;
        }
    }

    private void UpdateUI()
    {
        comboText.text = comboCounter.ToString();
        scoreText.text = scoreCounter.ToString();
        multiplierText.text = "x" + currentMultiplier.ToString();
    }
}
