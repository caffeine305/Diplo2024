using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour {

    public void OnButtonPressed()
    {
        SceneManager.LoadScene("Options");
    }
}
