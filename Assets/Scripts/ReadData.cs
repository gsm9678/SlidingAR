using System.Collections;
using UnityEngine;
using System.IO;
using System;

public class ReadData : MonoBehaviour
{
    #region Value

    private string _path;

    private string _com;

    private int _baudRate;

    private double _calcuData;

    private bool _completed = false;

    #endregion

    #region MonoBehaviour Method
    private void Awake()
    {
        StartCoroutine(Readtxt());
    }
    #endregion

    #region Coroutine
    private IEnumerator Readtxt()
    {
        _path = Application.dataPath;
        DirectoryInfo di = new DirectoryInfo(_path + @"\AR_Datafolder");
        if (!di.Exists)
            di.Create();
        if (!File.Exists(_path + @"\AR_Datafolder\Setting.txt"))
        {
            string allText = "// Readme :(클론) 뒤에 수치만 바꿀것! \n" +
                            "COM : COM3 \n" +
                            "BaudRate : 9600 \n" +
                            "CalcuData : 0.004190476";
            File.WriteAllText(_path + @"\AR_Datafolder\Setting.txt", allText);
        }
        yield return new WaitUntil(() => File.Exists(_path + @"\AR_Datafolder\Setting.txt"));
        string lien;
        StreamReader sr = new StreamReader(_path + @"\AR_Datafolder\Setting.txt");
        while ((lien = sr.ReadLine()) != null)
        {
            if (lien.IndexOf("//") == -1)
            {
                yield return null;

                if (lien.IndexOf("COM") != -1)
                {
                    string[] s = lien.Split(':');
                    s[1] = s[1].Trim();
                    _com = s[1];
                }
                else if (lien.IndexOf("BaudRate") != -1)
                {
                    string[] s = lien.Split(':');
                    s[1] = s[1].Trim();
                    _baudRate = int.Parse(s[1]);
                }
                else if (lien.IndexOf("CalcuData") != -1)
                {
                    string[] s = lien.Split(':');
                    s[1] = s[1].Trim();
                    _calcuData = Double.Parse(s[1]);
                }
            }
        }
        _completed = true;
    }
    #endregion

    #region Property

    public string GetCOM { get { return _com; } }
    public int GetBaudRate { get { return _baudRate; } }
    public double GetCalcuData { get { return _calcuData; } }
    public bool GetCompleted { get { return _completed; } }

    #endregion
}
