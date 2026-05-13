using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class EntrarCasa : MonoBehaviour
{
    public TextMeshProUGUI textoInteracao;
    public string nomeDaCena;

    private bool playerPerto = false;

    void Start()
    {
        textoInteracao.gameObject.SetActive(false);
    }

    void Update()
    {
        if (playerPerto && Keyboard.current.eKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(nomeDaCena);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPerto = true;

            textoInteracao.gameObject.SetActive(true);
            textoInteracao.text = "Aperte E para entrar";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPerto = false;

            textoInteracao.gameObject.SetActive(false);
        }
    }
}