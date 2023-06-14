using UnityEngine;
using UnityEngine.Serialization;

public class CrabNPCMove : MonoBehaviour
{
    private CharacterController _crabController;

    [FormerlySerializedAs("NPCSpeed")] [SerializeField] private float npcSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        _crabController = GetComponent<CharacterController>();
    }
}
