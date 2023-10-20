using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] Shader portalShader;

    public void DeselectButton()
    {
        // Works but if the click is released outside the button it remains selected.
        EventSystem.current.SetSelectedGameObject(null);
    }
}
