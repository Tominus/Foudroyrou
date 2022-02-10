using System;
using UnityEngine;

public class F_DayCycle : MonoBehaviour
{
#region event
    public event Action OnDay = null;
    public event Action OnNight = null;
    /// <summary>
    /// string param : Time format => "Hours : Minutes"
    /// </summary>
    public event Action<string> OnTimeChange = null;
    #endregion
#region SF
    /// <summary>
    /// Rate of the sun update
    /// </summary>
    [SerializeField] float sunTickRate = .1f;
    /// <summary>
    /// duration in minutes
    /// </summary>
    [SerializeField] float dayDuration = 3,nightDuration = 8;
    /// <summary>
    /// Trigger treshold for Day/Night event
    /// </summary>
    [SerializeField] int nightTimeTrigger = 18,dayTimeTrigger = 8;
    #endregion
#region Var
    Vector3 currentRotation = Vector3.zero;
    bool isDay = true;
    float currentTime = 0;
    float rotationIncreasePerTick = .1f;
#endregion
    private void Start()
    {
        transform.eulerAngles = Vector3.zero;
        currentTime = 0;
        //init Rotation speed (start at day speed)
        rotationIncreasePerTick = (sunTickRate/(dayDuration * 60f))* ((nightTimeTrigger - dayTimeTrigger)*15f);
        InvokeRepeating("TimeUpdate", 0, sunTickRate);
    }

    void TimeUpdate()
    {
        currentRotation += new Vector3(rotationIncreasePerTick, 0, 0);
        transform.eulerAngles = currentRotation;
        currentTime = (currentRotation.x / 15) + dayTimeTrigger;
        currentTime = currentTime > 24 ? currentTime - 24 : currentTime;
        if(currentTime > nightTimeTrigger && isDay)
        {
            OnNight?.Invoke();
            isDay = false;
            Debug.Log("Night");
            //Change rotation speed to match day/night duration
            rotationIncreasePerTick = (sunTickRate / (nightDuration * 60f)) * ((24-(nightTimeTrigger - dayTimeTrigger)) * 15f);
        }
        if (currentTime > dayTimeTrigger && currentTime < nightTimeTrigger && !isDay)
        {
            OnDay?.Invoke();
            isDay = true;
            Debug.Log("Day");
            //Change rotation speed to match day/night duration
            rotationIncreasePerTick = (sunTickRate / (dayDuration * 60f)) * ((nightTimeTrigger - dayTimeTrigger) * 15f);
        }
        string _time = ((int)currentTime).ToString() + " : " + ((int)((currentTime % 1) * 60)).ToString();
        OnTimeChange?.Invoke(_time);
    }
}
