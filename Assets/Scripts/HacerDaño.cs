using UnityEngine;

public class HacerDaño : MonoBehaviour
{
    public float CantidadDaño;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && other.GetComponent<PlayerController>())
        {
            other.GetComponent<PlayerController>().RecibirDaño(CantidadDaño);
        }
    }



}
