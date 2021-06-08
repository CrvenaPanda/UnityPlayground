using UnityEngine;
using UnityEngine.UI;

namespace HiddenObjectsGame
{
    public class HiddenObjectsTile : MonoBehaviour
    {
        [SerializeField] private Image _image;

        public void SetSprite(Sprite sprite)
        {
            _image.sprite = sprite;
        }

        public void SetTileActive(bool active)
        {
            _image.gameObject.SetActive(active);
        }
    }
}
