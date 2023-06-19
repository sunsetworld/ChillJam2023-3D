using UnityEngine;

public class PlayerNet : MonoBehaviour
{
    [SerializeField] private Vector3 playerRespawnPos = new Vector3(0, 10, 0);

    private CarrieMovement _carrieMovement;
    // Start is called before the first frame update
    void Start()
    {
        _carrieMovement = FindObjectOfType<CarrieMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _carrieMovement.EnablePlayerMovement();
            other.gameObject.transform.position = playerRespawnPos;
        }
    }
}
