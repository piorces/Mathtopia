using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    public AudioClip _clip;

    // Start is called before the first frame update
    public void PlayGame() {
        StartCoroutine(LoadLevel());
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }

    IEnumerator LoadLevel() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OptionGame() {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }

    public void QuitGame() {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        Application.Quit();
    }
}