using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private Transform _center;

    public Vector3 Center => _center.position;
}