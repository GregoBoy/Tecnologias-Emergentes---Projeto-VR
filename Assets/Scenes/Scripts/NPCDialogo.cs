using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class NPCDialogo : MonoBehaviour
{
    public TextMeshProUGUI textoDialogo;
    public string[] falas = {
        "Olá! Bem-vindo!",
        "Fique à vontade para explorar.",
        "Para entrar pressione E!"
    };

    private bool playerPerto = false;
    private int indiceFala = 0;

    void Update()
    {
        if (playerPerto && Keyboard.current.eKey.wasPressedThisFrame)
        {
            textoDialogo.gameObject.SetActive(true);
            textoDialogo.text = falas[indiceFala];
            indiceFala = (indiceFala + 1) % falas.Length;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPerto = true;
            textoDialogo.gameObject.SetActive(true);
            textoDialogo.text = "Aperte E para falar";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPerto = false;
            indiceFala = 0;
            textoDialogo.gameObject.SetActive(false);
        }
    }
}