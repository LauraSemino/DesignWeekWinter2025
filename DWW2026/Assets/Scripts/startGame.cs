using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class startGame : MonoBehaviour
{

    StarterAssetsInputs _input;

    private void Update()
    {




    }
    public void NextScene(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("LevelPlayground 1");
    }
}