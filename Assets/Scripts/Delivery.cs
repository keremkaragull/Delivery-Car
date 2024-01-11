using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 0, 0, 1);
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] float destroyDelay;
    [SerializeField] List<float> xpositionList;
    [SerializeField] List<float> ypositionList;
    [SerializeField] GameObject Package;
    bool hasPackage;
    SpriteRenderer sprite;

    private void Awake() {

        TeleportMethod(Package);   
    }
    private void Start() 
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package Picked Up");
            hasPackage = true;
            other.gameObject.SetActive(false);
            sprite.color = hasPackageColor;
        }

        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package Delivered");
            hasPackage = false;
            sprite.color = noPackageColor;
            TeleportMethod(Package);
        }
    }
    void TeleportMethod(GameObject _gameObject)
    {
        _gameObject.SetActive(true);
        _gameObject.transform.localPosition = new Vector3(xpositionList[Random.Range(0,2)], ypositionList[Random.Range(0,2)], 0);
    }
}