using UnityEngine;

public class GameManager : MonoBehaviour
{
    private DateTimeManager _dateTimeManager;

    [SerializeField] private bool newGame = true; 
    // Start is called before the first frame update
    void Start()
    {
        _dateTimeManager = GetComponent<DateTimeManager>();
    }

    public bool GetNewGame()
    {
        return newGame;
    }
}
