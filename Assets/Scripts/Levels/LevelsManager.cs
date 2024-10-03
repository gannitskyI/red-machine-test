using Events;
using UnityEngine.SceneManagement;
using Utils.Scenes;
using Utils.Singleton;

namespace Levels
{
    public class LevelsManager : DontDestroyMonoBehaviour
    {
        private const string TestSceneName = "TestScene";
        private const string LevelNamePattern = "Level{0}";
        private bool _isTestSceneComplete = false;

        private int _currentLevelIndex;

        private void Start()
        {
            ScenesChanger.GotoScene(TestSceneName);
            EventsController.Subscribe<EventModels.Game.TargetColorNodesFilled>(this, OnTargetColorNodesFilled);
        }

        private void OnTargetColorNodesFilled(EventModels.Game.TargetColorNodesFilled e)
        {
            if (SceneManager.GetActiveScene().name == TestSceneName && !_isTestSceneComplete)
            {
                _isTestSceneComplete = true;
                _currentLevelIndex = 0;  // Сначала загружается Level0
                ScenesChanger.GotoScene(string.Format(LevelNamePattern, _currentLevelIndex));
            }
            else
            {
                _currentLevelIndex += 1;
                ScenesChanger.GotoScene(string.Format(LevelNamePattern, _currentLevelIndex));
            }
        }
    }
}
