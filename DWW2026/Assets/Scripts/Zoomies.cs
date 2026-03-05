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
        timer += velocity * Time.deltaTime;
        if (timer > 0 && timer <= 33f)
        {
            wooshies[0].SetActive(true);
            wooshies[1].SetActive(false);
            wooshies[2].SetActive(false);
        }

    }
}
