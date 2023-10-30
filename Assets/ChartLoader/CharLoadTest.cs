using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChartLoader.NET.Utils;
using ChartLoader.NET.Framework;

public class CharLoadTest : MonoBehaviour
{
    public static ChartReader chartReader;

    public Transform[] notePrefabs;

    private string chartPath = "Assets\\ChartLoader\\Gakusaku Shiki\\notes.chart";

    // Start is called before the first frame update
    void Start()
    {
        chartReader = new ChartReader();
        Chart hisWorldChart = chartReader.ReadChartFile(chartPath);

        Note[] expertGuitarNotes = hisWorldChart.GetNotes("ExpertSingle");

        SpawnNotes(expertGuitarNotes);
        
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

            if (note.ButtonIndexes[i] == true)
            {
                /*
                 * x = Horizontal position
                 * y = How high the notes are
                 * z = How far the notes are
                 */
                point = new Vector3(i - 2f, 0f, note.Seconds);

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
