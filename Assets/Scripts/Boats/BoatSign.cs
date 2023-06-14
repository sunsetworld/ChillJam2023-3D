using Unity.Mathematics;
using UnityEngine;

public class BoatSign : MonoBehaviour
{
    private bool CanRideBoat = false;
    [SerializeField] private GameObject boatObj;
    [SerializeField] private Vector3 boatOffset;

    [SerializeField] private float playerOffsetY = 100;
    private CarrieMovement _carrieMovement;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && CanRideBoat)
        {
            CanRideBoat = false;
            Vector3 newBoatPos = transform.position + boatOffset;
            GameObject newBoat = Instantiate(boatObj,newBoatPos, quaternion.identity);
            Transform playerTransform = _carrieMovement.gameObject.transform;
            playerTransform.position = newBoat.transform.position + new Vector3(0, playerOffsetY, 0);
            playerTransform.rotation = Quaternion.Euler(0, 180, 0);
            _carrieMovement.DisablePlayerMovement();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CanRideBoat = true;
            _carrieMovement = other.gameObject.GetComponent<CarrieMovement>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
    }
}
