using System;
using System.Globalization;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using Studious.Helpers;

public class Clock : MonoBehaviour
{
    [SerializeField] private TMP_Text ClockText;
    [SerializeField] private Button PlayButton;
    [SerializeField] private int GameSpeed = 2000;

    private Timer ClockTimer;
    private double ElapsedGameTime = 0;

    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        TimeSpan ts = TimeSpan.ParseExact("00:08:00", @"d\:hh\:mm", CultureInfo.InvariantCulture);
        ElapsedGameTime = ts.TotalMilliseconds;
        DisplayTime();

        ClockTimer = new Timer(GameSpeed);
        ClockTimer.Elapsed += HandleMinuteTick;
        ClockTimer.Start();

        PlayButton.Select();
    }

    /// <summary>
    /// 
    /// </summary>
    private void HandleMinuteTick(object sender, ElapsedEventArgs e)
    {
        ElapsedGameTime += 60000;
        RuntimeHelper.RunOnMainThread(() => DisplayTime());
    }

    /// <summary>
    /// 
    /// </summary>
    private void DisplayTime()
    {
        TimeSpan ts = TimeSpan.FromMilliseconds(ElapsedGameTime);
        DateTime time = DateTime.Today.Add(ts);

        ClockText.text = time.ToString("hh:mm tt");
    }

    /// <summary>
    /// 
    /// </summary>
    public void PauseClock()
    {
        ClockTimer.Enabled = false;
    }

    /// <summary>
    /// 
    /// </summary>
    public void NomalSpeed()
    {
        ClockTimer.Enabled = false;
        ClockTimer.Interval = GameSpeed;
        ClockTimer.Enabled = true;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Speed2x()
    {
        ClockTimer.Enabled = false;
        ClockTimer.Interval = GameSpeed / 3;
        ClockTimer.Enabled = true;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Speed3x()
    {
        ClockTimer.Enabled = false;
        ClockTimer.Interval = GameSpeed / 5;
        ClockTimer.Enabled = true;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Speed4x()
    {
        ClockTimer.Enabled = false;
        ClockTimer.Interval = GameSpeed / 8;
        ClockTimer.Enabled = true;
    }

    /// <summary>
    /// 
    /// </summary>
    private void OnDisable()
    {
        ClockTimer.Close();
    }


}
