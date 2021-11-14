using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public int speed = 110;
 
    void Update()
    {
        var angles = transform.rotation.eulerAngles;
        angles.y += Time.deltaTime * speed;
        transform.rotation = Quaternion.Euler(angles);
    }
}
