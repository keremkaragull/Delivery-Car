using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);
    [SerializeField] float pausetime;
    [SerializeField] GameObject customer;
    bool hasPackage = false;
    Rigidbody2D body;
    
    
    SpriteRenderer sprite;

    private void Start() 
    {  
        sprite = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Debug.Log("Object is collisioned");
        
    }
    private void OnTriggerEnter2D(Collider2D trigger) 
    {
        if(trigger.tag == "Package" && !hasPackage  )
        {
            Debug.Log("Object is triggered");
            hasPackage = true;
            Destroy(trigger.gameObject , pausetime);
            customer.SetActive(true);
            sprite.color = hasPackageColor;
            
        }
        if(trigger.tag == "Customer" && hasPackage)
        {
            Debug.Log("Customer is triggered");
            hasPackage = false;
            customer.SetActive(false);  
            sprite.color = noPackageColor;
        }
        
    }
}
