using System.Collections.Generic;
using Achievement;
using UnityEngine;
using UnityEngine.UIElements;

namespace Managers
{
    public class AchievementsManager : MonoBehaviour
    {

           #region Singleton
        
                private static AchievementsManager _instance;
        
                public static AchievementsManager Instance => _instance;


                private void Awake()
                {
                    if (_instance != null && _instance != this)
                    {
                        Destroy(this.gameObject);
                    } else {
                        _instance = this;
                    }
                }
        
                #endregion
          
        private UIManager _uiManager;
        
        [SerializeField]
        private List<Achievement.Achievement> achievements;
        

     

        private void Start()
        {
            _uiManager = UIManager.Instance;
        }

        public void UpdateAchievementProgress(AchievementTypes achievementType, int progress)
        {
            var updatedAchievements = new List<Achievement.Achievement>();
            foreach (var achievement in achievements)
            {
                if (achievement.achievementType == achievementType && !achievement.isFinished)
                {
                    achievement.UpdateProgress(progress);
                }
                updatedAchievements.Add(achievement);
            }
            achievements.Clear();
            achievements.AddRange(updatedAchievements);
        }
   

        private void Update()
        {
            var achievementList = _uiManager.AchievementsListView;
            achievementList.hierarchy.Clear();

            var titleLabel = new Label
            {
                text = "Achievements: ",
                style =
                {
                    color = new StyleColor(Color.white),
                    fontSize =new StyleLength(24f),
                    
                }
            };
            
            achievementList.hierarchy.Add(titleLabel);
            /*
             * Start updating the achievement list
             */
            foreach (var achievement in achievements)
            {
                var label = new Label
                {
                    text = $"{achievement.name} {achievement.progress}/{achievement.condition}",
                    style =
                    {
                    color = new StyleColor(Color.white),
                    fontSize =new StyleLength(14f),
                    
                    }
                };
                
                if (achievement.isFinished)
                {
                    label.text += " (DONE)";
                }
                
                achievementList.hierarchy.Add(label);

            }

        }
    }
}