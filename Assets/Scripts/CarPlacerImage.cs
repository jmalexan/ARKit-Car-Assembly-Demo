using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CarPlacerImage : MonoBehaviour
{

    private bool hasTouched = false;

    public GameObject prefab = null;

    private GameObject display = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ARRaycastManager raycaster = gameObject.GetComponent<ARRaycastManager>();
        if (Input.touchCount > 0 && !hasTouched)
        {
            hasTouched = true;
            List<ARRaycastHit> hits = new List<ARRaycastHit>();

            raycaster.Raycast(Input.GetTouch(0).position, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinBounds);

            if (this.display == null) {
                this.display = Instantiate(prefab, hits[0].pose.position, hits[0].pose.rotation);
            } else {
                this.display.transform.position = hits[0].pose.position;
                this.display.transform.rotation = hits[0].pose.rotation;
            }

        }
        else if (Input.touchCount == 0)
        {
            hasTouched = false;
        }
    }
}
