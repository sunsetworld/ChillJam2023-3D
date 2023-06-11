using UnityEngine;
public class DateTimeManager : MonoBehaviour
{
    private int _gameDate = 1;
    
    [SerializeField] private int gameHour = 6;

    private int _gameMinute;

    [SerializeField] private int timeMultiplier = 2;

    private void Start()
    {
        _gameDate = PlayerPrefs.GetInt("Date");
    }

    // Update is called once per frame
    void Update()
    {
        AddToGameTime();
    }

    private void AddToGameTime()
    {
        if (_gameMinute <= 59)
        {
            _gameMinute += timeMultiplier;
        }
        else if (_gameMinute == 60)
        {
            _gameMinute = 0;
            if (gameHour + 1 == 24)
            {
                gameHour = 0;
                _gameDate += 1;
                PlayerPrefs.SetInt("Date", _gameDate);
                Debug.Log("Day " + _gameDate);
            }
            else
            {
                gameHour += 1;
            }
        }
    }

    public int GetGameDate()
    {
        return _gameDate;
    }
}
