using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class bobBehavior : MonoBehaviour
{
    public GameObject worldObject;
    public GameObject fx;
    private AudioSource audio;
    void Start()
    {
        audio = GameObject.Find("Audio").GetComponent<AudioSource>();
        worldObject = GameObject.Find("World");
    }
    void Update()
    {
    }
    void OnTriggerEnter(Collider other)
    { // OnCollisionEnter
        if (other.tag == "Player")
        {
            Instantiate(fx, transform.position, Quaternion.identity);
            Destroy(gameObject);
            if (audio)
            {
                audio.Play();
            }
            worldObject.SendMessage("AddHit");
        }


    }
}
