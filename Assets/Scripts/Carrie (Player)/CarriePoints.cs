using System;
using UnityEngine;

public class CarriePoints : MonoBehaviour
{
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


}
