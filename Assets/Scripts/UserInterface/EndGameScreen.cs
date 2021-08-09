using UnityEngine;
using UnityEngine.UI;

public class EndGameScreen : MonoBehaviour
{
    [SerializeField] private EndGameScreenAnimation _endGameScreenAnimation;
    [SerializeField] private Button _buttonRestart;

    private IRestart _restartObject;

    private void Awake()
    {
        _buttonRestart.onClick.AddListener(ButtonRestart_Click);
    }

    public void LaunchEndGameScreen(IRestart restartObject)
    {
        _restartObject = restartObject;

        gameObject.SetActive(true);
        _buttonRestart.gameObject.SetActive(true);

        _endGameScreenAnimation.PlayFadeToBlack();
    }

    public void ButtonRestart_Click()
    {
        _buttonRestart.gameObject.SetActive(false);
        _endGameScreenAnimation.PlayFadeToLoadingScreen(() => _restartObject.Restart() , () => gameObject.SetActive(false));
    }

}
