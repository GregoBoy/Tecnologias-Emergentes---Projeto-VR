using UnityEngine;

public class PortalAnimacao : MonoBehaviour
{
    public float velocidade = 2f;
    public float tamanhoMin = 0.8f;
    public float tamanhoMax = 1.2f;

    private Vector3 escalaOriginal;

    void Start()
    {
        escalaOriginal = transform.localScale;
    }

    void Update()
    {
        float pulso = Mathf.PingPong(Time.time * velocidade, 1f);
        float escala = Mathf.Lerp(tamanhoMin, tamanhoMax, pulso);
        transform.localScale = escalaOriginal * escala;
    }
}