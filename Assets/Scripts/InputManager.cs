using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    //Delegate and events pairs
    public delegate void OnTapHandle();
    public static event OnTapHandle OnTap;

    //This will run when a tap is detected - callback context gives us information about
    //the tap's state.
    public void Tap(InputAction.CallbackContext tap)
    {
        if(tap.started == true)
        {
            //Debug.Log("Tap has started");
        }
        else if(tap.canceled == true)
        {
            //Debug.Log("Tap has finished");

            OnTap?.Invoke();
        }
    }
}
