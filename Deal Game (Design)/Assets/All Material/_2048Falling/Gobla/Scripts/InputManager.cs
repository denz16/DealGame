using UnityEngine;
namespace _2048FALLING
{

    public enum MoveDirection
    {
        Left, Right, Up, Down
    }
    public class InputManager : MonoBehaviour
    {
        private GameBroadManager gm;
        private void Awake()
        {
            gm = GameObject.FindObjectOfType<GameBroadManager>();
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance.GameState == GameState.Playing)
            {
                moveTouch();
                //Mouse();
                // Key();
            }

        }
        void Key()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                // move Right
                gm.Move(MoveDirection.Right);
            }
            else
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // move Left
                gm.Move(MoveDirection.Left);
            }

        }
        float timeLast = 0;
        void moveTouch()
        {
            if (Time.time - timeLast > 0.0f)
            {
                timeLast = Time.time;
                if (SwipeControl.Instance._Right)
                {
                    gm.Move(MoveDirection.Right);
                    SwipeControl.Instance._Right = false;
                }
                else
                {
                    if (SwipeControl.Instance._Left)
                    {
                        gm.Move(MoveDirection.Left);
                        SwipeControl.Instance._Left = false;
                    }
                }
            }

        }
        float touchX;
        void Touch()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                    touchX = touchDeltaPosition.x;
                    touchX = Mathf.Clamp(touchX / 30, -1.0f, 1.0f); // nhay
                    if (touchX > 0)
                        gm.Move(MoveDirection.Left);
                    if (touchX < 0)
                        gm.Move(MoveDirection.Right);
                }
                else
                {
                    touchX = 0;
                }
            }
        }
        void Mouse()
        {
            


        }
    }
}
