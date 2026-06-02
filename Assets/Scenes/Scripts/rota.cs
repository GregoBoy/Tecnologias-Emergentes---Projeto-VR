using UnityEngine;

public class RotacionarObjeto : MonoBehaviour
{
    [SerializeField] private Vector3 velocidadeRotacao = new Vector3(0, 50, 0);

    void Update()
    {
        // Faz o objeto girar a cada frame baseado na velocidade definida
        transform.Rotate(velocidadeRotacao * Time.deltaTime);
    }
}