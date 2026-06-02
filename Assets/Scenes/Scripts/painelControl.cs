using UnityEngine;
using TMPro;

public class PainelController : MonoBehaviour
{
    public static PainelController Instance;

    public GameObject painelLegenda;
    public TextMeshProUGUI textoDialogo;

    private ObjetoCultural donoPainel = null;

    void Awake()
    {
        Instance = this;
        painelLegenda.SetActive(false);
    }

    public void MostrarTexto(string mensagem, ObjetoCultural dono)
    {
        donoPainel = dono;
        painelLegenda.SetActive(true);
        textoDialogo.text = mensagem;
    }

    public void EsconderPainel(ObjetoCultural dono)
    {
        if (donoPainel == dono)
        {
            donoPainel = null;
            painelLegenda.SetActive(false);
            textoDialogo.text = "";
        }
    }
}