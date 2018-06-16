using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class gameoverplane : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.gameObject.GetType());
            Debug.Log(other.gameObject.name);
            Debug.Log("Error Debug");
            SceneManager.LoadScene("Game Over");
        }
    }
    /*void OnCollisionEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Error Debug");
            SceneManager.LoadScene("Game Over");
        }
    }*/
}
