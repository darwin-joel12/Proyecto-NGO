using Unity.Netcode;
using UnityEngine;

public class NetworkManagerUI : MonoBehaviour
{
    private void OnGUI()
    {
        if (NetworkManager.Singleton == null)
            return;

        if (NetworkManager.Singleton.IsServer || NetworkManager.Singleton.IsClient)
            return;

        // Dibujamos el contenedor de los botones de forma segura
        GUILayout.BeginArea(new Rect(10, 10, 300, 300));

        if (GUILayout.Button("Start Host (Servidor + Jugador 1)"))
        {
            NetworkManager.Singleton.StartHost();
        }
        if (GUILayout.Button("Start Client (Jugador 2)"))
        {
            NetworkManager.Singleton.StartClient();
        }

        GUILayout.EndArea();
    }
}