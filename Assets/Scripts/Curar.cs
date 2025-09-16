using UnityEngine;

public class Curar : MonoBehaviour
{
    public float CantidadCura;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<PlayerController>())
        {
            other.GetComponent<PlayerController>().RecibirCura(CantidadCura);
        }
    }

}
