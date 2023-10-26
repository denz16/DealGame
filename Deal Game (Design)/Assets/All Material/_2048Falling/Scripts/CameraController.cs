using UnityEngine;
using System.Collections;

namespace _2048FALLING
{
    public class CameraController : MonoBehaviour
    {
        public Transform playerTransform;
        private Vector3 velocity = Vector3.zero;
        private Vector3 originalDistance = Vector3.zero;

        [Header("Camera Follow Smooth-Time")]
        public float smoothTime = 0.1f;

        [Header("Shaking Effect")]
        // How long the camera shaking.
    public float shakeDuration = 0.1f;
        // Amplitude of the shake. A larger value shakes the camera harder.
        public float shakeAmount = 0.2f;
        public float decreaseFactor = 0.3f;
        [HideInInspector]
        public Vector3 originalPos;

        private float currentShakeDuration;
        private float currentDistance;

        void OnEnable()
        {
            CharacterScroller.ChangeCharacter += ChangeCharacter;
        }

        void OnDisable()
        {
            CharacterScroller.ChangeCharacter -= ChangeCharacter;
        }

        void Start()
        {
            StartCoroutine(WaitingPlayerController());
        }

        void Update()
        {
            if (GameManager.Instance.GameState == GameState.Playing && playerTransform != null)
            {
                Vector3 pos = playerTransform.position + originalDistance;
                transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smoothTime);
            }
        }

        public void FixPosition()
        {
            transform.position = playerTransform.position + originalDistance;
        }

        public void ShakeCamera()
        {
            StartCoroutine(Shake());
        }

        IEnumerator Shake()
        {
            originalPos = transform.position;
            currentShakeDuration = shakeDuration;
            while (currentShakeDuration > 0)
            {
                transform.position = originalPos + Random.insideUnitSphere * shakeAmount;
                currentShakeDuration -= Time.deltaTime * decreaseFactor;
                yield return null;
            }
            transform.position = originalPos;
        }

        void ChangeCharacter(int cur)
        {
            StartCoroutine(WaitingPlayerController());
        }

        IEnumerator WaitingPlayerController()
        {
            yield return new WaitForSeconds(0.05f);
            //playerTransform = GameManager.Instance.playerController.transform;
            //originalDistance = transform.position - playerTransform.transform.position;
        }
    }
}