using UnityEngine;

namespace _2048FALLING
{
    public class SwipeControl : MonoBehaviour
    {

        public static SwipeControl Instance;
        public bool _Tap, _Left, _Right, _Up, _Down;
        private Vector2 startTouch, _Delta;
        private bool isDraging = false;
        private float touchX = 0;

        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        private void Update()
        {
            // move();
            //MoveTouch();
            MoveMouse();
        }

        void MoveTouch()
        {
            _Tap = _Up = _Down = _Left = _Right = false;
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                    touchX = touchDeltaPosition.x;
                    //touchX = Mathf.Clamp(touchX / 10000, -1.0f, 1.0f); // nhay
                    if (touchX > 25)
                    {
                        _Right = true;
                    }
                    else if (touchX < -25)
                        _Left = true;
                    else
                    {
                        _Left = _Right = false;
                    }
                }
                else
                {
                    _Left = _Right = false;
                }
            }
        }

        float posBeginX = 0;
        public float distanceX = 1.1f;
        public float timeMouseDow = 0;
        public float timeMouseUp = 0;
        public float distanceTemp = 0;

        void MoveMouse()
        {
            _Tap = _Up = _Down = _Left = _Right = false;
            if (Input.GetMouseButtonDown(0))
            {
                posBeginX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
                GameBroadManager.Instance.ismoving = true;
                timeMouseDow = Time.time;
            }

            if (Input.GetMouseButton(0) /*&& Time.time - timeLast > 0.1f*/)
            {
                //timeLast = Time.time;
                float posX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
                //Debug.Log(posBeginX - posX);
                distanceTemp = posBeginX - posX;
                if (distanceTemp < -distanceX)
                {
                    _Left = true;
                    posBeginX = posX;
                }
                else if (distanceTemp > distanceX)
                {
                    _Right = true;
                    posBeginX = posX;
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                GameBroadManager.Instance.ismoving = false;
                timeMouseUp = Time.time;
                //Debug.Log(timeMouseUp + " _ " + timeMouseDow);
            }


        }

        private void move()
        {
            _Tap = _Up = _Down = _Left = _Right = false;
            #region Standalone Input
            if (Input.GetMouseButtonDown(0))
            {
                _Tap = true;
                isDraging = true;
                startTouch = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isDraging = false;
                Reset();
            }
            #endregion

            #region Mobile Input
            if (Input.touches.Length > 0)
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    isDraging = true;
                    _Tap = true;
                    startTouch = Input.touches[0].position;
                }
                else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
                {
                    isDraging = false;
                    Reset();
                }
            }

            #endregion

            #region Tinh khoan cach 
            _Delta = Vector2.zero;// gan gia tri ban dau
            if (isDraging)
            {
                if (Input.touches.Length > 0)
                    _Delta = Input.touches[0].position - startTouch;
                else
                {
                    if (Input.GetMouseButton(0))
                    {
                        _Delta = (Vector2)Input.mousePosition - startTouch;
                    }
                }
            }
            #endregion

            // Did wr cross the deadzone?
            if (_Delta.magnitude > 0)
            {
                //which direction ?
                float x = _Delta.x;
                float y = _Delta.y;
                if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    // L or R 
                    if (x < 0)
                    {
                        _Left = true;
                    }
                    else
                        _Right = true;
                }
                else
                {
                    if (y < 0)
                        _Down = true;
                    else
                        _Up = true;
                }
                Reset();
            }
        }

        private void Reset()
        {
            startTouch = _Delta = Vector2.zero; // khoi dong lai gia tri ban dau 
            isDraging = false;
        }
    }
}