using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public static Combat combat;
    public ParticleSystem beeBlast;
    public float damage;
    public Collider hitObject;

    // Start is called before the first frame update
    void Start()
    {
        combat = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.gameM.paused)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(BeeBlast());
            }
        }
    }

    //Plays little bee particle for 1 second and sends Attacked message
    IEnumerator BeeBlast()
    {
        beeBlast.Play(); 
        RaycastHit hitObj;
        if (Physics.Raycast(transform.position, transform.forward, out hitObj, 5f))
        {
            hitObj.transform.gameObject.SendMessage("Attacked");         
        }
        yield return new WaitForSeconds(1f);
        beeBlast.Stop();
        yield return null;
    }
}

