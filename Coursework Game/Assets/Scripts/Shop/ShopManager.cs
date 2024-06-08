using System.Collections.Generic;
using UnityEngine;

namespace CourseworkGame.Shop
{
    public class ShopManager : MonoBehaviour
    {
        [SerializeField] private List<ShopItemSO> shopItemsInfo;
        [SerializeField] private List<ShopItemTemplate> shopItems;

        private void Start()
        {
            var sprites = new List<Sprite>(Resources.LoadAll<Sprite>($"SkinSprites/"));
            for (int i = 0; i < shopItemsInfo.Count; i++)
            {
                shopItems[i].enabled = true;
                Instantiate(sprites.Find(s => s.name == shopItemsInfo[i].SkinName), shopItems[i].SkinSpriteSpawnPoint);
                shopItems[i].SkinName.text = shopItemsInfo[i].SkinName;
                shopItems[i].Price.text =
                    shopItemsInfo[i].Price + (shopItemsInfo[i].Currency == ShopItemSO.CurrencyType.Coin
                        ? "\nCoins"
                        : "\nStars");
            }
        }
    }
}