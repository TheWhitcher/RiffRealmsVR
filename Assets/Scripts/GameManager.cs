using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    // Serialized Fields
    [SerializeField] const int POINTS = 100;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject endMenu;
    [SerializeField] Animator loadingScreen;

    [Header("Game UI")]
    [SerializeField] TextMeshProUGUI comboText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI multiplierText;

    [Header("End Menu")]
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] TextMeshProUGUI finalHitText;
    [SerializeField] TextMeshProUGUI finalMissedText;
    [SerializeField] TextMeshProUGUI finalHitPercentageText;

    // Game States
    private enum GameState
    {
        Setup,
        Play,
        Ending,
        Paused
    }

    // Private Static Properties
    private static int[] multiplier = { 1, 2, 4, 8, 10 };
    private static int currentMultiplier;
    private static int comboCounter;
    private static int scoreCounter;
    private static float notesHit;
    private static float notesMissed;
    
    // Private Properties
    private GameState currentState;
    private bool pausedState;

    private static bool isSongFinished = false;
    public static bool IsSongFinished { get { return isSongFinished; } set { isSongFinished = value; } }

    // Start is called before the first frame update
    void Start()
    {
        currentMultiplier = multiplier[0];
        comboCounter = 0;
        scoreCounter = 0;
        notesHit = 0;
        notesMissed = 0;
        pausedState = false;
        IsSongFinished = false;
        currentState = GameState.Setup;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case GameState.Setup:
                SetupHandler();
                break;

            case GameState.Play:
                SetMultiplier();
                UpdateUI();
                SongFinished();
                break;

            case GameState.Ending:
                EndingHandler();
                break;

            case GameState.Paused:
                PauseHandler();
                break;
        }

        // Test inputs
        if(Gamepad.current != null)
        {
            if (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.H) || Gamepad.current.buttonSouth.isPressed)
            {
                NoteHit();
            }

            if (Input.GetKeyDown(KeyCode.F) || Gamepad.current.leftShoulder.isPressed)
            {
                NoteMiss();
            }

            if (Input.GetKeyDown(KeyCode.S) || Gamepad.current.rightShoulder.isPressed)
            {
                ResetCombo();
            }

            if (Input.GetKeyDown(KeyCode.Escape) || Gamepad.current.startButton.isPressed) 
            {
                pausedState = !pausedState;

                if (pausedState)
                {
                    currentState = GameState.Paused;
                }
                else
                {
                    currentState = GameState.Play;
                    PauseHandler();
                }
            }

            if (Input.GetKeyDown(KeyCode.Q) || Gamepad.current.selectButton.isPressed)
            {
                IsSongFinished = true;
            }
        }
    }

    // Use on successful note hit. (Player strums with correct notes pressed)
    public static void NoteHit()
    {
        comboCounter++;
        scoreCounter += POINTS * currentMultiplier;
        notesHit++;
    }

    // Use when a note reaches the end of the hit area
    public static void NoteMiss()
    {
        notesMissed++;
        ResetCombo();
    }

    // Use on a bad strum. (Player strums with incorrect notes pressed) 
    public static void ResetCombo()
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

    private void SetupHandler()
    {
        AnimatorStateInfo stateInfo = loadingScreen.GetCurrentAnimatorStateInfo(0);

        if(stateInfo.normalizedTime >= 1.0f)
        {
            currentState = GameState.Play;
        }
    }

    private void EndingHandler()
    {
        float totalNotes = notesHit + notesMissed;
        float hitPercentage = 0;
        
        if (totalNotes > 0)
        {
            hitPercentage = math.round((notesHit / totalNotes) * 100);
        
            if (float.IsNaN(hitPercentage))
            {
                hitPercentage = 0;
            }
        }

        endMenu.SetActive(true);
        finalScoreText.text = scoreCounter.ToString();
        finalHitText.text = notesHit.ToString();
        finalMissedText.text = notesMissed.ToString();
        finalHitPercentageText.text = hitPercentage.ToString() + "%";
    }

    private void PauseHandler()
    {
        if (pausedState)
        {
            // Paused
            pauseMenu.SetActive(true);
        }
        else
        {
            // UnPaused
            pauseMenu.SetActive(false);
        }
    }

    public void CloseClicked()
    {
        currentState = GameState.Paused;
        pausedState = !pausedState;
    }
    
    private void SongFinished()
    {
        if (isSongFinished)
        {
            currentState = GameState.Ending;
        }
    }
}
