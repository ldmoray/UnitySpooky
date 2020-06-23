using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public AudioSource audioSource;

    private Vector3 movement;
    private float distance;
    private float wait = 1f;
    private bool canMove = false;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        distance = direction.magnitude;
        direction.Normalize();
        movement = direction;

        if (distance > 2f && canMove)
        {
            moveCharacter(movement);
        }
        else
        {
            canMove = false;
        }

        if (distance > 7f)
        {
            canMove = true;
        }
    }
    void moveCharacter(Vector3 direction)
    {
        transform.position = transform.position + (direction * moveSpeed * Time.deltaTime);
        wait -= Time.deltaTime;
        if (!audioSource.isPlaying && wait < 0f)
        {
            audioSource.Play();
            wait = 0.5f;
        }
    }
}
