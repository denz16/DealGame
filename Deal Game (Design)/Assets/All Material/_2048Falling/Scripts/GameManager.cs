using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

namespace _2048FALLING
{
    public enum GameState
    {
        Prepare,
        Playing,
        Paused,
        PreGameOver,
        GameOver
    }

    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public static event System.Action<GameState, GameState> GameStateChanged;

        private static bool isRestart;

        public GameState GameState
        {
            get
            {
                return GameState1;
            }
            private set
            {
                if (value != GameState1)
                {
                    GameState oldState = GameState1;
                    GameState1 = value;

                    if (GameStateChanged != null)
                        GameStateChanged(GameState1, oldState);
                }
            }
        }

        public static int GameCount
        {
            get { return _gameCount; }
            private set { _gameCount = value; }
        }

        public GameState GameState1
        {
            get
            {
                return _gameState;
            }

            set
            {
                _gameState = value;
            }
        }

        private static int _gameCount = 0;

        [Header("Set the target frame rate for this game")]
        [Tooltip("Use 60 for games requiring smooth quick motion, set -1 to use platform default frame rate")]
        public int targetFrameRate = 30;

        [Header("Current game state")]
        [SerializeField]
        private GameState _gameState = GameState.Prepare;

        // List of public variable for gameplay tweaking
        [Header("Gameplay Config")]

        [SerializeField]
        private Vector3 startPlayerPosition;

        [Range(0f, 1f)]
        public float coinFrequency = 0.1f;

        // List of public variables referencing other objects
        [Header("Object References")]
        public PlayerController playerController;

        void OnEnable()
        {
            PlayerController.PlayerDied += PlayerController_PlayerDied;
            CharacterScroller.ChangeCharacter += CreateNewCharacter;
        }

        void OnDisable()
        {
            PlayerController.PlayerDied -= PlayerController_PlayerDied;
            CharacterScroller.ChangeCharacter -= CreateNewCharacter;
        }

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                DestroyImmediate(Instance.gameObject);
                Instance = this;
            }
            CreateNewCharacter(CharacterManager.Instance.CurrentCharacterIndex);
        }

        void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }

        // Use this for initialization
        void Start()
        {
            // Initial setup
            Application.targetFrameRate = targetFrameRate;
            ScoreManager.Instance.Reset();

            PrepareGame();
        }

        // Update is called once per frame
        void Update()
        {

        }

        // Listens to the event when player dies and call GameOver
        public void PlayerController_PlayerDied()
        {
            GameOver();
        }

        // Make initial setup and preparations before the game can be played
        public void PrepareGame()
        {
            GameState = GameState.Prepare;

            // Automatically start the game if this is a restart.
            if (isRestart)
            {
                isRestart = false;
                StartGame();
            }
        }

        // A new game official starts
        public void StartGame()
        {
            StartCoroutine(DelayStartGame());
        }

        IEnumerator DelayStartGame()
        {
            yield return new WaitForEndOfFrame();
            GameState = GameState.Playing;
            if (SoundManager.Instance.background != null)
            {
                SoundManager.Instance.PlayMusic(SoundManager.Instance.background);
            }
        }

        // Called when the player died
        public void GameOver()
        {
            
                if (SoundManager.Instance.background != null)
                {
                    SoundManager.Instance.StopMusic();
                }

                SoundManager.Instance.PlaySound(SoundManager.Instance.gameOver);
                GameState = GameState.GameOver;
                GameCount++;

                // Add other game over actions here if necessary
                Debug.Log("take Photo");
                ScreenshotSharer.Instance.PlayerController_PlayerDied();
      
        }

        // Start a new game
        public void RestartGame(float delay = 0)
        {

            isRestart = true;
            StartCoroutine(CRRestartGame(delay));
        }

        IEnumerator CRRestartGame(float delay = 0)
        {
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            //SceneManager.LoadScene(0);
        }

        public void HidePlayer()
        {
            if (playerController != null)
                playerController.gameObject.SetActive(false);
        }

        public void ShowPlayer()
        {
            if (playerController != null)
                playerController.gameObject.SetActive(true);
        }

        void CreateNewCharacter(int curChar)
        {
            if (playerController != null)
            {
                DestroyImmediate(playerController.gameObject);
                playerController = null;
            }
            StartCoroutine(CR_DelayCreateNewCharacter(curChar));
        }

        IEnumerator CR_DelayCreateNewCharacter(int curChar)
        {
            yield return new WaitForEndOfFrame();
            //GameObject player = Instantiate(CharacterManager.Instance.characters[curChar]);
            //player.transform.position = startPlayerPosition;
            //playerController = player.GetComponent<PlayerController>();
        }
    }
}