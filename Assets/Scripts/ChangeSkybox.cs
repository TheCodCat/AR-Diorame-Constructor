using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;

public class ChangeSkybox : MonoBehaviour
{
    [SerializeField] private Material dayBox;
    [SerializeField] private Material nightBox;
    [SerializeField] private DirectionalLight directionalLight;

    public void DayChange(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            UnityEngine.RenderSettings.skybox = dayBox;
        }
    }
    public void NightChange(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
            UnityEngine.RenderSettings.skybox = nightBox;
    }
}
