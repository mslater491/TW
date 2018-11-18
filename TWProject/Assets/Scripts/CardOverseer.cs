/*
 * 
 * General Overseer for card management.
 * Loads all cards from CSV file (make using spreadsheet).
 * Authored: Phil Manning, Email: night_gia@hotmail.com
 * 
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardOverseer : MonoBehaviour
{
    // All cards
    public Dictionary<string, CardData> _allCards;

    // Awake() is called before all Start()
    public void Awake()
    {
        _allCards = new Dictionary<string, CardData>();

        // Convert CSV into string array
        LoadCardData();
    }

    // Reads card info in from cvs file
    private void LoadCardData()
    {
        string[] cardDataStrings = CSVOperations.Load("CardIndex");
        string[] line = new string[9];

        for (int i = 1; i < cardDataStrings.Length - 1; i++)
        {
            CardData tempData = new CardData();
            line = cardDataStrings[i].Split(',');
            tempData._name = line[0];
            tempData._type = (CardData.CardType)int.Parse(line[1]);
            tempData._deploymentCost = tempData.SetDeploymentCosts(line[2]);
            tempData._class = (CardData.CardClass)int.Parse(line[3]);
            tempData._subClass = line[4];
            //tempData._cardText.text = line[5];
            tempData._rarity = char.Parse(line[6]);
            tempData._statAttack = int.Parse(line[7]);
            tempData._statHP = int.Parse(line[8]);

            tempData._cardLocation = CardData.CurrentLocation.LOOSE;
            tempData._cardController = null;

            _allCards[line[0]] = tempData;
        }
    }

    void Update()
    {
        // TEST: DISPLAY TEST DATA READ IN FROM CSV
        if (Input.GetKeyUp(KeyCode.A))
        {
            foreach (KeyValuePair<string, CardData> kvp in _allCards)
            {
                Debug.LogError(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value._name));
                Debug.LogError(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value._type));
                foreach (KeyValuePair<string, int> deploy in kvp.Value._deploymentCost)
                {
                    Debug.LogError(string.Format("Key = {0}, Value = {1}", deploy.Key, deploy.Value));
                }
                Debug.LogError(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value._class));
                Debug.LogError(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value._subClass));
                //Debug.LogError(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value._cardText));
                Debug.LogError(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value._rarity));
                Debug.LogError(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value._statAttack));
                Debug.LogError(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value._statHP));
                //Debug.LogError(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value._picture));
                Debug.LogError(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value._cardLocation));
                Debug.LogError(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value._cardController));
            }
        }
        // END TEST
    }
}
    
// Class containing all information about a card
public class CardData
{
    public enum CardType { NULL, NATURE, SYNTHETIC, ZODIAC, ITEM };
    public enum CardClass { NULL, GENERAL, INFANTRY, OCCURENCE, RELIC, TERRAIN };
    public enum CurrentLocation { LOOSE, DOMAIN, HAND, FIELD, GRAVEYARD, EXPELLED };

    public string _name;
    public CardType _type;
    public Dictionary<string, int> _deploymentCost = new Dictionary<string, int>
    {
        { "Energy", 0 },
        { "Aether", 0 },
        { "Terra", 0 },
        { "Transgenic", 0 },
        { "Cyborg", 0 },
        { "Machine", 0 },
        { "Celestial", 0 },
        { "Demonic", 0 },
        { "Essence", 0 },
        { "None", 0 }
    };
    public CardClass _class;
    public string _subClass;
    public Text _cardText;
    public char _rarity;
    public int _statAttack;
    public int _statHP;
    public RawImage _picture;

    public CurrentLocation _cardLocation;
    public GameObject _cardController;

    // Assigns deployments costs to card
    public Dictionary<string, int> SetDeploymentCosts(string dataLine)
    {
        string[] values = new string[10];
        values = dataLine.Split('/');
        _deploymentCost["Energy"] = int.Parse(values[0]);
        _deploymentCost["Aether"] = int.Parse(values[1]);
        _deploymentCost["Terra"] = int.Parse(values[2]);
        _deploymentCost["Transgenic"] = int.Parse(values[3]);
        _deploymentCost["Cyborg"] = int.Parse(values[4]);
        _deploymentCost["Machine"] = int.Parse(values[5]);
        _deploymentCost["Celestial"] = int.Parse(values[6]);
        _deploymentCost["Demonic"] = int.Parse(values[7]);
        _deploymentCost["Essence"] = int.Parse(values[8]);
        _deploymentCost["None"] = int.Parse(values[9]);

        return _deploymentCost;
    }
}