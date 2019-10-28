
using UnityEngine;
using GameScene;
using UnityEngine.SceneManagement;
public class PlayerMenuUI : MonoBehaviour
{
    [SerializeField] GameObject playerMenu = null;

    private void Update() {
        if(SceneManager.GetActiveScene().buildIndex != (int)ScenesInGame.load &&
        SceneManager.GetActiveScene().buildIndex != (int)ScenesInGame.mainMenu) {
            playerMenu.SetActive(true);
        }
        else {
            playerMenu.SetActive(false);
        }
    }

    public void Load(int scene) {
        SceneController.Instance.Load(scene);
    }
    public void Exit(){
        SceneController.Instance.Exit();
    }
}
