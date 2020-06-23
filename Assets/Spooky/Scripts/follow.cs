using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public AudioSource audioSource;
    
    private Rigidbody rb;
    private Vector3 movement;
    private float distance;
    private float wait = 1f;
    private bool canMove = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 direction = player.position - transform.position;
       //Debug.Log(direction.magnitude);
       distance = direction.magnitude;
       direction.Normalize();
       movement = direction;
    }
    private void FixedUpdate(){
      //Debug.Log(distance);
      if(distance > 2f && canMove){
        moveCharacter(movement);
      } else {
        canMove = false;
      }
      if(distance > 7f){
        canMove = true;
      }
    }
    void moveCharacter(Vector3 direction){
      rb.MovePosition(transform.position + (direction * moveSpeed * Time.deltaTime));
      wait -= Time.deltaTime;
      if (!audioSource.isPlaying && wait < 0f)
      {
        audioSource.Play();
        wait = 0.5f;
      }
    }
}
