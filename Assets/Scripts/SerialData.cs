using System.Collections;
using UnityEngine;
using System;

public class SerialData : MonoBehaviour
{
    public float _Value;
    private double _CalcuData = 0.004190476;

    IEnumerator SetCalcuData()
    {
        yield return new WaitUntil(() => GameManager.GetGameManager.GetReadData.GetCompleted);

        _CalcuData = GameManager.GetGameManager.GetReadData.GetCalcuData;
    }

    private void Start()
    {
        StartCoroutine(SetCalcuData());
    }

    void OnMessageArrived(string msg)
    {
        calcuMessage(msg);
    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection established");
        else
            Debug.Log("Connection attempt failed or disconnection detected");
    }

    void calcuMessage(string msg)
    {
        int PriValue;
        try
        {
            PriValue = Int32.Parse(msg);
            _Value = (float)PriValue * (float)_CalcuData;
        }
        catch (System.TimeoutException e)
        {
            Debug.Log(e);
            throw;
        }
    }

    #region Property

    public float GetValue { get { return _Value; } }

    #endregion
}
