using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingtoFollow;
    void Update()
    {
        transform.position = thingtoFollow.transform.position;
    }
}
