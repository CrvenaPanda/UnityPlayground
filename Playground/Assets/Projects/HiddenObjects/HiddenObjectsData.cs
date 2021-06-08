using System.Collections.Generic;
using UnityEngine;

namespace HiddenObjectsGame
{
    [CreateAssetMenu(fileName = "HiddenObjectsData", menuName = "Games/Hidden Objects Data")]
    public class HiddenObjectsData : ScriptableObject
    {
        public List<Sprite> Sprites;
    }
}
