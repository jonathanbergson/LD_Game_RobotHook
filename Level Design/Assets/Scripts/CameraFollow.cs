using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform character;
    Vector3 defaultPosition;

    private void Awake()
    {
        defaultPosition = transform.position;
    }

    void Update()
    {
        if (character != null)
        {
            transform.position = character.position + defaultPosition;
        }
    }
}
