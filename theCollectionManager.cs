using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string itemName;
}

[System.Serializable]
public class RootObject
{
    public List<Item> items;
}

public class theCollectionManager : MonoBehaviour
{

    public int startIndex = 0; 
    public int maxItems = 4; 

    private RootObject root;
    private int currentIndex;

    // Start is called before the first frame update
    void Start()
    { 

        //read json file with serialization
        string jsonString = MySingleton.readJsonString();

        // Parse the JSON string
        RootObject root = JsonUtility.FromJson<RootObject>(jsonString);

        ShowItems(startIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ShowNextItems();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ShowPreviousItems();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectItem(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectItem(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectItem(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectItem(3);
        }
    }

    // Show next set of items
    void ShowNextItems()
    {
        startIndex += maxItems;
        if (startIndex >= root.items.Count)
        {
            startIndex = 0;
        }
        ShowItems(startIndex);
    }

    // Show previous set of items
    void ShowPreviousItems()
    {
        startIndex -= maxItems;
        if (startIndex < 0)
        {
            startIndex = Mathf.Max(0, root.items.Count - maxItems);
        }
        ShowItems(startIndex);
    }

    // Show items starting from startIndex
    void ShowItems(int startIndex)
    {
        for (int i = 0; i < maxItems; i++)
        {
            int index = startIndex + i;
            if (index < root.items.Count)
            {
                Debug.Log("Item " + (i + 1) + ": " + root.items[index].itemName);
            }
            else
            {
                // If there are no more items, break the loop
                break;
            }
        }
    }

    // Select item by index
    void SelectItem(int itemIndex)
    {
        int selectedIndex = startIndex + itemIndex;
        if (selectedIndex < root.items.Count)
        {
            Debug.Log("Selected item: " + root.items[selectedIndex].itemName);
        }
        else
        {
            Debug.Log("No item selected.");
        }
    }
}
    }
}
