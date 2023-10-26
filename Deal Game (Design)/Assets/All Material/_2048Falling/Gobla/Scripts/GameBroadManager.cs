using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _2048FALLING
{
    //public enum GameState
    //{
    //    Playing,
    //    OverGame
    //}
    public class GameBroadManager : MonoBehaviour
    {
        public static GameBroadManager Instance;
        private GameState gameState;
        // for animation at start menu

        [Header("Reference Objects")]
        [SerializeField]
        private Tile tileRandom;

        [SerializeField]
        private Tile[] AllTiles_;

        [Header("Config")]
        [SerializeField]
        private float minFallingTime = 0.3f;

        [SerializeField]
        [Tooltip("This is falling speed at start game")]
        private float maxFallingTime = 0.6f;

        [SerializeField]
        private float decreasingValue = 0.01f;

        [SerializeField]
        private int ScoreToDifficult = 32;

        private const int maxCol = 5;
        private const int maxRow = 5;
        private Tile[,] AllTiles = new Tile[maxCol, maxRow];
        private List<Tile> EmplyTiles = new List<Tile>();
        private int numberData;
        private float curFallingTime;
        private int isRow = 0;
        private int isCol = 2;
        private int isColRandom = 2;
        // allow moving or end move
        private bool canControl = true;
        // allow control left or right
        //private AudioSource audioSource;
        public Color backrgroud;
        public bool ismoving = false;
        //public AudioClip audioClipScore;
        //public AudioClip audioClipCol;
        //public AudioClip audioClipCol2;



        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                // DontDestroyOnLoad(gameObject);
            }
            //audioSource = GetComponent<AudioSource>();
        }
        // Use this for initialization
        void Start()
        {
            NewGame();
        }

        private void OnEnable()
        {
            curFallingTime = maxFallingTime;
        }

        // create new game
        public void NewGame()
        {
            //UIManager.Instance.txtScore.text = 0+"";
            gameState = GameState.Playing;
            isCol = 2;
            isRow = 0;
            curFallingTime = maxFallingTime;
            AllTiles_ = GameObject.FindObjectsOfType<Tile>();
            AllTiles_ = AllTiles_.OrderBy(obj => obj.name, new AlphanumComparatorFast()).ToArray();
            int indexTemp = 0;  // 
            // init Value for Alltiles_
            for (int iRow = 0; iRow < maxRow; ++iRow)
            {

                EmplyTiles.Add(AllTiles_[iRow]);

                for (int iCol = 0; iCol < maxCol; ++iCol)
                {
                    AllTiles_[indexTemp].Number = 0;
                    AllTiles_[indexTemp].indRow = iRow;
                    AllTiles_[indexTemp].indCol = iCol;

                    AllTiles[iRow, iCol] = AllTiles_[indexTemp];
                    ++indexTemp;
                }
            }
            tileRandom.Number = 2;
            init();

        }

        public void Move(MoveDirection md)
        {
            //Debug.Log(md.ToString() + " move.");
            if (canControl && ismoving)
            {
                switch (md)
                {
                    case MoveDirection.Right:
                        {

                            AllTiles[isRow, isCol].Number = 0;
                            ++isCol;
                            if (isCol >= maxCol)
                                isCol = maxCol - 1;

                            if (AllTiles[isRow, isCol].Number == 0 || AllTiles[isRow, isCol].Number == -1)
                                AllTiles[isRow, isCol].Number = numberData;     // can move down
                            else                                                // can't move down, because Tile next is not empty
                                AllTiles[isRow, --isCol].Number = numberData;

                            AllTiles[isRow, isCol].Number = numberData;
                            break;
                        }
                    case MoveDirection.Left:
                        {
                            AllTiles[isRow, isCol].Number = 0;
                            --isCol;
                            if (isCol <= 0)
                                isCol = 0;

                            if (AllTiles[isRow, isCol].Number == 0 || AllTiles[isRow, isCol].Number == -1)
                                AllTiles[isRow, isCol].Number = numberData;     // can move down
                            else                                                // can't move down, because Tile next is not empty
                                AllTiles[isRow, ++isCol].Number = numberData;

                            AllTiles[isRow, isCol].Number = numberData;

                            break;
                        }
                }
            }


        }

        IEnumerator SortHeight(int ir, int ic)
        {
            if (AllTiles[ir - 1, ic].Number != 0)
            {
                for (int i = ir; i > 0; --i) // from bottom to top
                {
                    if (i - 1 >= 0) // top
                    {
                        AllTiles[i, ic].Number = AllTiles[i - 1, ic].Number;
                        yield return new WaitForSeconds(0.001f);
                    }
                }
                AllTiles[0, ic].Number = 0;
                DropD(ir, ic);
            }

        }

        bool checkIr(int ir)
        {
            if (ir < 0 || ir >= maxRow)
                return false;
            return true;
        }

        bool checkIc(int ic)
        {
            if (ic < 0 || ic >= maxCol)
                return false;
            return true;
        }

        void DropD(int ir, int ic)
        {
            if (checkIr(ir + 1))
            {
                if (AllTiles[ir, ic].Number == AllTiles[ir + 1, ic].Number)
                {
                    AllTiles[ir, ic].Number *= 2;
                    ScoreManager.Instance.AddScore(AllTiles[ir, ic].Number);
                    AllTiles[ir + 1, ic].Number = 0;
                    StartCoroutine(SortHeight(ir + 1, ic));
                    DropDLR(ir + 1, ic);
                }

            }
        }

        void DropL(int ir, int ic)
        {
            if (checkIc(ic - 1))
            {
                if (AllTiles[ir, ic].Number == AllTiles[ir, ic - 1].Number)
                {
                    AllTiles[ir, ic].Number *= 2;
                    ScoreManager.Instance.AddScore(AllTiles[ir, ic].Number);
                    AllTiles[ir, ic - 1].Number = 0;
                    StartCoroutine(SortHeight(ir, ic - 1));
                }
            }
        }

        void DropR(int ir, int ic)
        {
            if (checkIc(ic + 1))
            {
                if (AllTiles[ir, ic].Number == AllTiles[ir, ic + 1].Number)
                {
                    AllTiles[ir, ic].Number *= 2;
                    ScoreManager.Instance.AddScore(AllTiles[ir, ic].Number);
                    AllTiles[ir, ic + 1].Number = 0;
                    StartCoroutine(SortHeight(ir, ic + 1));
                }
            }
        }

        void DropDLR(int ir, int ic)
        {
            bool r = false;
            bool l = false;
            bool d = false;
            CheckDLR(ir, ic, ref d, ref l, ref r);
            //Debug.Log(l + "" + r + "" + d);
            if (r && l && d)
            {
                //Debug.Log("3" + ir + "_" + ic);
                AllTiles[ir, ic].Number *= 4;
                ScoreManager.Instance.AddScore(AllTiles[ir, ic].Number);
                AllTiles[ir, ic + 1].Number = 0;
                AllTiles[ir, ic - 1].Number = 0;
                AllTiles[ir + 1, ic].Number = 0;
                StartCoroutine(SortHeight(ir, ic + 1));
                StartCoroutine(SortHeight(ir, ic - 1));
                StartCoroutine(SortHeight(ir + 1, ic));
            }
            else
            {
                if (r && l)
                {
                    //Debug.Log("2");
                    AllTiles[ir, ic].Number *= 3;
                    ScoreManager.Instance.AddScore(AllTiles[ir, ic].Number);
                    AllTiles[ir, ic + 1].Number = 0;
                    AllTiles[ir, ic - 1].Number = 0;
                    StartCoroutine(SortHeight(ir, ic + 1));
                    StartCoroutine(SortHeight(ir, ic - 1));
                }
                else
                {
                    if (r && d)
                    {
                        //Debug.Log("2" + ir + "_" + ic);
                        AllTiles[ir, ic].Number *= 3;
                        ScoreManager.Instance.AddScore(AllTiles[ir, ic].Number);
                        AllTiles[ir, ic - 1].Number = 0;
                        AllTiles[ir + 1, ic].Number = 0;
                        StartCoroutine(SortHeight(ir, ic - 1));
                        StartCoroutine(SortHeight(ir + 1, ic));
                    }
                    else
                    {
                        if (l && d)
                        {
                            //Debug.Log("2" + ir + "_" + ic);
                            AllTiles[ir, ic].Number *= 3;
                            ScoreManager.Instance.AddScore(AllTiles[ir, ic].Number);
                            AllTiles[ir, ic + 1].Number = 0;
                            AllTiles[ir + 1, ic].Number = 0;
                            StartCoroutine(SortHeight(ir, ic + 1));
                            StartCoroutine(SortHeight(ir + 1, ic));
                        }
                        else
                        {
                            //Debug.Log("1" + ir + "_" + ic);
                            if (r)
                                DropR(ir, ic);
                            else if (l)
                                DropL(ir, ic);
                            else if (d)
                                DropD(ir, ic);
                        }
                    }
                }

            }

        }

        void CheckDropAlltiles()
        {

        }

        void CheckDLR(int ir, int ic, ref bool d, ref bool l, ref bool r)
        {
            if (checkIc(ic + 1))// right
                if (AllTiles[ir, ic].Number == AllTiles[ir, ic + 1].Number)
                r = true;
            else
                r = false;

            if (checkIc(ic - 1))// right
                if (AllTiles[ir, ic].Number == AllTiles[ir, ic - 1].Number)
                l = true;
            else
                l = false;

            if (checkIr(ir + 1))// right
                if (AllTiles[ir, ic].Number == AllTiles[ir + 1, ic].Number)
                d = true;
            else
                d = false;

        }

        bool mergeR(ref int ir, ref int ic, int mode)
        {
            if (ic + 1 >= maxCol)
                return false;
            if (mode != 1)
            {
                while (AllTiles[ir, ic + 1].Number == numberData)
                {
                    numberData *= 2;
                    AllTiles[ir, ic + 1].Number = 0;
                    AllTiles[ir, ic].Number = numberData;
                    StartCoroutine(SortHeight(ir, ic + 1));
                    ScoreManager.Instance.AddScore(numberData);

                    if (SoundManager.Instance.IsSoundOff() == false)
                    {
                        SoundManager.Instance.PlaySound(SoundManager.Instance.audioClipScore);
                    }

                }
            }
            else
            {
                if (AllTiles[ir, ic + 1].Number == numberData)
                {
                    numberData *= 2;
                    AllTiles[ir, ic + 1].Number = 0;
                    AllTiles[ir, ic].Number = numberData;
                    StartCoroutine(SortHeight(ir, ic + 1));
                    ScoreManager.Instance.AddScore(numberData);

                    if (SoundManager.Instance.IsSoundOff() == false)
                    {
                        SoundManager.Instance.PlaySound(SoundManager.Instance.audioClipScore);
                    }
                }
            }
            return true;
        }

        bool mergeL(ref int ir, ref int ic, int mode)
        {
            if (ic - 1 < 0)
                return false;
            if (mode != 1)
            {
                while (AllTiles[ir, ic - 1].Number == numberData)
                {
                    numberData *= 2;
                    AllTiles[ir, ic - 1].Number = 0;
                    AllTiles[ir, ic].Number = numberData;
                    StartCoroutine(SortHeight(ir, ic - 1));
                    ScoreManager.Instance.AddScore(numberData);

                    if (SoundManager.Instance.IsSoundOff() == false)
                    {
                        SoundManager.Instance.PlaySound(SoundManager.Instance.audioClipScore);
                    }
                }
            }
            else
            {
                if (AllTiles[ir, ic - 1].Number == numberData)
                {
                    numberData *= 2;
                    AllTiles[ir, ic - 1].Number = 0;
                    AllTiles[ir, ic].Number = numberData;
                    StartCoroutine(SortHeight(ir, ic - 1));
                    ScoreManager.Instance.AddScore(numberData);

                    if (SoundManager.Instance.IsSoundOff() == false)
                    {
                        SoundManager.Instance.PlaySound(SoundManager.Instance.audioClipScore);
                    }
                }
            }
            return true;
        }

        bool mergeD(ref int ir, ref int ic)
        {
            if (ir + 1 >= maxRow)
                return false;
            if (AllTiles[ir, ic].Number != AllTiles[ir + 1, ic].Number)
                return false;
            numberData *= 2;
            AllTiles[ir, ic].Number = 0;
            AllTiles[++ir, ic].Number = numberData;
            ScoreManager.Instance.AddScore(numberData);

            if (SoundManager.Instance.IsSoundOff() == false)
            {
                SoundManager.Instance.PlaySound(SoundManager.Instance.audioClipScore);
                //audioSource.clip = audioClipScore;
                //audioSource.Play();
            }
            return true;
        }

        bool mergeLDR(ref int ir, ref int ic)
        {
            EmplyTiles[isColRandom].Number = 0;
            int L = 0, R = 0, D = 0;
            //check left/right
            if (ic - 1 >= 0)
            if (AllTiles[ir, ic - 1].Number == numberData)
                L = 1;
            if (ic + 1 < maxCol)
            if (AllTiles[ir, ic + 1].Number == numberData)
                R = 1;
            if (ir + 1 < maxRow)
            if (AllTiles[ir + 1, ic].Number == numberData)
                D = 1;

            if (L == 0 && R == 0 && D == 0)
                return false;

            if (L == 1 && D == 1 && R == 1) //2 2 2
            {                               //  2   
                numberData *= 4;
                AllTiles[ir, ic].Number = numberData;
                AllTiles[ir, ic - 1].Number = 0;
                AllTiles[ir, ic + 1].Number = 0;
                AllTiles[ir + 1, ic].Number = 0;
                StartCoroutine(SortHeight(ir, ic - 1));
                StartCoroutine(SortHeight(ir, ic + 1));
                ScoreManager.Instance.AddScore(numberData);
                CoinManager.Instance.AddCoins(3);

                if (SoundManager.Instance.IsSoundOff() == false)
                {
                    SoundManager.Instance.PlaySound(SoundManager.Instance.audioClipScore);
                    //audioSource.clip = audioClipScore;
                    //audioSource.Play();
                }
                //Debug.LogError("LDR");
                return true;                    // meger ok
            }
            else
            {
                if (L == 1 && R == 1)   //2 2 2
                {
                    numberData *= 3;
                    AllTiles[ir, ic].Number = numberData;
                    AllTiles[ir, ic - 1].Number = 0;
                    AllTiles[ir, ic + 1].Number = 0;
                    StartCoroutine(SortHeight(ir, ic - 1));
                    StartCoroutine(SortHeight(ir, ic + 1));
                    ScoreManager.Instance.AddScore(numberData);
                    CoinManager.Instance.AddCoins(1);

                    if (SoundManager.Instance.IsSoundOff() == false)
                    {
                        SoundManager.Instance.PlaySound(SoundManager.Instance.audioClipScore);
                        //audioSource.clip = audioClipScore;
                        //audioSource.Play();
                    }
                    return true;                //meger ok
                }
                else
                {
                    if (L == 1 && D == 1)   //2 2   => 0 6
                    {                       //3 2      3 0
                        numberData *= 3;
                        AllTiles[ir, ic].Number = numberData;
                        AllTiles[ir, ic - 1].Number = 0;
                        AllTiles[ir + 1, ic].Number = 0;
                        StartCoroutine(SortHeight(ir, ic - 1));

                        ScoreManager.Instance.AddScore(numberData);
                        CoinManager.Instance.AddCoins(1);

                        if (SoundManager.Instance.IsSoundOff() == false)
                        {
                            SoundManager.Instance.PlaySound(SoundManager.Instance.audioClipScore);
                            //audioSource.clip = audioClipScore;
                            //audioSource.Play();
                        }
                        // Debug.Log("LD");
                        return true;            // meger ok
                    }
                    else
                    {
                        if (R == 1 && D == 1)   //8 2 2 =>  8 6 0
                        {                       //3 2       3 0
                            numberData *= 3;
                            AllTiles[ir, ic].Number = numberData;
                            AllTiles[ir, ic + 1].Number = 0;
                            AllTiles[ir + 1, ic].Number = 0;
                            StartCoroutine(SortHeight(ir, ic + 1));
                            ScoreManager.Instance.AddScore(numberData);
                            CoinManager.Instance.AddCoins(1);

                            if (SoundManager.Instance.IsSoundOff() == false)
                            {
                                SoundManager.Instance.PlaySound(SoundManager.Instance.audioClipScore);
                                //audioSource.clip = audioClipScore;
                                //audioSource.Play();
                            }
                            // Debug.Log("DR");
                            return true;        // meger ok
                        }
                        else
                        {
                            if (L == 1)
                                return mergeL(ref ir, ref ic, 1);// 2 2 3
                            else if (R == 1)
                                return mergeR(ref ir, ref ic, 1);// 3 2 2
                            else if (D == 1)
                                return mergeD(ref ir, ref ic);// 2
                            // 2    
                        }
                    }
                }
            }
            EmplyTiles[isColRandom].Number = 0;
            return false;   //failed 
        }

        public void init()
        {
            if (SoundManager.Instance.IsSoundOff() == false)
            {
                //SoundManager.Instance.PlaySound(SoundManager.Instance.audioClipCol2);
                //audioSource.clip = audioClipCol2;
                //audioSource.Play();
            }
            isRow = 0;

            //AllTiles[0, isCol].Number = -1;

            if (gameState == GameState.Playing)
            {
                // check other tiles
                //for (int r = 0; r < 5; ++r)
                //{
                //    for (int c = 0; c < 5; ++c)
                //    {
                //        if (AllTiles[r, c].Number != 0)
                //        {
                //            int row = r, col = c;
                //            mergeD(ref row, ref col);
                //        }
                //    }
                //}

                if (AllTiles[isRow, isCol].Number == 0 || AllTiles[isRow, isCol].Number == -1)
                {
                    curFallingTime = Mathf.Clamp(maxFallingTime - decreasingValue * (ScoreManager.Instance.Score / ScoreToDifficult),
                        minFallingTime, maxFallingTime);
                    //Debug.Log(curFallingTime);


                    numberData = tileRandom.Number;

                    canControl = true;

                    isCol = isColRandom;
                    EmplyTiles[isColRandom].Number = 0;
                    AllTiles[isRow, isCol].Number = numberData;

                    // random next number
                    int indexNumber = Random.Range(0, 3);
                    tileRandom.Number = TileStyleHolder.Instance.TileStyles[indexNumber].Number;
                    int temp = Random.Range(1, 4);
                    while (temp == isColRandom)
                        temp = Random.Range(1, 4);
                    isColRandom = temp;
                    EmplyTiles[isColRandom].Number = -1;
                }
                else
                {
                    if (mergeLDR(ref isRow, ref isCol) == false)    // if tile don't move, then show menu gameover
                    {
                        //Debug.Log("Gameover");
                        //gameObject.SetActive(false);
                        canControl = false;
                        gameState = GameState.GameOver;
                        if (GameManager.Instance.GameState == GameState.Playing)
                        {
                            curFallingTime = maxFallingTime;
                            GameManager.Instance.GameOver();
                        }
                        else
                            init();
                    }
                }

                //if (gameObject.activeSelf == true)
                StartCoroutine(onFramper());
            }

        }

        IEnumerator onFramper()// move down 
        {
            if (gameState == GameState.Playing)
            {
                yield return new WaitForSeconds(curFallingTime);
                //EmplyTiles[isColRandom].Number = 0;
                if (canControl == false)
                {
                    mergeLDR(ref isRow, ref isCol);
                }
                if (SoundManager.Instance.IsSoundOff() == false)
                {
                    SoundManager.Instance.PlaySound(SoundManager.Instance.audioClipCol);
                    //audioSource.clip = audioClipCol;
                    //audioSource.Play();
                }

                if (isRow + 1 < maxRow)
                {
                    if (AllTiles[isRow + 1, isCol].Number == -1)
                        AllTiles[isRow + 1, isCol].Number = 0;
                    if (AllTiles[isRow + 1, isCol].Number == 0)
                    {
                        AllTiles[isRow, isCol].Number = 0;
                        ++isRow;
                        AllTiles[isRow, isCol].Number = numberData;
                        StartCoroutine(onFramper());
                    }
                    else
                    {
                        if (AllTiles[isRow + 1, isCol].Number == -1)
                            AllTiles[isRow + 1, isCol].Number = 0;
                        if (AllTiles[isRow + 1, isCol].Number != 0)     // coll
                        {

                            if (mergeLDR(ref isRow, ref isCol) == false)             // meger
                            {
                                if (isRow == 0)
                                {
                                    //Debug.Log("Gameover");
                                    //gameObject.SetActive(false);
                                    canControl = false;
                                    gameState = GameState.GameOver;
                                    if (GameManager.Instance.GameState == GameState.Playing)
                                    {
                                        curFallingTime = maxFallingTime;
                                        GameManager.Instance.GameOver();
                                    }
                                    else
                                        init();
                                }
                                init();
                            }
                            else
                            {
                                canControl = false;
                                StartCoroutine(onFramper());
                            }
                        }
                    }
                    EmplyTiles[isColRandom].Number = -1;
                }
                else
                {   // in line bottom
                    //string s = "";
                    if (mergeLDR(ref isRow, ref isCol) == false)             // meger
                    {
                        init();

                    }
                    else
                    {
                        canControl = false;
                        StartCoroutine(onFramper());
                    }
                }
            }

        }

    }
}