using UnityEngine;

public class hand : MonoBehaviour {

    public GameObject torchPrefab;  // a reference to the torch’s prefab
    private GameObject torch;   // torch stores a reference to an instance of the torch

    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>(); // get a reference to the SteamVR_TrackedObject component that’s attached to the controllers
    }

    private void Showtorch()
    {
        torch.SetActive(true);
    }

    // new
    void Start()
    {
        torch = Instantiate(torchPrefab);
    }

    void Update ()
    {
		if (Controller.GetHairTriggerDown())
        {
            Showtorch();    // show the torch when press trigger
        }
        else
        {
            torch.SetActive(false); // disappear when release trigger
        }
  
    }
}
