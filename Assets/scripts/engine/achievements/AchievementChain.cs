﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SavedStat))]
public class AchievementChain : MonoBehaviour 
{
  [SerializeField]
  private string relevant_event_name;

  private Achievement[] achievements;
  private SavedStat tracked_stat;

  void Awake()
  {
    tracked_stat = GetComponent<SavedStat>();

    achievements = GetComponentsInChildren<Achievement>();
  }

  public void Increment()
  {
    AddValue(1);
  }

  public void AddValue(int value)
  {
    tracked_stat.AddValue(value);
    foreach (Achievement achieve in achievements)
    {
      achieve.CheckForCompletedAchievement();
    }
  }

  public string GetRelevantEventName()
  {
    return relevant_event_name;
  }

  public int GetTrackedStatValue()
  {
    return tracked_stat.GetValue();
  }
}
