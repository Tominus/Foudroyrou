using System;
using UnityEngine;

public class F_DayCycle : MonoBehaviour
{
    public event Action OnDay = null;
    public event Action OnNight = null;
    /// <summary>
    /// string param : Time format => "Hours : Minutes"
    /// </summary>
    public event Action<string> OnTimeChange = null;

    [SerializeField] float currentTime = 0, sunTickRate = .1f, rotationIncreasePerTick = .2f;
    /// <summary>
    /// Trigger treshold for Day/Night event
    /// </summary>
    [SerializeField] int nightTimeTrigger = 18,dayTimeTrigger = 8;
    Vector3 currentRotation = Vector3.zero;
    bool isDay = false;

    private void Start()
    {
        transform.eulerAngles = Vector3.zero;
        currentTime = 0;
        InvokeRepeating("TimeUpdate", 0, sunTickRate);
    }

    void TimeUpdate()
    {
        currentRotation += new Vector3(rotationIncreasePerTick, 0, 0);
        transform.eulerAngles = currentRotation;
        currentTime = (currentRotation.x / 15) + 7;
        currentTime = currentTime > 24 ? currentTime - 24 : currentTime;
        string _time = ((int)currentTime).ToString()+" : " + ((int)((currentTime % 1) * 60)).ToString() ;
        OnTimeChange?.Invoke(_time);
        if(currentTime > nightTimeTrigger && isDay)
        {
            OnNight?.Invoke();
            isDay = false;
            Debug.Log("Night");
        }
        if (currentTime > dayTimeTrigger && currentTime < nightTimeTrigger && !isDay)
        {
            OnDay?.Invoke();
            isDay = true;
            Debug.Log("Day");
        }
    }
}
