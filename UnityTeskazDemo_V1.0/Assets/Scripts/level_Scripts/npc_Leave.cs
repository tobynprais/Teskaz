using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_Leave : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("ai_leave"))
        { 
            Destroy(collision.gameObject);
        
        }



    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("ai_leave"))
        {
            Destroy(gameObject);

        }

    }


}
