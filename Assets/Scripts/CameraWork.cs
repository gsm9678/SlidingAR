using System.Collections;
using UnityEngine;

public class CameraWork : MonoBehaviour
{
    private bool _ver = false;
    private float _value;
    private float _speedlerp = 0f;
    private float _speedmt = 0f;

    IEnumerator WaitforPrepare()
    {
        yield return new WaitUntil(() => GameManager.GetGameManager.GetReadData.GetCompleted);

        _value = GameManager.GetGameManager.GetSerialData.GetValue;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitforPrepare());
    }

    // Update is called once per frame
    void Update()
    {
        GetkeyControll();
        _value = GameManager.GetGameManager.GetSerialData.GetValue;

        if (_ver == false)
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, new Vector3(_value - 11f, -0.5f, -16), _speedmt * Time.deltaTime);
        else
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(_value - 11f, -0.5f, -16), _speedlerp * Time.deltaTime);
    }

    void GetkeyControll()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (_ver == true)
                _speedlerp -= 0.5f;
            else
                _speedlerp -= 0.5f;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (_ver == true)
                _speedmt += 0.5f;
            else
                _speedmt += 0.5f;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad0)) _ver = false;
        else if (Input.GetKeyDown(KeyCode.Keypad1)) _ver = true;

    }
}
