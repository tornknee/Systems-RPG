using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Collider[] items = Physics.OverlapSphere(transform.position, 2f, 1 << 7);

            Collider closestCollider;
            float closestDistance = 100;
            closestCollider = items[0];

            foreach (Collider collider in items)
            {
                if(Vector3.Distance(transform.position,collider.transform.position) < closestDistance)
                {
                    closestCollider = collider;
                    closestDistance = Vector3.Distance(transform.position, collider.transform.position);
                }                
            }
            closestCollider.GetComponent<PickUpItem>().PickedUp();
        }       
    }
}
