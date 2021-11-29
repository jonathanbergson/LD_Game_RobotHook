using UnityEngine;

public class ToggleMaterial : MonoBehaviour
{
    public MeshRenderer mesh;
    public Material defaultMaterial;
    public Material activedMaterial;

    void Awake()
    {
        mesh.material = defaultMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TargetCollider")
        {
            mesh.material = activedMaterial;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "TargetCollider")
        {
            mesh.material = defaultMaterial;
        }
    }
}
