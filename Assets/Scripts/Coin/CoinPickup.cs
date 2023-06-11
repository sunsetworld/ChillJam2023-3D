using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] private int pointsToAdd = 1;
    private CarriePoints _playerPointScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerPointScript = other.gameObject.GetComponent<CarriePoints>();
            _playerPointScript.AddPlayerPoints(pointsToAdd);
            Destroy(this.gameObject);
        }
    }
}
