using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseItemUI : MonoBehaviour
{
    [SerializeField] List<ItemInfo> allItems;
    [SerializeField] List<ItemInfoHolder> itemButtons;
    [SerializeField] GameObject rewardScreen;

    public void OpenRewardScreen()
    {
        rewardScreen.SetActive(true);
        RandomizeItems();
    }

    void RandomizeItems()
    {
        int itemsToGenerate = itemButtons.Count;
        List<ItemInfo> randomizedItems = new List<ItemInfo>();
        ItemInfo randomItem = null;

        for (int i = 0; i < itemsToGenerate; i++)
        {
            do
            {
                randomItem = allItems[Random.Range(0, allItems.Count)];
            } while (randomizedItems.Contains(randomItem));

            randomizedItems.Add(randomItem);
        }

        for (int i = 0; i < itemButtons.Count; i++)
        {
            itemButtons[i].SetNewItem(randomizedItems[i]);
        }
    }
}
