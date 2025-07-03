using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public Animator transition;
    public float transitionTime;

    public static void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public static void Restart()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //IEnumerator LoadLevel(int sceneIndex)
    //{
    //    transition.SetTrigger("Start");
    //    yield return new WaitForSeconds(transitionTime);
    //}

}
