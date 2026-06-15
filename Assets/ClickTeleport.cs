using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickTeleport : NetworkBehaviour
{
    private Renderer rendererComponent;

    public override void OnNetworkSpawn()
    {
        rendererComponent = GetComponent<Renderer>();

        if (rendererComponent != null)
        {
            // Asignación de colores fija según autoridad
            if (IsOwner)
                rendererComponent.material.color = Color.blue;
            else
                rendererComponent.material.color = Color.red;
        }
    }

    void Update()
    {
        // EL DESCARTE: Si se presiona Espacio, lanzamos un mensaje a la consola de Unity
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Debug.Log($"[ClickTeleport] ¡Tecla Espacio detectada! ¿Soy el dueño de esta esfera?: {IsOwner}");

            // Si eres el dueño, la movemos
            if (IsOwner)
            {
                Vector3 posicionAleatoria = new Vector3(Random.Range(-2f, 2f), 0.5f, Random.Range(-2f, 2f));
                transform.position = posicionAleatoria;
            }
        }
    }
}