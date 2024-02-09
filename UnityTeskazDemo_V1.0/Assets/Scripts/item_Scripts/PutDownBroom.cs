using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutDownBroom : MonoBehaviour
{
    //varibles
    public GameObject inttext,item_begin, item_hand,item_broke, item_end, player;
    public AudioSource putdown;
    public bool interactable;
    public bool placed = false;
    public int itemNum;

    //when player looks at item it becomes interactable
    void OnTriggerStay(Collider other)
    {
        if (placed == false)
        {
            if (other.CompareTag("MainCamera"))
            {
                inttext.SetActive(true);
                interactable = true;
            }
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
    //if interactable is true player can place item
    void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inttext.SetActive(false);
                interactable = false;
                //pickup.Play();
                item_hand.SetActive(false);
                item_broke.SetActive(false);
                // replace other bits
                item_begin.SetActive(true);
                
                player.GetComponent<PlayerInventory>().HandFull = false;
                player.GetComponent<PlayerInventory>().itemNum = 0;
            }
        }
        if (player.GetComponent<PlayerInventory>().itemNum == 2)
        {
            item_hand.SetActive(false);
            item_broke.SetActive(true);
        }
    }
}
