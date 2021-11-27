using UnityEngine;

public class TargetController : MonoBehaviour
{
    LineRenderer lineRenderer;
    public AnimationAndMovementController character;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        MoveTarget();
    }

    void MoveTarget()
    {
        Vector3 origin = character.transform.position;
        origin.y += 1;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.x;
        Vector3 target = Camera.main.ScreenToWorldPoint(mousePos);
        target.x = 0;

        target = origin + (target - origin).normalized * 5;
        lineRenderer.SetPosition(0, origin);
        lineRenderer.SetPosition(1, target);

        transform.LookAt(target, Vector3.forward);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "JumpPointer")
        {
            character.jumpPoint = other.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "JumpPointer")
        {
            character.jumpPoint = null;
        }
    }
}
