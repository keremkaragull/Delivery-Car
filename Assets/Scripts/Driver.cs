using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField]Rigidbody2D body;
    [SerializeField]float steerSpeed;
    [SerializeField]float moveSpeed;
    [SerializeField]float booster;
    [SerializeField]float normalspeed;
   
    private void Awake() 
    {
        body = GetComponent<Rigidbody2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Booster")
        {
            moveSpeed = booster;
        }
    }
    
     private void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = normalspeed;
    }   
    void Update()
    {    
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        
        float speedAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0, speedAmount ,0); 
    }
}
