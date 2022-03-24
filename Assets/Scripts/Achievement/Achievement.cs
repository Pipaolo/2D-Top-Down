using System;
using UnityEngine;

namespace Achievement
{
    [Serializable]
    public struct Achievement
    {
        public AchievementTypes achievementType;
        public int progress;
        public string name;
    
        public int condition;
        public bool isFinished;

        public void UpdateProgress(int progressAmount)
        {
            progress = Mathf.Clamp(progress + progressAmount, 0, condition);
            isFinished = condition <= progress;
        }
    }
}