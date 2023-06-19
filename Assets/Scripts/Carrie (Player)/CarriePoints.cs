using System;
using UnityEngine;

public class CarriePoints : MonoBehaviour
{
    [SerializeField] private AudioClip hitClip;
    private int _playerPoints = 0;

    private void Start()
    {
        _playerPoints = PlayerPrefs.GetInt("Score");
    }

    public int GetPlayerPoints()
    {
        return _playerPoints;
    }

    public void AddPlayerPoints(int pointsToProvide)
    {
        _playerPoints += pointsToProvide;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            AddPlayerPoints(1);
            AudioSource.PlayClipAtPoint(hitClip, transform.position);
            Debug.Log("Player Points: " + _playerPoints);
        }
    }
}
