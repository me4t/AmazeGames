using System.Threading.Tasks;
using CodeBase.CameraLogic;
using CodeBase.Infrastructure.Factory;
using CodeBase.Logic;
using CodeBase.Services.StaticData;
using CodeBase.StaticData;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;
        private readonly IStaticDataService _staticData;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain,
            IGameFactory gameFactory, IStaticDataService staticDataService)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
            _staticData = staticDataService;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtain.Show();
            _gameFactory.Cleanup();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() =>
            _loadingCurtain.Hide();

        private async void OnLoaded()
        {
            await InitGameWorld();
            _stateMachine.Enter<GameLoopState>();
        }



        private async Task InitGameWorld()
        {
            LevelStaticData levelData = LevelStaticData();

            await InitSpawners(levelData);
            GameObject hero = await InitHero(levelData);
            await InitHud();
            CameraFollow(hero);
        }

        private async Task InitSpawners(LevelStaticData levelStaticData)
        {
            foreach (EnemySpawnerStaticData spawnerData in levelStaticData.LootSpawners)
                await _gameFactory.CreateSpawner(spawnerData.Position, spawnerData.lootSpawnId);
        }


        private async Task<GameObject> InitHero(LevelStaticData levelStaticData) =>
            await _gameFactory.CreateHero(levelStaticData.InitialHeroPosition);


        private async Task InitHud() => await _gameFactory.CreateHud();

        private LevelStaticData LevelStaticData() =>
            _staticData.ForLevel(SceneManager.GetActiveScene().name);

        private void CameraFollow(GameObject hero) =>
            Camera.main.GetComponent<CameraFollow>().Follow(hero);
    }
}