using UnityEngine;

namespace RollingRush.Shop
{
    [CreateAssetMenu]
    public class ShopItemSO : ScriptableObject
    {
        [field: SerializeField] public string Title { get; private set; }
        [field: SerializeField] public string SkinName { get; private set; }
        [field: SerializeField] public int Price { get; private set; }
        [field: SerializeField] public CurrencyType Currency { get; private set; }
        [field: SerializeField] public string SkinSprite { get; private set; }
        
        public enum CurrencyType
        {
            Coin,
            Star
        }
    }
}