using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderHandler : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject deathFX;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("ReLoad", levelLoadDelay);
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
    }

    private void ReLoad()
    {
        SceneManager.LoadScene(1);
    }
}
