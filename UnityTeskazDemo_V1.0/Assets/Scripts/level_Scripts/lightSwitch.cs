using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class lightSwitch : MonoBehaviour
{
    //Variables
    public GameObject inttext, light;
    public bool toggle = true, interactable;
    public Renderer lightBulb;
    public Material offlight, onlight;
    public AudioSource LightSwitchSound;
    public Animator switchAnim;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
            {
            inttext.SetActive(true);
            interactable = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera")) ; 
        {
            inttext.SetActive(false);
            interactable = false;

        }




    }

    // Update is called once per frame
    void Update()
    {
        if (interactable == true)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                toggle = !toggle;
                //ligfhtSwitchSound
                switchAnim.ResetTrigger("press");
                switchAnim.SetTrigger("press");

            }
        }

            if (toggle == false)
            {
                light.SetActive(false);
                lightBulb.material = offlight;

            }
            if (toggle == true)
            {
                light.SetActive(true);
                lightBulb.material = onlight;

            }


        
    }

}
