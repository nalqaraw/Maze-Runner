using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public int isWalkingHash;
    public int isBackwardHash;
    public int isRunningHash;
    public GameObject key1;
    public GameObject key2;
    public GameObject key3;

    public GameObject door1;
    public GameObject door2;
    public GameObject door3;

    public float speed = 10f;

    private bool hasKey1 = false;
    private bool hasKey2 = false;
    private bool hasKey3 = false;


    public void Start()
    {

        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isBackwardHash = Animator.StringToHash("isBackward");
        isRunningHash = Animator.StringToHash("isRunning");

    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject==key1)
        {
            Debug.Log("Key1 collected");
            hasKey1 = true;
            Destroy(key1);
        }
        else if(coll.gameObject==key2)
        {
            Debug.Log("Key2 collected");
            hasKey2 = true;
            Destroy(key2);
        }
        else if(coll.gameObject==key3)
        {
            Debug.Log("Key3 collected");
            hasKey3 = true;
            Destroy(key3);
        }
}
    public void OpenDoor()
    {
        if(hasKey1)
        {
            Debug.Log("Door1 opened");
            Destroy(door1);
            hasKey1 = false;
        }
        else if(hasKey2)
        {
            Debug.Log("Door2 opened");
            Destroy(door2);
            hasKey2 = false;
        }
        else if(hasKey3)
        {
            Debug.Log("Door3 opened");
            Destroy(door3);
            hasKey3 =  false;
        }
        }

    
    //Update is called once per frame
    public void Update()
    {
        bool isWalking = animator.GetBool("isWalking");
        bool forwardPressed = Input.GetKey(KeyCode.UpArrow);
        bool isBackward = animator.GetBool("isBackward");
        bool backwardPressed = Input.GetKey(KeyCode.DownArrow);
        bool isRunning = animator.GetBool("isRunning");
        bool runningPressed = Input.GetKey(KeyCode.X);

        bool doorOpen = Input.GetKey(KeyCode.Space);
        
        transform.position += transform.forward * speed * Time.deltaTime;
 
        if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            transform.Rotate(0.0f, -45.0f, 0.0f);
        }

      
        if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            transform.Rotate(0.0f, 45.0f, 0.0f);
        }
        
        //if player pressed forward key (or up arrow)
        if(forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }
        if(!forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

        //if player pressed backward key (or down arrow)
        if(backwardPressed)
        {
            animator.SetBool(isBackwardHash, true);
        }
        if(!backwardPressed)
        {
            animator.SetBool(isBackwardHash, false);
        }

        //if player pressed the x key 
        if(runningPressed)
        {
            animator.SetBool(isRunningHash, true);
        }
        if(!runningPressed)
        {
            animator.SetBool(isRunningHash, false);
        }

        if(doorOpen)
        {
            OpenDoor();
        }
    }
}

