using UnityEngine;

public class DrawTargetLine : MonoBehaviour
{
    private LineRenderer targetLine;

    private void Awake()
    {
        targetLine = GetComponent<LineRenderer>();
    }

    void Update()
    {
        Vector3 origin = transform.position;
        origin.y += 1;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.x;
        Vector3 target = Camera.main.ScreenToWorldPoint(mousePos);
        target.x = 0;

        targetLine.SetPosition(0, origin);
        targetLine.SetPosition(1, origin + (target - origin).normalized * 5);
    }
}
