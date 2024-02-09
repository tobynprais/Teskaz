using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    //varibles
    public GameObject inttext, item_start, item_hand, item_end, player;
    public AudioSource pickup;
    public bool interactable;
    public int itemNum;

    //when player looks at the item it becomes interactable
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(true);
            interactable = true;
        }
    }
    // when the player looks away the item becomes un-interactable
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
            if (Input.GetKeyDown(KeyCode.E))
            {
                //player can only pick up an item if they do not already have one in thier hand
                if (player.GetComponent<PlayerInventory>().HandFull == false)
                {
                    inttext.SetActive(false);
                    interactable = false;
                    //pickup.Play();
                    item_hand.SetActive(true);
                    item_start.SetActive(false);
                    item_end.SetActive(true);
                    player.GetComponent<PlayerInventory>().HandFull = true;
                }
            }
        }
    }
}
