using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    private DateTimeManager _dateTimeManager;

    private CarriePoints _carriePoints;

    [SerializeField] private TMP_Text hudTxt;
    // Start is called before the first frame update
    void Start()
    {
        _dateTimeManager = FindObjectOfType<DateTimeManager>();
        _carriePoints = FindObjectOfType<CarriePoints>();

    }

    // Update is called once per frame
    void Update()
    {
        NewHUDMessage();
    }

    private void NewHUDMessage()
    {
        if (_dateTimeManager != null && _carriePoints != null)
        {
            string newHudMessage = "Minute: " + (int)_dateTimeManager.GetGameMinute()
                                              + "\nHour: " + _dateTimeManager.GetGameHour()
                                              + "\nDate: " + _dateTimeManager.GetGameDate()
                                              + "\nPoints: " + _carriePoints.GetPlayerPoints();
            hudTxt.text = newHudMessage;
        }
    }
}
