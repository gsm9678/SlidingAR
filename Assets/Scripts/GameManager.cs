using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _gameManager;
    private ReadData _readData;
    private SerialData _SerialData;

    private void Awake()
    {
        if (_gameManager == null)
        {
            _gameManager = this;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            return;
        }
        InitializeGameManager();
    }

    private void InitializeGameManager()
    {
        _readData = GameObject.Find("ReadData").GetComponent<ReadData>();
        _SerialData = GameObject.Find("GetSerialManager").GetComponent<SerialData>();
    }


    #region Properties
    public static GameManager GetGameManager { get { return _gameManager; } }
    public ReadData GetReadData { get { return _readData; } }
    public SerialData GetSerialData { get { return _SerialData; } }

    #endregion
}
