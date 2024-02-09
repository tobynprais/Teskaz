using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ai_follow : MonoBehaviour
{
   public NavMeshAgent ai;
   public Transform player;
   public Animator aiAnim;
   Vector3 dest;
   public GameObject intText,followtext,beastAi;
   public bool interactable,toggle,follow;

    //Set customer to follow player with button input
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
            interactable = false;
        }
    }


    //code to handle when npc leaves 
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
            followtext.SetActive(false);
            beastAi.SetActive(true);
        }

    }





    void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
               
                    toggle = !toggle;
                    if (toggle == true)
                    {
                        follow = true;
                        
                }

                    if (toggle == false)
                    {
                        follow = false;
                        
                    }
                    intText.SetActive(false);
                    interactable = false;
                

            }
        }

                if (follow==true)
        {
            dest = player.position;
            ai.destination = dest;
            followtext.SetActive(true);
        }

        else 
       {
            followtext.SetActive(false) ;
        }


        /*
        if (ai.remainingDistance <= ai.stoppingDistance)
        {
            aiAnim.ResetTrigger("jog");
            aiAnim.SetTrigger("idle");
        }
        else
        {
            aiAnim.ResetTrigger("idle");
            aiAnim.SetTrigger("jog");
        }
        */
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }



}
