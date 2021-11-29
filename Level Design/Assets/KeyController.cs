using UnityEngine;

public class KeyController : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Character" && door != null)
        {
            Destroy(door);
            Destroy(gameObject);
        }
    }
}
