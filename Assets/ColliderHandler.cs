using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
    }
}
