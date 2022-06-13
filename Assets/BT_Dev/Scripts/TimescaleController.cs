using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimescaleController : MonoBehaviour
{
    static private TimescaleController _instance;
    static public TimescaleController Instance { get { return _instance; } }

    private float currentTimescale;
    private bool systemPaused = false;
    public float Timescale { get { return currentTimescale; } }

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else if (_instance == this) { }
        else
            Destroy(gameObject);
    }

    public void SetTimescale(float t)
    {
        if (systemPaused) return;
        currentTimescale = t;
        Time.timeScale = t;
        Time.fixedDeltaTime = t * 0.02f;
    }

    public void Pause()
    {
        if (systemPaused) return;
        systemPaused = true;
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }

    public void Unpause()
    {
        if (!systemPaused) return;
        systemPaused = false;
        Time.timeScale = currentTimescale;
        Time.timeScale = currentTimescale * 0.02f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1.0f;
        Time.timeScale = 0.02f;
    }
}
