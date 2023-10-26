using UnityEngine;
using System.Collections;

namespace _2048FALLING
{
    public class PlayerController : MonoBehaviour
    {
        public static event System.Action PlayerDied;
        //public static PlayerController Instance;
        //private void Awake()
        //{
        //    if (Instance)
        //    {
        //        Destroy(gameObject);
        //    }else
        //    {
        //        Instance = this;
        //        DontDestroyOnLoad(gameObject);
        //    }
                
        //}
        void OnEnable()
        {
            GameManager.GameStateChanged += OnGameStateChanged;
        }

        void OnDisable()
        {
            GameManager.GameStateChanged -= OnGameStateChanged;
        }

        void Start()
        {
            // Setup
        }
	
        // Update is called once per frame
        void Update()
        {
        }

        // Listens to changes in game state
        void OnGameStateChanged(GameState newState, GameState oldState)
        {
            if (newState == GameState.Playing)
            {
                // Do whatever necessary when a new game starts
            }      
        }

        // Calls this when the player dies and game over
        public void Die()
        {
            // Fire event
            if (PlayerDied != null)
                PlayerDied();
        }
    }
}