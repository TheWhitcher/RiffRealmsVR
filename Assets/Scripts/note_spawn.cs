using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class note_spawn : MonoBehaviour
{
    [SerializeField] Transform[] spawnNodes;
    [SerializeField] GameObject[] frets;

    private float nextSpawn = 0f;
    private int nextNode = 0;
    private float spawnRate = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn + spawnRate)
        {
            nextSpawn = Time.time;
            nextNode = Random.Range(0, spawnNodes.Length);

            GameObject newFret = Instantiate(frets[nextNode], spawnNodes[nextNode].position, Quaternion.identity);
            newFret.name = frets[nextNode].name;
            

        }
    }
}
