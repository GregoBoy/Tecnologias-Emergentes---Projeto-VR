using UnityEngine;
using TMPro; // Necessário para usar o TextMeshPro

public class InteracaoObjeto : MonoBehaviour
{
    [Header("Configurações do Texto")]
    public string nomeDoObjeto;
    [TextArea(3, 10)] // Deixa o campo grande no Inspector
    public string descricaoHistorica;

    [Header("Referências da UI")]
    public GameObject painelLegenda;
    public TextMeshProUGUI textoUI;

    private bool jogadorPerto = false;
    private bool legendaAtiva = false;

    void Start()
    {
        // Garante que a UI comece fechada
        if (painelLegenda != null) painelLegenda.SetActive(false);
    }

    void Update()
    {
        // Se o jogador estiver perto e apertar a tecla E
        if (jogadorPerto && Input.GetKeyDown(KeyCode.E))
        {
            if (!legendaAtiva)
            {
                MostrarLegenda();
            }
            else
            {
                FecharLegenda();
            }
        }
    }

    void MostrarLegenda()
    {
        textoUI.text = "<b>" + nomeDoObjeto + "</b>\n\n" + descricaoHistorica;
        painelLegenda.SetActive(true);
        legendaAtiva = true;
    }

    void FecharLegenda()
    {
        painelLegenda.SetActive(false);
        legendaAtiva = false;
    }

    // Detecta quando o jogador entra na área do objeto
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
            // Opcional: Colocar um aviso na tela "Pressione E para inspecionar"
        }
    }

    // Detecta quando o jogador se afasta do objeto
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
            FecharLegenda(); // Fecha a legenda automaticamente se o jogador se afastar
        }
    }
}