
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

    private Material hitMaterial;
    private float initialSpeed;
    private float initialTwirlStrength;
    private bool isSelected = false;

    // Start is called before the first frame update
    void Start()
    {
        swirlRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controllerLineRenderer != null)
        {
            Vector3 controllerPosition = controllerLineRenderer.transform.position;
            Vector3 controllerForward = controllerLineRenderer.transform.forward;

            Ray ray = new Ray(controllerPosition, controllerForward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.GetComponent<MeshRenderer>() == swirlRenderer && !isSelected)
                {
                    isSelected = true;
                    hitMaterial = swirlRenderer.material;

                    initialSpeed = hitMaterial.GetFloat("_Speed");
                    initialTwirlStrength = hitMaterial.GetFloat("_TwirlStrength");

                    hitMaterial.SetFloat("_Speed", speed);
                    hitMaterial.SetFloat("_TwirlStrength", twirlStrength);
                }
            }
            else
            {
                isSelected = false;

                if (hitMaterial != null)
                {
                    hitMaterial.SetFloat("_Speed", initialSpeed);
                    hitMaterial.SetFloat("_TwirlStrength", initialTwirlStrength);
                }
            }
        }
    }
}
