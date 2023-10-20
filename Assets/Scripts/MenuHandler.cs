using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuHandler : MonoBehaviour
{
    public void DeselectButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
}
