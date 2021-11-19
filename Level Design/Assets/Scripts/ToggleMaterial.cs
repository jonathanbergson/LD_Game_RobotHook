using UnityEngine;

public class ToggleMaterial : MonoBehaviour
{
    MeshRenderer mesh;
    public Material defaultMaterial;
    public Material activedMaterial;

    void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.material = defaultMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerAreaHook")
            mesh.material = activedMaterial;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "PlayerAreaHook")
            mesh.material = defaultMaterial;
    }
}
