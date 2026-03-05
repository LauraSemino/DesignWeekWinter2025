using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CameraToUI : MonoBehaviour
{
 
    public Camera mainCamera;
    public RenderTexture renderTexture;
    public RawImage displayImage;
    public void OnEnableRenderTexture(InputAction.CallbackContext context)
    {
       
        if (context.performed)
        {
            ToggleCameraView();
        }
    }

    private void ToggleCameraView()
    {
        if (mainCamera.targetTexture == null)
        {   
            mainCamera.targetTexture = renderTexture;
            displayImage.texture = renderTexture;
            displayImage.gameObject.SetActive(true);
        }
        else
        {
            mainCamera.targetTexture = null;
            displayImage.gameObject.SetActive(false);
        }
    }
}