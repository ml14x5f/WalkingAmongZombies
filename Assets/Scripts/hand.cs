using UnityEngine;

public class hand : MonoBehaviour {

    public GameObject fireArrowPrefab;  // a reference to the fireArrow’s prefab
    private GameObject fireArrow;   // fireArrow stores a reference to an instance of the fireArrow
    private Transform fireArrowTransform;   // The transform component of the fireArrow
    private Vector3 hitPoint;

    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>(); // get a reference to the SteamVR_TrackedObject component that’s attached to the controllers
    }

    private void ShowfireArrow(RaycastHit hit)
    {
        fireArrow.SetActive(true);  // show the fire arrow
        fireArrowTransform.position = Vector3.Lerp(hitPoint, trackedObj.transform.position, 0.5f);   // get position
        fireArrowTransform.LookAt(hitPoint);
    }

    // new
    void Start()
    {
        fireArrow = Instantiate(fireArrowPrefab);
        fireArrowTransform = fireArrow.transform;
    }

    void Update ()
    {
        if (Controller.GetPress(SteamVR_Controller.ButtonMask.Trigger))    // show when press trigger
        {
            RaycastHit hit;

            if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 100))
            {
                hitPoint = hit.point;
                ShowfireArrow(hit);
            }
        }
        else
        {
            fireArrow.SetActive(false); // disappear when release touchpad
        }
  
    }
}
