using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Windows;

public class startGame : MonoBehaviour
{

    bool isLoading = false;
    float countDown = 1;

    RawImage image;

    StarterAssetsInputs _input;

    private void Update()
    {

        if (isLoading == true)
        {
            image.color = new Color(0,0,0,countDown - Time.deltaTime / 40);

        }

        if (countDown >= 0)
        {
            SceneManager.LoadScene("LevelPlayground 1");

        }

    }
    public void NextScene(InputAction.CallbackContext context)
    {
        isLoading = true;


        
    }
}