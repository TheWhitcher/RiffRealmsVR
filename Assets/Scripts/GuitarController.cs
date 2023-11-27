using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
public class GuitarController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if(Gamepad.current != null)
        {
            if (Gamepad.current.buttonSouth.isPressed)
            {
                Debug.Log("GreenButton Pressed");
            }
            if (Gamepad.current.buttonWest.isPressed)
            {
                Debug.Log("RedButton Pressed");
            }
            if (Gamepad.current.buttonNorth.isPressed)
            {
                Debug.Log("YellowButton Pressed");
            }
            if (Gamepad.current.buttonEast.isPressed)
            {
                Debug.Log("BlueButton Pressed");
            }
            if (Gamepad.current.dpad.down.isPressed)
            {
                Debug.Log("OrangeButton pressed");
            }
            if (Gamepad.current.startButton.isPressed)
            {
                Debug.Log("StartButton Pressed");
            }
            if (Gamepad.current.leftShoulder.isPressed)
            {
                Debug.Log("StrumUp Pressed");
            }
            if (Gamepad.current.rightShoulder.isPressed)
            {
                Debug.Log("StrumDown Pressed");
            }
        }
    }
}