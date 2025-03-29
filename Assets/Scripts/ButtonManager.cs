using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private AudioClip audioClipClick;

    public void SceneChanger(string name)
    {
        StartCoroutine(Loader(name));
    }

    private IEnumerator Loader(string name)
    {
        SceneManager.LoadSceneAsync(name);
        yield return null;
    }

    public void AudioPlay()
    {
        if (audioClipClick != null)
            AudioSource.PlayClipAtPoint(audioClipClick, transform.position, 0.5f);
    }

    public void ExitToGame()
    {
        Application.Quit();
    }
}
