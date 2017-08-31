using UnityEngine;
using System;

public class ClockAnimator : MonoBehaviour
{
    private const float hoursToDegrees = 360f / 12f;
    private const float minutesToDegrees = 360f / 60f;
    private const float secondsToDegrees = 360f / 60f;

    public enum ClockType
    {
        digital, analog, analogDigital
    }

    public Transform hours, minutes, seconds;
    public ClockType analog;


    private void Update(){
        DateTime datetime = DateTime.Now;
        TimeSpan timespan = DateTime.Now.TimeOfDay;
        
        switch (analog){
            case ClockType.digital:
                hours.localRotation = Quaternion.Euler(0f, 0f, datetime.Hour * -hoursToDegrees);
                minutes.localRotation = Quaternion.Euler(0f, 0f, datetime.Minute * -minutesToDegrees);
                seconds.localRotation = Quaternion.Euler(0f, 0f, datetime.Second * -secondsToDegrees);
                break;
                
            case ClockType.analog:
                hours.localRotation = Quaternion.Euler(0f, 0f, (float)timespan.TotalHours * -hoursToDegrees);
                minutes.localRotation = Quaternion.Euler(0f, 0f, (float)timespan.TotalMinutes * -minutesToDegrees);
                seconds.localRotation = Quaternion.Euler(0f, 0f, (float)timespan.TotalSeconds * -secondsToDegrees);
                break;
                
            case ClockType.analogDigital:
                hours.localRotation = Quaternion.Euler(0f, 0f, (float)timespan.TotalHours * -hoursToDegrees);
                minutes.localRotation = Quaternion.Euler(0f, 0f, (float)timespan.TotalMinutes * -minutesToDegrees);
                seconds.localRotation = Quaternion.Euler(0f, 0f, datetime.Second * -secondsToDegrees);
                break;
                
            default:
                throw new ArgumentOutOfRangeException();
        }

    }
}
