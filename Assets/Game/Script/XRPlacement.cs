using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class XRPlacement : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    private List<GameObject> spawnedPrefabs = new();
    private ARRaycastManager raycastManager;

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void ARRaycasting(Vector2 pos)
    {
        List<ARRaycastHit> hits = new();

        if (raycastManager.Raycast(pos, hits, TrackableType.PlaneEstimated))
        {
            Pose pose = hits[0].pose;
            ARInstantiate(pose.position, pose.rotation);
        }
    }

    void ARInstantiate(Vector3 pos, Quaternion rot)
    {
        var obj = Instantiate(prefab, pos, rot);
        spawnedPrefabs.Add(obj);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = touch.position;
            ARRaycasting(touchPosition);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            ARRaycasting(mousePos);
        }
    }
}
