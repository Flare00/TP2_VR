using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIBehavior : MonoBehaviour
{
    private TMP_Text headText;
    private TMP_Text timerText;
    private int nbHeads = 0;
    public int objective = 4;
    public int currentTime = 60;
    public GameObject winPrefab;
    public GameObject player;
    public Transform winTeleport;
    void Start()
    {
        headText = GameObject.Find("lblBob").GetComponent<TMPro.TMP_Text>();
        timerText = GameObject.Find("lblTime").GetComponent<TMPro.TMP_Text>();
        headText.text = "BobHeads: " + 0;
        StartCoroutine(TimerTick());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddHit()
    {
        nbHeads++;
        headText.text = "BobHeads: " + nbHeads;
        if(nbHeads >= objective)
        {
            StopAllCoroutines();
            GameObject.Instantiate(winPrefab,new Vector3(0,0,1.0f), Quaternion.identity);

            player.transform.position = winTeleport.transform.position;
            player.transform.rotation = winTeleport.transform.rotation;

            StartCoroutine(WaitAndChange());
        }
    }

    IEnumerator TimerTick()
    {
        while (currentTime > 0)
        {
            // attendre une seconde
            yield return new WaitForSeconds(1);
            currentTime--;
            timerText.text = "Time :" + currentTime.ToString();
        }
        // game over
        SceneManager.LoadScene("Scene"); // le nom de votre scene
    }

    IEnumerator WaitAndChange()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("Terrain");
    }
}
