
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEffects : MonoBehaviour
{
    MeshRenderer swirlRenderer;
    [SerializeField] float twirlStrength = 10.0f;
    [SerializeField] float scale;
    [SerializeField] float speed = 0.5f;
    [SerializeField] float disolveAmount;
    [SerializeField] LineRenderer controllerLineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        swirlRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (controllerLineRenderer != null)
        //{
        //    Vector3 controllerPosition = controllerLineRenderer.transform.position;
        //    Vector3 controllerForward = controllerLineRenderer.transform.forward;

        //    Ray ray = new Ray(controllerPosition, controllerForward);
        //    RaycastHit hit;

        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        if (hit.collider.gameObject.GetComponent<MeshRenderer>() == swirlRenderer)
        //        {
        //            Material hitMaterial = swirlRenderer.material;
        //            hitMaterial.SetFloat("_Speed", speed);
        //            hitMaterial.SetFloat("_TwirlStrength", twirlStrength);
        //        }
        //    }
        //    else
        //    {
        //        swirlRenderer.material.SetFloat("_Speed", 0.1f);
        //        swirlRenderer.material.SetFloat("_TwirlStrength", 3f);
        //    }
        //}

        // Used for testing
        Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit2;

        // Perform the raycast and check if it hits any collider
        if (Physics.Raycast(ray2, out hit2))
        {
            if (hit2.collider.gameObject.GetComponent<MeshRenderer>() == swirlRenderer) {
                Material hitMaterial = swirlRenderer.material;
                Debug.Log(twirlStrength);
                hitMaterial.SetFloat("_Speed", speed);
                hitMaterial.SetFloat("_TwirlStrength", twirlStrength);
            }
        }
        else
        {
            swirlRenderer.material.SetFloat("_Speed", 0.1f);
            swirlRenderer.material.SetFloat("_TwirlStrength", 3f);

        }
    }
}
