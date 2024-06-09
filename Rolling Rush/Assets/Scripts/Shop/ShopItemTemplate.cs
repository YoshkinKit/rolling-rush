using TMPro;
using UnityEngine;

namespace RollingRush.Shop
{
    public class ShopItemTemplate : MonoBehaviour
    {
        [field: SerializeField] public RectTransform SkinSpriteSpawnPoint { get; private set; }
        [field: SerializeField] public TMP_Text SkinName { get; set; }
        [field: SerializeField] public TMP_Text Price { get; set; }
    }
}