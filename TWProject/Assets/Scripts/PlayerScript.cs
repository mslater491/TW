/*
 * 
 * Attached to Player objects.
 * Holds a player's information.
 * Authored: Phil Manning, Email: night_gia@hotmail.com
 * 
 */

using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public List<GameObject> _playerHand;
    public GameObject[] _playerDomain;

    public void Start()
    {
        _playerHand = new List<GameObject>();
        _playerDomain = new GameObject[40];
        //_playerDomain = PopulateDomain();
    }

    public GameObject[] PopulateDomain()
    {
        return null;
    }
}
