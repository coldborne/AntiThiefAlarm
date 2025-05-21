using UnityEngine;

public class DoorZone : MonoBehaviour
{
    [SerializeField] private Transform _outside;

    private Thief _thief;

    public Vector3 Outside => _outside.position;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Thief thief))
        {
            _thief = thief;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _))
        {
            _thief = null;
        }
    }

    public bool TryGetThief(out Thief thief)
    {
        thief = _thief;

        return _thief != null;
    }
}