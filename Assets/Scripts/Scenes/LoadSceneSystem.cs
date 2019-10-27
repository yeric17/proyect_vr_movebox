using UnityEngine;
using UnityEngine.SceneManagement;


namespace GameScene
{
    public class LoadSceneSystem : MonoBehaviour
    {
        private void Start(){
            int nextScene;
            if(PlayerPrefs.HasKey("NextScene")){
                nextScene = PlayerPrefs.GetInt("NextScene");
            }
            else {
                nextScene = SceneController.Instance.GetStartScene();
            }
            
            Debug.Log(nextScene);

            SceneController.Instance.Load(nextScene);
        }
    }
}