using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);
    [SerializeField] float timeToDestroy = 0.1f;

    bool hasPackage = false;

    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Ouch, we hit something");
   }

    void OnTriggerEnter2D(Collider2D other) {

        // when we get the package
        if(other.tag == "Package" && !hasPackage){
            hasPackage = true;
            Destroy(other.gameObject, timeToDestroy);
            spriteRenderer.color = hasPackageColor;
            Debug.Log("Package picked up");
        }
        // when we deliver the package to the customer
        if(other.tag == "Customer" && hasPackage){
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
            Debug.Log("Delivered to Customer");
        }
   }
}
