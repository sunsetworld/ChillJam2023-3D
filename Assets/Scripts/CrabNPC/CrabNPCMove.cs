using UnityEngine;
public class CrabNPCMove : MonoBehaviour
{
    private CharacterController _crabController;

    [SerializeField] private float NPCSpeed = 10f;

    [SerializeField] private float minX = -1f;
    [SerializeField] private float maxX = 1f;
    [SerializeField] private float minZ = -1f;
    [SerializeField] private float maxZ = 1f;

    private Vector3 _targetArea;

    [SerializeField] private float maxTimer = 10;

    private float _timer;
    // Start is called before the first frame update
    void Start()
    {
        _crabController = GetComponent<CharacterController>();
        GetNewTargetArea();
        _timer = maxTimer;
    }

    private void GetNewTargetArea()
    {
        float newX = Random.Range(minX, maxX);
        float newZ = Random.Range(minZ, maxZ);
        _targetArea = new Vector3(newX, 0, maxZ);
    }

    private void Update()
    {
        _crabController.Move(_targetArea * (NPCSpeed * Time.deltaTime));
        GetNewTargetArea();
    }
}
