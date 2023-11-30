using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChartLoader.NET.Utils;
using ChartLoader.NET.Framework;
using System.IO;

public class CharLoadTest : MonoBehaviour
{
    public static ChartReader chartReader;

    [SerializeField] string songFolderName = "";

    Vector3 basePosition;
    float baseX;
    float baseY;
    float baseZ;

    public Transform[] notePrefabs;
    public AudioSource audioSource;
    //public AudioClip audioClip;
    private NoteMovement movementScript;

    // Start is called before the first frame update
    void Start()
    {
        string chartPath = Application.dataPath + "\\StreamingAssets\\" + songFolderName + "\\notes.chart";
        //string audioPath = folderPath + "\\song.ogg";

        baseX = transform.position.x;
        baseY = transform.position.y;
        baseZ = transform.position.z;
        basePosition = transform.position;

        chartReader = new ChartReader();
        Chart newChart = chartReader.ReadChartFile(chartPath);
        Note[] expertGuitarNotes = newChart.GetNotes("ExpertSingle");

        movementScript = gameObject.GetComponent<NoteMovement>();

        // Set the audio
        //LoadSong(audioPath);
        //audioSource.clip = audioClip;

        if (audioSource.clip == null)
        {
            Debug.LogError("No audio clip.");
        }

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

            float x = i - 2f;
            float y = 0f;
            float z = note.Seconds * movementScript.speed;

            if (note.ButtonIndexes[i] == true)
            {
                /*
                 * x = Horizontal position
                 * y = How high the notes are
                 * z = How far the notes are
                 */

                Vector3 change = new Vector3(i - 2f, 0f, z);

                point = basePosition - change * transform.parent.gameObject.transform.localScale.x;

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


    private void LoadAudioClipFromFile(string path)
    {
        AudioClip audioClip = null;
        WWW www = new WWW(path);
        while (!www.isDone) { }
        audioClip = www.GetAudioClip();

        Debug.Log(path);

        audioSource.clip = audioClip;
    }

    private void LoadSong(string path)
    {
        StartCoroutine(LoadSongCoroutine(path));
    }

    IEnumerator LoadSongCoroutine(string path)
    {
        AudioClip audioClip = null;
        WWW www = new WWW(path);
        yield return www;

        audioClip = www.GetAudioClip();

        Debug.Log(path);

        audioSource.clip = audioClip;
    }

}
