using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Windows;

public class startGame : MonoBehaviour
{

    public bool isLoading = false;
    public float countDown;

    public RawImage image;

    StarterAssetsInputs _input;

    void FixedUpdate()
    {

        if (isLoading == true)
        {

            countDown += Time.deltaTime / 2;

            image.color = new Color(0,0,0,countDown);

        }

        if (countDown >= 1)
        {
            SceneManager.LoadScene("LevelPlayground 1");

        }

    }
    public void NextScene(InputAction.CallbackContext context)
    {
        isLoading = true;

    }
}