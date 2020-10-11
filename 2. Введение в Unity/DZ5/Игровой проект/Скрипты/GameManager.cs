using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public AudioSource exitAudio;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource caughtAudio;

    private float _timer;
    private bool _isLose = false;
    private bool _isWin = false;
    private bool _isFinalAudioPlayed = false;

    private void Update()
    {
        if (_isWin)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (_isLose)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }

    public void LoseGame()
    {
        _isLose = true;
    }

    public void WinGame()
    {
        _isWin = true;
    }

    private void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!_isFinalAudioPlayed)
        {
            audioSource.Play();
            _isFinalAudioPlayed = true;
        }

        _timer += Time.deltaTime;
        imageCanvasGroup.alpha = _timer / fadeDuration;

        if (_timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }

    public void OpenMainDoor()
    {
        GameObject mainDoor = GameObject.FindGameObjectWithTag("MainDoor");
        mainDoor.SendMessage("Open");
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            WinGame();
        }
    }

    public bool IsGameEnded()
    {
        return _isWin || _isLose;
    }

    public static GameManager GetGameManager()
    {
        GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        return gameManagerObject.GetComponent<GameManager>();
    }
}
