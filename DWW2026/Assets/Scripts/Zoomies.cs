using UnityEngine;
using UnityEngine.UI;

public class Zoomies : MonoBehaviour
{
    public GameObject[] wooshies;


    public float velocity;
    float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  

        velocity = GetComponent<Rigidbody>().linearVelocity.magnitude;
        if (velocity > 6) 
        {
            timer += velocity * Time.deltaTime * 60;
        }
        else
        {
            wooshies[0].SetActive(false);
            wooshies[1].SetActive(false);
            wooshies[2].SetActive(false);
            timer = 0;
        }

        if (timer > 0 && timer <= 33f)
        {
            wooshies[0].SetActive(true);
            wooshies[1].SetActive(false);
            wooshies[2].SetActive(false);
            wooshies[0].GetComponent<RawImage>().color = new Color(255, 255, 255, velocity/30);
        }
        if (timer > 33 && timer <= 66f)
        {
            wooshies[0].SetActive(false);
            wooshies[1].SetActive(true);
            wooshies[2].SetActive(false);
            wooshies[1].GetComponent<RawImage>().color = new Color(255, 255, 255, velocity/30);
        }
        if (timer > 66 && timer <= 99f)
        {
            wooshies[0].SetActive(false);
            wooshies[1].SetActive(false);
            wooshies[2].SetActive(true);
            wooshies[2].GetComponent<RawImage>().color = new Color(255, 255, 255, velocity/30);
        }
        if (timer >= 100)
        {
            timer = 0;
        }

    }
}
