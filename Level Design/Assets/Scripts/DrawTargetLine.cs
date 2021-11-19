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

        if (Input.GetMouseButtonUp(0))
        {

            Debug.Log("LOG");
            Debug.Log(origin);
            Debug.Log(target);
            Debug.Log((target - origin));
            Debug.Log((target - origin).normalized);

            //    Debug.Log("LOG");
            //    Debug.Log(Input.mousePosition);
            //    Debug.Log(transform.position);
            //    Debug.Log(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.x)));

            //    Vector3 mousePos;
            //    mousePos = Input.mousePosition;
            //    Debug.Log("C1: " + mousePos.ToString());
            //    mousePos.z = 10;
            //    mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 1.0f));
            //    Debug.Log("C2: " + mousePos.ToString());

            //    Vector3 mouseWzPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z);
            //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(mouseWzPos);

            //    mousePos.z = 0;
            //    Debug.Log("C2: " + mousePos.ToString());

        }
    }
}
