using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnTitle : MonoBehaviour {

    public void OnButtonPressed()
    {
        SceneManager.LoadScene("Title");
    }
}
