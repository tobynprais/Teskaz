using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class nav : MonoBehaviour
{
    public GameObject loadingScreen;
    public string sceneName;

    public Transform[] goals;
    private UnityEngine.AI.NavMeshAgent agent;
    private int whichDest = 0;
    public Transform player;
    Transform dest;
    bool huntTime;
    bool reset;
    bool inSight;
    public bool hidingspace;
    public float sightDistance = 10.0f;
    public float caught = 2.0f;
    public GameObject playCam;
    public GameObject dieCam, DeathMenu;
    AudioSource scream;
    float cooldown;
    public float cooldownTimer = 1.0f;

        
    // Start is called before the first frame update
    void Start()
    {
        scream = GetComponent<AudioSource>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.autoBraking = false;
        nextPoint();
        playCam.SetActive(true);
        dieCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (huntTime)
            Hunt();
        else
            Roam();
        if (cooldown > 0)
        {
            cooldown = cooldown - 0.1f;
        }
    }
    void nextPoint()
    {
        agent.destination = goals[whichDest].position;

        whichDest++;
        if (whichDest >= goals.Length)
            whichDest = 0;

    }
    void Roam()
    {
        if (reset)
        {
            nextPoint();
            reset = false;
        }
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            nextPoint();
        Scan();

    }
    void Hunt()
    {
        float distance = Vector3.Distance(player.position, agent.transform.position);
        if (distance < caught)
        {
            if (player.GetComponent<PlayerInventory>().itemNum == 1)
            {
                player.GetComponent<PlayerInventory>().itemNum = 2;

                cooldown = cooldownTimer;

                
            }

            

            else
            {
                if ((cooldown <= 0.0))
                {
                    if ((!hidingspace))
                    { getCaught(); }
                }
            }
        }
              
         
        if (inSight)
        {
            dest = player;
            agent.destination = dest.position;
        }
       
        
        if (!agent.pathPending && agent.remainingDistance < 0.2f)
        {
            huntTime = false; 
            
            
        }
        Scan();
    }

    void Scan()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        RaycastHit cast;
        if (Physics.Raycast(transform.position, direction, out cast, sightDistance))
            if (cast.collider.gameObject.tag == "MainCamera")
            {

                huntTime = true;
                reset = true;
                inSight = true;
            }
            else
                inSight = false;
           
        
               
            
    }
    void getCaught()
    {
        scream.Play();
        dieCam.SetActive(true);
        playCam.SetActive(false);
        Destroy(this);
        DeathMenu.SetActive(true);



    }
    
}
