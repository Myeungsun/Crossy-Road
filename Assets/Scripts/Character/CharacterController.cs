using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private static CharacterController _instance;

    public static CharacterController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("CharacterController").AddComponent<CharacterController>();
            }
            return _instance;
        }
    }
}
