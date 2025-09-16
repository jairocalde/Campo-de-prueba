using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float Salud = 100;
    public float SaludMaxima = 100;

    [Header("Interfaz")]
    public Image BarraSalud;
    public Text TextoSalud;
    public CanvasGroup OjosRojos;
    


    [Header("Muerto")]
    public GameObject Muerto;

    private void Update()
    {
        if (OjosRojos.alpha>0)
            {
            OjosRojos.alpha -= Time.deltaTime;
            }
        ActualizarInterfaz();
    }

    public void RecibirCura (float cura)
    {
        Salud += cura;
        
        if (Salud > SaludMaxima)
        {
            Salud = SaludMaxima;
        }

    }

        public void RecibirDaño(float daño)
    {
        Salud -= daño;
        OjosRojos.alpha = 1;

        if (Salud <= 0)
        {
            Instantiate(Muerto);
            Destroy(gameObject);
        }

    }

    void ActualizarInterfaz()
        
    {    
         BarraSalud.fillAmount = Salud / SaludMaxima;
         TextoSalud.text = "Vida+" + Salud.ToString("f0");
    }
}
