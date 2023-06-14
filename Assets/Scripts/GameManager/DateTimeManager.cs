using UnityEngine;
public class DateTimeManager : MonoBehaviour
{
    [SerializeField] private Material skyboxDay;
    [SerializeField] private Material skyboxNight;
    
    
    private int _gameDate = 1;
    
    [SerializeField] private int gameHour = 6;

    private float _gameMinute;

    [SerializeField] private int timeMultiplier = 2;

    private GameManager _gameManager;
    
    

    private void Start()
    {
        _gameManager = GetComponent<GameManager>();
        if (!_gameManager.GetNewGame())
        {
            _gameDate = PlayerPrefs.GetInt("Date");
        }
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
            _gameMinute += timeMultiplier * Time.deltaTime;
        }
        else
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
            
            UpdateSky();
        }
    }

    public int GetGameDate()
    {
        return _gameDate;
    }

    public int GetGameHour()
    {
        return gameHour;
    }

    public float GetGameMinute()
    {
        return _gameMinute;
    }

    void UpdateSky()
    {
        if (gameHour >= 0 && gameHour <= 5)
        {
            RenderSettings.skybox = skyboxNight;
        }
        else if (gameHour >= 6 && gameHour <= 17)
        {
            RenderSettings.skybox = skyboxDay;
        }
        else if (gameHour >= 18 && gameHour <= 23)
        {
            RenderSettings.skybox = skyboxNight;
        }
    }
}
