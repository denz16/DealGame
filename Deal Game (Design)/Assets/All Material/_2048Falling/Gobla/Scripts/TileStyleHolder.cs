using UnityEngine;
using System.Collections;

namespace _2048FALLING
{
    [System.Serializable]
    public class TileStyle
    {
        public int Number;
        public Color32 TileColor;
        public Color32 TextColor;
    }


    public class TileStyleHolder : MonoBehaviour
    {

        // SINGLETON
        public static TileStyleHolder Instance;

        public TileStyle[] TileStyles;

        void Awake()
        {
            Instance = this;
        }
    }
}
