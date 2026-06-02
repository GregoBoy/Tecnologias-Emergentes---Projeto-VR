using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTeleporte : MonoBehaviour
{
    [Header("Configurações do Teleporte")]
    [Tooltip("Digite o nome exato da cena para onde o portal vai levar o jogador")]
    public string nomeDaNovaCena;

    private bool jogadorEstaPerto = false;

    void Update()
    {
        // Se o jogador estiver perto e apertar a tecla E, muda de cena
        if (jogadorEstaPerto && Input.GetKeyDown(KeyCode.E))
        {
            if (!string.IsNullOrEmpty(nomeDaNovaCena))
            {
                SceneManager.LoadScene(nomeDaNovaCena);
            }
            else
            {
                Debug.LogWarning("Esqueceu de digitar o nome da nova cena no Inspector do Portal!");
            }
        }
    }

    // Detecta quando o jogador entra na área do portal
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorEstaPerto = true;
            Debug.Log("Jogador chegou perto do portal. Aperte 'E' para teleportar!");
        }
    }

    // Detecta quando o jogador sai da área do portal
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorEstaPerto = false;
            Debug.Log("Jogador se afastou do portal.");
        }
    }
}