using UnityEngine;

public class SceneSetup : MonoBehaviour
{
    public SceneType sceneType;

    private void Start()
    {
        SetupScene();
    }

    private void SetupScene()
    {
        GameManager gameManager = GameManager.instance;

        // Resetear todos los valores a false
        gameManager.SetIsLobby(false);
        gameManager.SetIsRoom(false);
        gameManager.SetIsWin(false);
        gameManager.SetIsGameOver(false);
        gameManager.SetIsDie(false);

        // Configurar el valor correspondiente a true según el tipo de escena
        switch (sceneType)
        {
            case SceneType.Lobby:
                gameManager.SetIsLobby(true);
                break;
            case SceneType.Room:
                gameManager.SetIsRoom(true);
                break;
            case SceneType.Win:
                gameManager.SetIsWin(true);
                break;
            case SceneType.GameOver:
                gameManager.SetIsGameOver(true);
                break;
            case SceneType.Die:
                gameManager.SetIsDie(true);
                break;
            // Agrega más casos según sea necesario

            default:
                Debug.LogWarning("Tipo de escena no reconocido: " + sceneType);
                break;
        }
    }
}

public enum SceneType
{
    Lobby,
    Room,
    Win,
    GameOver,
    Die,
    // Agrega más tipos según sea necesario
}
