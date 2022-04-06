using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    
    [Tooltip("The point where the camera while zoom/unzoom depending of the y position")]
    [SerializeField] private Transform zoomLimite;
    
    [Tooltip("The point where the camera while zoom/unzoom depending of the y position")]
    [SerializeField] private Transform rocket;

    [Tooltip("How fast the camera will zoom")]
    [SerializeField] private float zoomLerp = 2f;
    [Tooltip("How far to zoom")]
    [SerializeField] private float maxZoom = 5f;
    
    [Tooltip("How fast the camera will unzoom")]
    [SerializeField] private float unzoomLerp = 0.5f;
    [Tooltip("How far to unzoom")]
    [SerializeField] private float maxUnzoom = 15f;
    

    // Update is called once per frame
    void Update()
    {
        float orthoSize = virtualCamera.m_Lens.OrthographicSize;
        
        if (rocket.position.y > zoomLimite.position.y)
        {
            orthoSize = Mathf.Lerp(orthoSize, maxUnzoom, unzoomLerp * Time.deltaTime);
        }
        else
        {
            orthoSize = Mathf.Lerp(orthoSize, maxZoom, zoomLerp * Time.deltaTime);
        }

        virtualCamera.m_Lens.OrthographicSize = orthoSize;
    }
}
