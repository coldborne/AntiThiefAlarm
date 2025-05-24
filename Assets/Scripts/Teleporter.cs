using UnityEngine;

public class Concierge : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private DoorZone _doorZone;
    [SerializeField] private Room _room;

    private void OnEnable()
    {
        _door.Opened += LetIn;
        _door.Closed += Release;
    }

    private void OnDisable()
    {
        _door.Opened -= LetIn;
        _door.Closed -= Release;
    }

    private void Release()
    {
        if (HasThief(out Thief thief))
        {
            Teleport(thief, _doorZone.Outside);
        }
    }

    private void LetIn()
    {
        if (HasThief(out Thief thief))
        {
            Teleport(thief, _room.Center);
        }
    }

    private void Teleport(Thief thief, Vector3 to)
    {
        thief.transform.position = to;
    }

    private bool HasThief(out Thief thief)
    {
        return _doorZone.TryGetThief(out thief);
    }
}