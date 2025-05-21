using UnityEngine;

[RequireComponent(typeof(AudioListener))]
[RequireComponent(typeof(Mover))]
public class Thief : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private void OnEnable()
    {
        _inputReader.InteractionButtonPressed += Interact;
    }

    private void OnDisable()
    {
        _inputReader.InteractionButtonPressed -= Interact;
    }

    private void Interact()
    {
        float lookDistance = 1.0f;
        bool hasHit = Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, lookDistance);

        if (hasHit)
        {
            if (hit.transform.TryGetComponent(out Door door))
            {
                door.Toggle();
            }
        }
    }
}