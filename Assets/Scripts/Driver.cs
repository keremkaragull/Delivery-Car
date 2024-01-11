using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 175f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float slowSpeed = 5f;
    [SerializeField] float boostSpeed = 20f;

    void Update()
    {
        if(!Mathf.Approximately(Input.GetAxis("Vertical"), 0 ))
        {
            float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
            if (Input.GetAxis("Vertical") == 1)
            {
                transform.Rotate(0, 0, -steerAmount);
            }
            else if (Input.GetAxis("Vertical") == -1)
            {
                transform.Rotate(0, 0, steerAmount);
            }
        }
            float moveAmount = Input.GetAxis("Vertical") * moveSpeed  * Time.deltaTime;
            transform.Translate(0, moveAmount, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpeedUp" && moveSpeed != boostSpeed)
        {
            Debug.Log("Speed Up");
            moveSpeed = boostSpeed;
        }

        if (other.tag == "SlowDown" && moveSpeed != slowSpeed)
        {
            Debug.Log("Slow Down");
            moveSpeed = slowSpeed;
        }
    }
}