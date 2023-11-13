using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public string locationName;

    [TextArea]
    public string description;

    public Connection[] connections;


    public List<Item> itemList = new List<Item>();    //items will change throughout gameplay so list is used


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetItemsText()
    {
        if (itemList.Count == 0) return "";           // if no items will return empty

        string result = "You see ";
        bool first = true;
        foreach (Item item in itemList)
        {
            if (item.itemEnabled)                   //will check to see if item is enabled in unity then will print the names into the game
            {
                if (!first) result += " and ";      //the first one is false so all the others will have an 'and' connector
                result += item.description;
                first = false;
            }
        }
        result += "\n"; //carriage return or new line
        return result; 
    }

    public string GetConnectionsText()              //will give directions for the player
    {
        string result = "";
        foreach (Connection connection in connections)
        {
            if (connection.connectionEnabled)
                result += connection.description + "\n";
        }
        return result;
    }

    internal bool HasItem(Item itemToCheck)
    {
        foreach (Item item in itemList)
        {
            if (item == itemToCheck && item.itemEnabled)
            {
                return true;
            }
        }
        return false;
    }


    public Connection GetConnection(string connectionNoun) //north, south etc
    {
        foreach(Connection connection in connections)
        {
            if (connection.connectionName.ToLower() == connectionNoun.ToLower()) //so it's not case sensitive
                return connection;
        }
        return null;
    }
}
