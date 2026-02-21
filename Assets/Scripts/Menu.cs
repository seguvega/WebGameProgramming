using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGameSingle()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

       public void PlayGameAdditive()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);
    }
}
