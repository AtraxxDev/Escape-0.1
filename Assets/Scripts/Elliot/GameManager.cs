using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SceneTransitionManager _sceneTransitionManager;
    private int WinScene = 7;
    private int GameoverScene = 7;
    private Inventory _inventory;
    private void Awake()
    {
        // Busca el objeto con la etiqueta "InventoryObject" en la escena
        GameObject inventoryObject = GameObject.FindWithTag("InventoryObject");

        // Asegúrate de que se encontró el objeto
        if (inventoryObject != null)
        {
            // Obtiene el componente Inventory del objeto encontrado
            _inventory = inventoryObject.GetComponent<Inventory>();
        }
        else
        {
            Debug.LogError("No se encontró ningún objeto con la etiqueta 'InventoryObject' en la escena.");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void WinGame()
    {
        _sceneTransitionManager.isRoom = false;
        _sceneTransitionManager.isWin = true;
        _sceneTransitionManager.GoToSceneAsync(WinScene);
        PlayerPrefs.DeleteAll();
        gameObject.SetActive(false);
    }

    public void GameOver()
    {
        _sceneTransitionManager.isRoom = false;
        _sceneTransitionManager.isGameOver = true;
        _inventory.Key1 = false;
        _inventory.Key2 = false;
        _inventory.Key3 = false;
        _inventory.Key4 = false;
        _sceneTransitionManager.GoToSceneAsync(GameoverScene);
        PlayerPrefs.DeleteAll();
    }
}
