using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TeleportBack : MonoBehaviour
{
    [Tooltip("GameObject where our rocket will go back if it pass the teleportStart")]
    [SerializeField] private GameObject teleportBack;
    
    [Tooltip("GameObject to tell when going back have a longer background")]
    [SerializeField] private GameObject teleportStart;

    //our goal precision
    private float _precision = 0.2f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > teleportStart.transform.position.y )
        {
            Vector3 futurPos = teleportBack.transform.position;
            futurPos.y -= _precision;
            transform.position = futurPos;
        }
    }
}
