using System;
using UnityEngine;
using UnityEngine.UI;

namespace _2048FALLING
{
    public class Tile : MonoBehaviour
    {

        public bool mergedThisTurn = false;

        public int indRow;
        public int indCol;

        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
                if (number == 0)
                    SetEmpty();
                else
                {
                    ApplyStyle(number);
                    SetVisible();
                }
            }
        }

        private int number;

        private Text TileText;
        private Image TileImage;
        private Animator anim;

        void Awake()
        {
            anim = GetComponent<Animator>();
            TileText = GetComponentInChildren<Text>();
            TileImage = transform.Find("NumberCell").GetComponent<Image>();
           
        }
        private void Start()
        {
            transform.GetComponent<Image>().color = GameBroadManager.Instance.backrgroud;
        }
        public void PlayMergeAnimation()
        {
            anim.SetTrigger("Merge");
        }

        public void PlayAppearAnimation()
        {
            anim.SetTrigger("Appear");
        }


        void ApplyStyleFromHolder(int index)
        {
            try
            {
                TileText.text = TileStyleHolder.Instance.TileStyles[index].Number.ToString();
                TileText.color = TileStyleHolder.Instance.TileStyles[index].TextColor;
                TileImage.color = TileStyleHolder.Instance.TileStyles[index].TileColor;
            }
            catch (Exception ex)
            {
                Debug.Log("Erro:" + ex.ToString());
            }
        }

        void ApplyStyle(int num)
        {
            switch (num)
            {
                case 2:
                    ApplyStyleFromHolder(0);
                    break;
                case 4:
                    ApplyStyleFromHolder(1);
                    break;
                case 8:
                    ApplyStyleFromHolder(2);
                    break;
                case 16:
                    ApplyStyleFromHolder(3);
                    break;
                case 32:
                    ApplyStyleFromHolder(4);
                    break;
                case 64:
                    ApplyStyleFromHolder(5);
                    break;
                case 128:
                    ApplyStyleFromHolder(6);
                    break;
                case 256:
                    ApplyStyleFromHolder(7);
                    break;
                case 512:
                    ApplyStyleFromHolder(8);
                    break;
                case 1024:
                    ApplyStyleFromHolder(9);
                    break;
                case 2048:
                    ApplyStyleFromHolder(10);
                    break;
                case 4096:
                    ApplyStyleFromHolder(11);
                    break;
                case 6:
                    ApplyStyleFromHolder(12);
                    break;
                case 12:
                    ApplyStyleFromHolder(13);
                    break;
                case 24:
                    ApplyStyleFromHolder(14);
                    break;
                case 48:
                    ApplyStyleFromHolder(15);
                    break;
                case -1:
                    TileText.text = "";
                    TileText.color = TileStyleHolder.Instance.TileStyles[16].TextColor;
                    TileImage.color = TileStyleHolder.Instance.TileStyles[16].TileColor;
                    break;
                default:
                    TileText.text = num.ToString();
                    TileText.color = TileStyleHolder.Instance.TileStyles[9].TextColor;
                    TileImage.color = TileStyleHolder.Instance.TileStyles[9].TileColor;
                    break;
            }
        }
        private void SetVisible()
        {
            TileImage.enabled = true;
            TileText.enabled = true;
        }

        private void SetEmpty()
        {
            TileImage.enabled = false;
            TileText.enabled = false;
        }
    }
}
