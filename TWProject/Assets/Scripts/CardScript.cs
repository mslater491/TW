/*
 * 
 * Attached to Card objects.
 * Holds a card's information.
 * Authored: Phil Manning, Email: night_gia@hotmail.com
 * 
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardScript : MonoBehaviour
{
    public CardData _data;

    public void Start()
    {
        _data = new CardData();
    }

    private void SetCardData(string name)
    {
        //_data = 
    }

    public CardData GetCardData()
    {
        return _data;
    }
}
