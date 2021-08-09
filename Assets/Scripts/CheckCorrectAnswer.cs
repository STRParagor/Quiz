using UnityEngine;
using UnityEngine.Events;

public class CheckCorrectAnswer : MonoBehaviour, ICorrectAnswer
{
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private ParticleSystem _winParticle;

    public UnityEvent DisableInputEvent { get => _levelGenerator.DisableInputEvent; }

    public void OnBeforeAnimCorrectAnswer()
    {
        _levelGenerator.DisableInputEvent.Invoke();
        _winParticle.Play();
    }

    public void OnAfterAnimCorrectAnswer()
    {
        NextLevel();
    }

    private void NextLevel()
    {
        _levelGenerator.CurrentLevel++;
        if (_levelGenerator.CurrentLevel >= _levelGenerator.CardsCountPerLevel.Length)
        {
            EndGame();
            return;
        }

        _levelGenerator.BaseGrid.Restart();
    }

    private void EndGame()
    {
        _levelGenerator.CurrentLevel = 0;

        _levelGenerator.EndGameScreen.LaunchEndGameScreen(_levelGenerator.BaseGrid);
    }
}
