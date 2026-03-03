using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool sprint;
		public bool rGrab;
		public bool lGrab;
		public bool lRelease;
		public bool rRelease;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputAction.CallbackContext value)
		{
			MoveInput(value.ReadValue<Vector2>());
		}

		public void OnLook(InputAction.CallbackContext value)
		{
			if(cursorInputForLook)
			{
                LookInput(value.ReadValue<Vector2>());
            }
		}

		public void OnRGrab(InputAction.CallbackContext value)
		{
            if (value.performed)
            {
                rGrabInput(true);
            }
            if (value.canceled)
            {
                rGrabRelease(true);
            }
        }
        public void OnLGrab(InputAction.CallbackContext value)
        {
            if (value.performed)
            {
				lGrabInput(true);
            }
            if (value.canceled)
            {
				lGrabRelease(true);
            }
        }
#endif


        public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void rGrabInput(bool newRGrabState)
		{
			rGrab = newRGrabState;
		}
        public void rGrabRelease(bool newRGrabState)
        {
            rRelease = newRGrabState;
        }
        public void lGrabInput(bool newLGrabState)
        {
            lGrab = newLGrabState;
        
		}
        public void lGrabRelease(bool newLGrabState)
        {
            lRelease = newLGrabState;
        }


        private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}