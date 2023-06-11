using UnityEngine;

public class GameManager : MonoBehaviour
{
    private DateTimeManager _dateTimeManager;
    // Start is called before the first frame update
    void Start()
    {
        _dateTimeManager = GetComponent<DateTimeManager>();
    }
}
