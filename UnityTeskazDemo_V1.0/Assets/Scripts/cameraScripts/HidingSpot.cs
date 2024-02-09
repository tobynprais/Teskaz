using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSpot : MonoBehaviour
{
    //varibles
    public GameObject beast,inttext, player, hideCamera,playerCamera,hidetext;
    public AudioSource hide;
    public bool interactable;
    public bool hiding = false;

    //when player looks at the hiding spot it becomes interactable
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(true);
            interactable = true;
            
        }
    }

    // when the player looks away the hiding spot becomes un-interactable
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(false);
            interactable = false;
            
        }

    }
    //if interactable is true player can pick up item
    void Update()
    {
        if (interactable == true)
        {
            if (hiding == false)
            {

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable = false;
                    inttext.SetActive(false);
                    //hide.Play();
                    hideCamera.SetActive(true);
                    playerCamera.SetActive(false);
                    player.SetActive(false);
                    hiding = true;
                    beast.GetComponent<nav>().hidingspace = true;
                }
            }
        }
        if (interactable == false)
            {
            if (hiding == true)
            {
                hidetext.SetActive(true);
                if (Input.GetKeyDown(KeyCode.H))
                {
                    //hide.Play();
                    hideCamera.SetActive(false);
                    playerCamera.SetActive(true);
                    player.SetActive(true);
                    hiding = false;
                    hidetext.SetActive(false);
                    beast.GetComponent<nav>().hidingspace = false;

                }
               
            }
        }

    }
}
