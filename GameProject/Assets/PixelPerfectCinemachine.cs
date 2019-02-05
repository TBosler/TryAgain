using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelPerfectCinemachine : MonoBehaviour
{

    [SerializeField] private Camera mainCamera;
    private Cinemachine.CinemachineVirtualCamera virtualCameraScript;

    // Use this for initialization
    void Start()
    {
        GameObject vcam = GameObject.Find("CM vcam1");
        virtualCameraScript = GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        virtualCameraScript.m_Lens.OrthographicSize = mainCamera.orthographicSize;
    }
}