using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public void OnButtonPressed()
    {
        SceneManager.LoadScene("Stage1");
    }
}
