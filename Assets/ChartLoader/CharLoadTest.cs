using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChartLoader.NET.Utils;
using ChartLoader.NET.Framework;
using System.IO;

public class CharLoadTest : MonoBehaviour
{
    public static ChartReader chartReader;

    [SerializeField] string folderPath = "Assets\\ChartLoader\\Gakusaku Shiki";
    [SerializeField] float noteDistance = 0;

    Vector3 basePosition;
    float baseX;
    float baseY;
    float baseZ;

    public Transform[] notePrefabs;
    public AudioSource audioSource;
    private NoteMovement movementScript;

    // Start is called before the first frame update
    void Start()
    {
        string chartPath = folderPath + "\\notes.chart";
        //string audioPath = folderPath + "\\song.ogg";

        baseX = transform.position.x;
        baseY = transform.position.y;
        baseZ = transform.position.z;
        basePosition = transform.position;

        chartReader = new ChartReader();
        Chart newChart = chartReader.ReadChartFile(chartPath);
        Note[] expertGuitarNotes = newChart.GetNotes("ExpertSingle");

        movementScript = gameObject.GetComponent<NoteMovement>();

        SpawnNotes(expertGuitarNotes);
        audioSource.Play();
        
    }

    // Spawn all notes.
    public void SpawnNotes(Note[] notes)
    {
        foreach(Note note in notes)
        {
            SpawnNote(note);
        }
    }

    // Spawn single note.
    public void SpawnNote(Note note)
    {
        for (int i = 0; i < note.ButtonIndexes.Length; i++)
        {
            Vector3 point;

            float z = note.Seconds * movementScript.speed;

            if (note.ButtonIndexes[i] == true)
            {
                /*
                 * x = Horizontal position
                 * y = How high the notes are
                 * z = How far the notes are
                 */
                Vector3 change = new Vector3(i - 2f, 0f, z);

                point = basePosition + change;

                SpawnPrefab(notePrefabs[i], point);
            }
        }
    }

    // Spawns a prefab.
    public void SpawnPrefab(Transform prefab, Vector3 point)
    {
        Transform tmp = Instantiate(prefab);
        tmp.SetParent(transform);
        tmp.position = point;
    }

}
