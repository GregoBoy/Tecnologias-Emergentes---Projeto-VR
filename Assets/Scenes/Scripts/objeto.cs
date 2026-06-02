using UnityEngine;
using UnityEngine.InputSystem;

public class ObjetoCultural : MonoBehaviour
{
    [Header("Conteúdo")]
    public string nomeObjeto = "Nome do Objeto";
    [TextArea] public string descricao = "Descrição do objeto cultural...";

    [Header("Distância")]
    public float raioInteracao = 3f;

    private Transform jogador;
    private bool playerPerto = false;
    private bool descricaoAberta = false;

    void Start()
    {
        jogador = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        float distancia = Vector3.Distance(transform.position, jogador.position);
        bool estaPerto = distancia <= raioInteracao;

        // Só age quando o estado MUDA
        if (estaPerto && !playerPerto)
        {
            playerPerto = true;
            descricaoAberta = false;
            PainelController.Instance.MostrarTexto("Aperte E para ver detalhes", this);
        }
        else if (!estaPerto && playerPerto)
        {
            playerPerto = false;
            descricaoAberta = false;
            PainelController.Instance.EsconderPainel(this);
        }

        // Apertar E só quando perto
        if (playerPerto && Keyboard.current.eKey.wasPressedThisFrame)
        {
            descricaoAberta = !descricaoAberta;

            if (descricaoAberta)
                PainelController.Instance.MostrarTexto($"<b>{nomeObjeto}</b>\n\n{descricao}", this);
            else
                PainelController.Instance.MostrarTexto("Aperte E para ver detalhes", this);
        }
    }

    void OnDestroy()
    {
        if (playerPerto)
            PainelController.Instance?.EsconderPainel(this);
    }
}