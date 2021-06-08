using System.Collections.Generic;
using UnityEngine;

namespace HiddenObjectsGame
{
    // TODO: Move to common
    public static class IListExtensions {
        /// <summary>
        /// Shuffles the element order of the specified list.
        /// </summary>
        public static void Shuffle<T>(this IList<T> ts) {
            var count = ts.Count;
            var last = count - 1;
            for (var i = 0; i < last; ++i) {
                var r = UnityEngine.Random.Range(i, count);
                var tmp = ts[i];
                ts[i] = ts[r];
                ts[r] = tmp;
            }
        }
    }

    public class HiddenObjectsMain : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private HiddenObjectsData _data;
        [SerializeField] private Vector2Int _boardSize;

        [Header("Prefabs")]
        [SerializeField] private GameObject _row;
        [SerializeField] private GameObject _tile;

        private bool _inputEnabled;
        private Dictionary<GameObject, int> _tiles;


        public void OnCardClicked()
        {
            if (!_inputEnabled)
            {
                return;
            }
        }

        private void Start()
        {
            var tilesCount = _boardSize.x * _boardSize.y;
            if (tilesCount % 2 == 1)
            {
                Debug.LogError($"Tiles count ({tilesCount}) needs to be even.");
                return;
            }

            if ((tilesCount / 2) > _data.Sprites.Count)
            {
                Debug.LogError($"There is not enough sprites ({_data.Sprites.Count}), needs {tilesCount / 2}.");
                return;
            }

            InitTiles();
            _inputEnabled = true;
        }

        private void InitTiles()
        {
            var sprites = GetRandomizedSprites();
            var spriteIndex = 0;
            for (var y = 0; y < _boardSize.y; y++)
            {
                var row = Instantiate(_row, transform).transform;
                for (var x = 0; x < _boardSize.x; x++)
                {
                    var tile = Instantiate(_tile, row).GetComponent<HiddenObjectsTile>();
                    tile.SetSprite(sprites[spriteIndex++]);
                }
            }
        }

        private List<Sprite> GetRandomizedSprites()
        {
            var pairsCount = _boardSize.x * _boardSize.y;
            var result = new List<Sprite>(pairsCount);

            for (var i = 0; i < pairsCount / 2; i++)
            {
                result.Add(_data.Sprites[i]);
                result.Add(_data.Sprites[i]);
            }

            result.Shuffle();
            return result;
        }
    }
}
