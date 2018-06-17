using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class gameoverplane : MonoBehaviour
{
    public GameObject player;
    public float killHeight;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y <= killHeight)
        {
            Debug.Log(" *- " + player.transform.position);

            Debug.Log("Error Debug");
            SceneManager.LoadScene("Game Over");
        }
    }
    /*
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.gameObject.GetType());
            Debug.Log(other.gameObject.name);
            
        }
    }
    */
    /*void OnCollisionEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Error Debug");
            SceneManager.LoadScene("Game Over");
        }
    }*/
}
