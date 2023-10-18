using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttons_testing : MonoBehaviour
{
    [SerializeField] private Transform[] frets;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //// loop through all available buttons
        //for (int i = 0; i < input.touchcount; i++)
        //{
        //    if (input.gettouch(i).phase == touchphase.began)
        //    {
        //        debug.log("button pressed: " + input.gettouch(i).fingerid);
        //    }
        //}
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("yes");
        }
    }
}
