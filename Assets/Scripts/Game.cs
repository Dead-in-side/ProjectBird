using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private BirdSpawner _enemySpawner;
    [SerializeField] private StartWindow _startWindow;
    [SerializeField] private GameOverWindow _gameOverWindow;

    private void Awake()
    {
        _startWindow.gameObject.SetActive(true);
        _gameOverWindow.gameObject.SetActive(false);

        Time.timeScale = 0;
    }

    private void OnEnable()
    {
        _startWindow.ButtonPressed += StartTime;
        _player.GameOver += StopTime;
        _gameOverWindow.ButtonPressed += Restart;
    }

    private void OnDisable()
    {
        _startWindow.ButtonPressed -= StartTime;
        _player.GameOver -= StopTime;
        _gameOverWindow.ButtonPressed -= Restart;
    }

    private void Restart()
    {
        _enemySpawner.Reset();
        _player.Restart();
        _gameOverWindow.gameObject.SetActive(false);
        StartTime();
    }

    private void StopTime()
    {
        Time.timeScale = 0;

        _gameOverWindow.gameObject.SetActive(true);
    }

    private void StartTime()
    {
        Time.timeScale = 1;

        _startWindow.gameObject.SetActive(false);
    }
}
