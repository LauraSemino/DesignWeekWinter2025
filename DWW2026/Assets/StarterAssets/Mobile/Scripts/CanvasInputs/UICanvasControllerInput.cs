using UnityEngine;

namespace StarterAssets
{
    public class UICanvasControllerInput : MonoBehaviour
    {

        [Header("Output")]
        public StarterAssetsInputs starterAssetsInputs;

        public void VirtualMoveInput(Vector2 virtualMoveDirection)
        {
            starterAssetsInputs.MoveInput(virtualMoveDirection);
        }

        public void VirtualRArmInput(Vector2 virtualRArmDirection)
        {
            starterAssetsInputs.rightArmInput(virtualRArmDirection);
        }
        public void VirtualLArmInput(Vector2 virtualLArmDirection)
        {
            starterAssetsInputs.leftArmInput(virtualLArmDirection);
        }

        public void VirtualLookInput(Vector2 virtualLookDirection)
        {
            starterAssetsInputs.LookInput(virtualLookDirection);
        }

        public void VirtualRGrabInput(bool virtualRGrabState)
        {
            starterAssetsInputs.rGrabInput(virtualRGrabState);
        }
        public void VirtualLGrabInput(bool virtualLGrabState)
        {
            starterAssetsInputs.lGrabInput(virtualLGrabState);
        }

    }

}
