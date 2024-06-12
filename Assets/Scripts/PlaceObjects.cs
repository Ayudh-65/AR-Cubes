using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceObjects : MonoBehaviour
{
    [SerializeField]
    public GameObject spawnablePrefab;
    public ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake() 
    {
        raycastManager = GetComponent<ARRaycastManager>();
        UnityEngine.InputSystem.EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.Touch.onFingerDown += FingerDown;
    }

    void FingerDown(EnhancedTouch.Finger finger) {
        if(raycastManager.Raycast(finger.currentTouch.screenPosition, hits, TrackableType.AllTypes)) 
        {
            Instantiate(spawnablePrefab, hits[0].pose.position, hits[0].pose.rotation);
        }
    }
}
