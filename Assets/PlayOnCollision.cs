using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnCollision : MonoBehaviour
{
    public AudioSource audioSource;
    public bool repeatable = true;
    private bool canPlay = false;

    void OnTriggerEnter(Collider other)
    {
        if (!canPlay && other.tag == "Player" && !audioSource.isPlaying)
        {
            canPlay = !repeatable;
            audioSource.Play();
        }
    }
}
