using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public static PlayerPickup playerPickup;
    private void Start()
    {
        playerPickup = this;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            //pickup layer "1 << 7"
            Collider[] items = Physics.OverlapSphere(transform.position, 2f, 1 << 7);
            Collider closestCollider;
            float closestDistance = 100;
            if (items.Length>0)
            {
                closestCollider = items[0];
            }
            else
            {
                closestCollider = null;
            }


            foreach (Collider collider in items)
            {
                if(Vector3.Distance(transform.position,collider.transform.position) < closestDistance)
                {
                    closestCollider = collider;
                    closestDistance = Vector3.Distance(transform.position, collider.transform.position);
                }                
            }
            if(closestCollider != null)
            {
                closestCollider.GetComponent<PickUpItem>().PickedUp();
            }

        }       
    }
}
